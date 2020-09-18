using System;
using System.IO;
using System.Threading.Tasks;
using Centralization.DAL;
using Centralization.Models;
using Centralization.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Centralization.Pages.Memorials
{
    public class CreateModel : PageModel
    {
        private readonly MemorialContext _context;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt", ".pdf" };
        private readonly string _targetFilePath;

        public CreateModel(MemorialContext context, IConfiguration config)
        {
            _context = context;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            // To save physical files to path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");

            // To save physical files to temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }

        [BindProperty]
        public MemorialApplication MemorialApplication { get; set; }
        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public string Result { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // ReSharper disable once UnusedMember.Global --- AJAX
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";
                return Page();
            }

            // Save file in folder
            byte[] formFileContent = await FileHelpers.ProcessFormFile<IFormFile>(
                FileUpload, ModelState, _permittedExtensions, _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";
                return Page();
            }

            // For the file name of the uploaded file stored server-side, use
            // Path.GetRandomFileName to generate a safe random file name.
            var trustedFileNameForFileStorage = Path.GetRandomFileName();
            var folder = _targetFilePath + MemorialApplication.GetPath();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filePath = Path.Combine(folder, trustedFileNameForFileStorage);
            while (System.IO.File.Exists(filePath))
            {
                trustedFileNameForFileStorage = Path.GetRandomFileName();
                filePath = Path.Combine(folder, trustedFileNameForFileStorage);
            }
            // **WARNING!**
            // In the following example, the file is saved without scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API is used on the file before making the file available
            // for download or for use by other systems. For more information, see the topic that accompanies this sample.
            await using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with the FormFiles, use the following instead:
                //await FileUpload.CopyToAsync(fileStream);
            }

            // Set and Save Application in DB
            MemorialApplication.FilePath = MemorialApplication.GetPath();
            MemorialApplication.FileName = trustedFileNameForFileStorage;
            MemorialApplication.UploadDate = DateTime.Now;
            await _context.MemorialApplications.AddAsync(MemorialApplication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { msg = "Application Successfully Added" });
        }
    }
}
