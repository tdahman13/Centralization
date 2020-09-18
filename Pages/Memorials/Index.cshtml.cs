using System.Collections.Generic;
using System.Threading.Tasks;
using Centralization.DAL;
using Centralization.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Centralization.Pages.Memorials
{
    public class IndexModel : PageModel
    {
        private readonly MemorialContext _context;

        public IndexModel(MemorialContext context)
        {
            _context = context;
        }

        public IList<MemorialApplication> MemorialApplication { get; set; }
        public string Confirmation { get; set; }

        // ReSharper disable once UnusedMember.Global  --- AJAX
        public async Task OnGetAsync(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                Confirmation = msg;
            }

            MemorialApplication = await _context.MemorialApplications
                .AsNoTracking().ToListAsync();
        }
    }
}
