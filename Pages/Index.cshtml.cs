﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centralization.DAL;
using Centralization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Centralization.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IntermentContext _context;
        public List<Interment> interments;
        public List<SelectListItem> cemeteries = Cemeteries.cemeteriesSelectList;

        public IndexModel(ILogger<IndexModel> logger, IntermentContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Interment emptyInterred = new Interment();
            interments = new List<Interment> { emptyInterred };
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

        public PartialViewResult OnGetData(int idf, string cemNo)
        {
            var interment = _context.Interments.Find(new object[] { idf, cemNo });
            var intermentProfile = new IntermentProfile(interment);
            //return new JsonResult(interment);
            return new PartialViewResult
            {
                ViewName = "_IntermentPartial",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IntermentProfile>(ViewData, intermentProfile)
            };
        }
    }
}
