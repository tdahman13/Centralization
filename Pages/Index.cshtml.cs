using System.Collections.Generic;
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

        public async Task OnGetAsync()
        {
            interments = await _context.Interments.Take(100).ToListAsync();
        }

        public IActionResult OnGetSearch(string term)
        {
            var intermentsIQ = from z in _context.Interments
                             select z;

            intermentsIQ = intermentsIQ.AsNoTracking()
                .Where(x => x.LastName.Contains(term));
            var result = intermentsIQ.Take(500).ToList();

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
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Interment>(ViewData, intermentProfile)
            };
        }
    }
}
