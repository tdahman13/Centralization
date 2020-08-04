using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Centralization.Models
{
    public class MemorialApplication
    {
        public int MemorialApplicationID { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "File Path")]
        public string FilePath { get; set; }

        [EnumDataType(typeof(ApplicationType))]
        [Display(Name = "Application Type")]
        public ApplicationType Type { get; set; }

        [Display(Name = "Upload Date")]
        [DataType(DataType.Date, ErrorMessage = "Must be valid Date mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^((0[1-9])|(1[0-2]))\/((0[1-9])|(1[0-9])|(2[0-9])|(3[0-1]))\/(\d{4})$", ErrorMessage = "Not a valid date mm/dd/yyyy")]
        public DateTime UploadDate { get; set; }

        [Display(Name = "Uploaded By")]
        public string UploadedBy { get; set; }

        [Display(Name = "Cemetery")]
        public string CemNo { get; set; }

        public List<LinkedInterment> LinkedInterments { get; set; }

        public string GetPath()
        {
            return string.Format(@"\{0}\{1}-{2}\{3}\{4}\", Cemeteries.parentCems[CemNo],
                CemNo, Cemeteries.cems[CemNo], Type, DateTime.Now.Year);
        }
    }

    public enum ApplicationType
    {
        [Display(Name = "Optional Complete Service")]
        OptionalCompleteService = 0,
        [Display(Name = "Complete Cemetery Service")]
        CompleteCemeteryService = 1,
        [Display(Name = "Niche Plaque Order Form")]
        CryptPlaque = 2,
        [Display(Name = "Crypt Plaque Order Form")]
        NichePlaque = 3
    }
}
