using System.Collections.Generic;
using System.Linq;
using Centralization.DAL;
using Centralization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Centralization.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IntermentContext _context;
        public Interment interment;
        public List<SelectListItem> cemeteries = Cemeteries.cemeteriesSelectList;

        public SearchModel(IntermentContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            interment = new Interment();
            //interments = await _context.Interments.Take(100).ToListAsync();
        }

        public IActionResult OnGetSearchBothNames(string term, string cemetery)
        {
            string first, last;
            var intermentsIQ = from z in _context.Interments
                               select z;

            if (!string.IsNullOrEmpty(cemetery))
            {
                intermentsIQ = intermentsIQ.Where(x => x.CemNo.Equals(cemetery));
            }

            if (term.Contains(','))
            {
                string[] name = term.Split(',');
                last = name[0];
                first = name[1].Trim();
                for (int i = 2; i < name.Length; i++)
                {
                    first += name[i];
                }
                intermentsIQ = intermentsIQ.AsNoTracking()
                    .Where(x => x.LastName.Contains(last) && x.FirstName.Contains(first));
            }
            else
            {
                intermentsIQ = intermentsIQ.AsNoTracking()
                    .Where(x => x.LastName.Contains(term));
            }

            var result = intermentsIQ.AsNoTracking().Take(500).AsQueryable();

            return new JsonResult(result);
        }

        public IActionResult OnGetSearchFullNames(string term, string cemetery)
        {
            // Call stored procedure to get interments, cemetery can be null
            var names = _context.Interments.FromSqlRaw("GetIntermentsByFullNameAndCemNo @p0, @p1", term, cemetery);
            var result = names.AsNoTracking().AsQueryable();

            return new JsonResult(result);
        }

        public IActionResult OnGetSearchLocation(string cemetery, string grave, string lot, string block, string section, bool exactSearch)
        {
            var intermentIQ = from z in _context.Interments
                              select z;
            if (!string.IsNullOrEmpty(cemetery))
                intermentIQ = intermentIQ.Where(z => z.CemNo.Equals(cemetery));

            if (exactSearch)
            {
                intermentIQ = intermentIQ.Where(z => (grave == null ? z.GraveCrypt.Equals(""): z.GraveCrypt.Equals(grave)) 
                    && (lot == null ? z.LotTier.Equals(""): z.LotTier.Equals(lot))
                    && (block == null ? z.BlockBuilding.Equals(""): z.BlockBuilding.Equals(block)) 
                    && (section == null ? z.SectionLocation.Equals(""): z.SectionLocation.Equals(section)));
            }
            else
            {
                intermentIQ = intermentIQ.Where(z => (grave == null ? z.GraveCrypt.Contains(""): z.GraveCrypt.Contains(grave)) 
                    && (lot == null ? z.LotTier.Contains(""): z.LotTier.Contains(lot))
                    && (block == null ? z.BlockBuilding.Contains(""): z.BlockBuilding.Contains(block))
                    && (section == null ? z.SectionLocation.Contains(""): z.SectionLocation.Contains(section)));
            }

            var result = intermentIQ.AsNoTracking().Take(500).ToArray();
            return new JsonResult(result);
        }

        public IActionResult OnGetData(int idf, string cemNo)
        {
            if (cemNo.Length == 1)
            {
                cemNo = "0" + cemNo;
            }
            var interment = _context.Interments.Find(new object[] { idf, cemNo });
            var intermentProfile = new IntermentProfile(interment);

            return Partial("_intermentPartial", intermentProfile);
        }
    }
}
