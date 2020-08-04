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
    public class DetailsModel : PageModel
    {
        private readonly Centralization.DAL.MemorialContext _context;

        public DetailsModel(Centralization.DAL.MemorialContext context)
        {
            _context = context;
        }

        public MemorialApplication MemorialApplication { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemorialApplication = await _context.MemorialApplications.FirstOrDefaultAsync(m => m.ID == id);

            if (MemorialApplication == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
