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
    public class DeleteModel : PageModel
    {
        private readonly Centralization.DAL.MemorialContext _context;

        public DeleteModel(Centralization.DAL.MemorialContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemorialApplication MemorialApplication { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemorialApplication = await _context.MemorialApplication.FirstOrDefaultAsync(m => m.ID == id);

            if (MemorialApplication == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemorialApplication = await _context.MemorialApplication.FindAsync(id);

            if (MemorialApplication != null)
            {
                _context.MemorialApplication.Remove(MemorialApplication);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
