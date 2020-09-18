using System.Collections.Generic;
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
        private readonly MemorialContext _memorialContext;
        private readonly IntermentContext _intermentContext;

        public DeleteModel(MemorialContext memorialContext, IntermentContext intermentContext)
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
                .Include(m => m.LinkedInterments).AsNoTracking()
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemorialApplication = await _memorialContext.MemorialApplications.FindAsync(id);

            if (MemorialApplication != null)
            {
                _memorialContext.MemorialApplications.Remove(MemorialApplication);
                await _memorialContext.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
