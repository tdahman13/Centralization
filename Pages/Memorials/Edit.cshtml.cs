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
    public class EditModel : PageModel
    {
        private readonly MemorialContext _memorialContext;
        private readonly IntermentContext _intermentContext;

        public EditModel(MemorialContext memorialContext, IntermentContext intermentContext)
        {
            _memorialContext = memorialContext;
            _intermentContext = intermentContext;
        }

        [BindProperty]
        public MemorialApplication MemorialApplication { get; set; }
        public List<Interment> Interments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemorialApplication = await _memorialContext.MemorialApplications
                .Include(m => m.LinkedInterments)
                .FirstOrDefaultAsync(m => m.MemorialApplicationId == id);

            if (MemorialApplication == null)
            {
                return NotFound();
            }

            Interments = new List<Interment>();
            foreach(var interred in MemorialApplication.LinkedInterments)
            {
                var interment = await _intermentContext.Interments
                    .FindAsync(new object[] { interred.Idf, interred.CemNo });
                Interments.Add(interment);
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

            _memorialContext.Attach(MemorialApplication).State = EntityState.Modified;

            try
            {
                await _memorialContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemorialApplicationExists(MemorialApplication.MemorialApplicationId))
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
            return _memorialContext.MemorialApplications.Any(e => e.MemorialApplicationId == id);
        }
    }
}
