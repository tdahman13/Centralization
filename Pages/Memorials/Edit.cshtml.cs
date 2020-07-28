using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Centralization.DAL;
using Centralization.Models;

namespace Centralization.Pages.Applications
{
    public class EditModel : PageModel
    {
        private readonly Centralization.DAL.MemorialContext _context;

        public EditModel(Centralization.DAL.MemorialContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MemorialApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemorialApplicationExists(MemorialApplication.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemorialApplicationExists(int id)
        {
            return _context.MemorialApplication.Any(e => e.ID == id);
        }
    }
}
