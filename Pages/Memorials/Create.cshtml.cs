using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Centralization.DAL;
using Centralization.Models;

namespace Centralization.Pages.Applications
{
    public class CreateModel : PageModel
    {
        private readonly MemorialContext _context;

        public CreateModel(MemorialContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MemorialApplication MemorialApplication { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MemorialApplication.UploadDate = DateTime.Now;
            _context.MemorialApplication.Add(MemorialApplication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
