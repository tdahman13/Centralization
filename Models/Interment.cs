using System;
using System.ComponentModel.DataAnnotations;

namespace Centralization.Models
{
    public class Interment
    {
        private readonly string PathStart = @"\\imageserver\CemeteryDocuments\";
        public int Idf { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Display(Name = "Grave/Crypt")]
        public string GraveCrypt { get; set; }

        [Display(Name = "Lot/Tier")]
        public string LotTier { get; set; }

        [Display(Name = "Block/Building")]
        public string BlockBuilding { get; set; }

        [Display(Name = "Section/Location")]
        public string SectionLocation { get; set; }

        [Display(Name = "Date Interred")]
        [DataType(DataType.Date, ErrorMessage = "Must be valid Date mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^((0[1-9])|(1[0-2]))\/((0[1-9])|(1[0-9])|(2[0-9])|(3[0-1]))\/(\d{4})$", ErrorMessage = "Not a valid date mm/dd/yyyy")]
        public DateTime? IDate { get; set; }

        [Display(Name = "Cemetery Number")]
        public string CemNo { get; set; }

        [Display(Name = "Cemetery")]
        public string CemName => Cemeteries.cems[CemNo];

        [Display(Name = "Parent Cemetery Name")]
        public string ParentCemName => Cemeteries.parentCems[CemNo];

        public string Type { get; set; }

        [Display(Name = "Easement Number")]
        public string EasementNo { get; set; }
        public string IOTifName { get; set; }
        public string IOTifPath { get; set; }
        public string IOFullPath
        {
            get { return PathStart + ParentCemName + IOTifPath + IOTifName; }
        }
        public string EbTifName { get; set; }
        public string EbTifPath { get; set; }
        public string EbFullPath
        {
            get { return PathStart + ParentCemName + EbTifPath + EbTifName; }
        }
        public string LCTifName { get; set; }
        public string LCTifPath { get; set; }
        public string LCFullPath
        {
            get { return PathStart + ParentCemName + LCTifPath + LCTifName; }
        }
        public string ICTifName { get; set; }
        public string ICTifPath { get; set; }
        public string ICFullPath
        {
            get { return PathStart + ParentCemName + ICTifPath + ICTifName; }
        }
        public string Location
        {
            get
            {
                if (string.IsNullOrEmpty(Type))
                {
                    return string.Empty;
                }
                if (Type.Equals("1") || Type.Equals("4"))
                {
                    return string.Format("Crypt: {0} | Tier: {1} | Building: {2} | Location: {3}",
                        GraveCrypt, LotTier, BlockBuilding, SectionLocation);
                }
                else
                {
                    return string.Format("Grave: {0} | Lot: {1} | Block: {2} | Section: {3}",
                        GraveCrypt, LotTier, BlockBuilding, SectionLocation);
                }
            }
        }

        public string Label
        {
            get
            {
                return string.Format("{0} {1} - G: {2} | L: {3} | B: {4} | S: {5} => Buried {6} at {7}",
                    LastName, FirstName, GraveCrypt, LotTier, BlockBuilding, SectionLocation,
                    IDate?.ToString("MM/dd/yyyy"), CemName);
            }
        }
    }
}
