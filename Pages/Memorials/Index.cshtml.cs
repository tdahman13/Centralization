using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Centralization.DAL;
using Centralization.Models;

namespace Centralization.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly Centralization.DAL.MemorialContext _context;

        public IndexModel(Centralization.DAL.MemorialContext context)
        {
            _context = context;
        }

        public IList<MemorialApplication> MemorialApplication { get;set; }

        public async Task OnGetAsync()
        {
            MemorialApplication = await _context.MemorialApplications.ToListAsync();
        }
    }
}
