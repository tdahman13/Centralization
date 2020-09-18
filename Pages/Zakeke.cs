using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Centralization.Pages
{
    public class ZakekeModel : PageModel
    {
        private readonly ILogger<ZakekeModel> _logger;

        public ZakekeModel(ILogger<ZakekeModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
