﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Centralization.Models
{
    public class Interment
    {
        private const string PathStart = @"\\imageserver\CemeteryDocuments\";
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
                    return
                        $"Crypt: {GraveCrypt} | Tier: {LotTier} | Building: {BlockBuilding} | Location: {SectionLocation}";
                }
                else
                {
                    return
                        $"Grave: {GraveCrypt} | Lot: {LotTier} | Block: {BlockBuilding} | Section: {SectionLocation}";
                }
            }
        }

        public string Label
        {
            get
            {
                return
                    $"{LastName}, {FirstName} - G: {GraveCrypt} | L: {LotTier} | B: {BlockBuilding} | S: {SectionLocation} => Buried {IDate?.ToString("MM/dd/yyyy")}";
            }
        }

        public string Value
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
    }
}
