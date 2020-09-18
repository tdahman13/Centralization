using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centralization.DAL;
using Centralization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Centralization.Pages.Memorials
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

        // ReSharper disable once UnusedMember.Global --- AJAX
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
                    .FindAsync(interred.Idf, interred.CemNo);
                Interments.Add(interment);
            }
            return Page();
        }

        // ReSharper disable once UnusedMember.Global --- AJAX
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
