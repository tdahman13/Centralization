using System;
using System.ComponentModel.DataAnnotations;

namespace Centralization.Models
{
    public class MemorialApplication
    {
        public int ID { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public ApplicationType Type { get; set; }

        public DateTime UploadDate { get; set; }

        public string UploadedBy { get; set; }

        public Interment Interred { get; set; }
    }

    public enum ApplicationType
    {
        OptionalCompleteService = 0,
        CompleteCemeteryService = 1,
        CryptPlaque = 2,
        NichePlaque = 3
    }
}
