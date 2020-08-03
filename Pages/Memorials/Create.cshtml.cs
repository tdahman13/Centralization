using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Centralization.DAL;
using Centralization.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Centralization.Utilities;
using System.IO;
using System.Collections.Generic;

namespace Centralization.Pages.Applications
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";
                return Page();
            }

            // Save file in folder
            var formFileContent = await FileHelpers.ProcessFormFile<IFormFile>(
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

            var filePath = Path.Combine(folder, trustedFileNameForFileStorage);

            // **WARNING!**
            // In the following example, the file is saved without scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API is used on the file before making the file available
            // for download or for use by other systems. For more information, see the topic that accompanies this sample.
            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with the FormFiles, use the following instead:
                //await FileUpload.CopyToAsync(fileStream);
            }

            // Linked Interments
            var inter1 = new LinkedInterment
            {
                CemNo = "05",
                Idf = 123
            };
            var inter2 = new LinkedInterment
            {
                CemNo = "05",
                Idf = 111
            };
            List<LinkedInterment> interments = new List<LinkedInterment>
            {
                inter1, inter2
            };

            // Set and Save Application in DB
            MemorialApplication.FilePath = MemorialApplication.GetPath();
            MemorialApplication.FileName = trustedFileNameForFileStorage;
            MemorialApplication.UploadDate = DateTime.Now;
            MemorialApplication.LinkedInterments = interments;
            _context.MemorialApplication.Add(MemorialApplication);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
