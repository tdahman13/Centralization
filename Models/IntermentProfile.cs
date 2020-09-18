using Centralization.DAL;
using Centralization.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Centralization.Models
{
    public class IntermentProfile
    {
        public Interment Interred { get; }
        public List<string> IntermentOrderImages { get; }
        public List<string> EasementImages { get; }
        public List<string> LotCardImages { get; }
        public List<string> IntermentCardImages { get; }
        public List<string> DocumentImages { get; }

        public IntermentProfile(Interment interred)
        {
            Interred = interred;
            IntermentCardImages = ImageGenerator.TiffToImages(interred.ICFullPath);
            BackupPathGenerator pg = new BackupPathGenerator();

            if(string.IsNullOrEmpty(interred.IOTifPath) || string.IsNullOrEmpty(interred.IOTifName))
            {
                string backupPath = pg.GetIntermentOrderPathBackup(interred);
                IntermentOrderImages = ImageGenerator.TiffToImages(backupPath);
            }
            else
            {
                IntermentOrderImages = ImageGenerator.TiffToImages(interred.IOFullPath);
            }
            
            if((string.IsNullOrEmpty(interred.EbTifPath) || string.IsNullOrEmpty(interred.EbTifName))
                && !string.IsNullOrEmpty(interred.EasementNo))
            {
                string backupPath = pg.GetEasementPathBackup(interred);
                EasementImages = ImageGenerator.TiffToImages(backupPath);
            }
            else
            {
                EasementImages = ImageGenerator.TiffToImages(interred.EbFullPath);
            }
            
            if(string.IsNullOrEmpty(interred.LCTifPath) || string.IsNullOrEmpty(interred.LCTifName))
            {
                string backupPath = pg.GetLotCardPathBackup(interred);
                LotCardImages = ImageGenerator.TiffToImages(backupPath);
            }
            else
            {
                LotCardImages = ImageGenerator.TiffToImages(interred.LCFullPath);
            }

            string documentPath = pg.GetDocumentsPath(interred);
            DocumentImages = !string.IsNullOrEmpty(documentPath) ? ImageGenerator.TiffToImages(documentPath) : new List<string>();
        }
    }

    internal class BackupPathGenerator
    {
        private readonly DocumentContext _context = new DocumentContext();


        public string GetIntermentOrderPathBackup(Interment interred)
        {
            string grave = interred.GraveCrypt;
            string lot = interred.LotTier;
            string block = interred.BlockBuilding;
            string section = interred.SectionLocation;

            IntermentOrder intermentOrder = _context.IntermentOrders
                .FirstOrDefault(x => (grave == null ? x.Grave.Equals(""): x.Grave.Equals(grave))  
                                     && (lot == null ? x.Lot.Equals(""): x.Lot.Equals(lot))
                                     && (block == null ? x.Block.Equals(""): x.Block.Equals(block))
                                     && (section == null ? x.Section.Equals(""): x.Section.Equals(section))
                                     && interred.CemNo.Equals(x.Cemid));

            string path = interred.IOFullPath;
            if (intermentOrder != null)
                path = path + intermentOrder.Tifpath + intermentOrder.Iotif;
            return path;
        }

        public string GetEasementPathBackup(Interment interred)
        {
            Easements easement = _context.Easements
                .FirstOrDefault(x => interred.EasementNo.Equals(x.Easementno) && interred.CemNo.Equals(x.Cemid)
                                                                              && interred.IDate == x.Date);

            string path = interred.EbFullPath;
            if (easement != null)
                path = path + easement.Tifpath + easement.Ebtif;
            return path;
        }

        public string GetLotCardPathBackup(Interment interred)
        {
            string grave = interred.GraveCrypt;
            string lot = interred.LotTier;
            string block = interred.BlockBuilding;
            string section = interred.SectionLocation;

            LotCardInventory lotCardId = _context.LotCardInventory
                .FirstOrDefault(x => (grave == null ? x.Grave.Equals(""): x.Grave.Equals(grave))
                                     && (lot == null ? x.Lot.Equals(""): x.Lot.Equals(lot))
                                     && (block == null ? x.Block.Equals(""): x.Block.Equals(block))
                                     && (section == null ? x.Section.Equals(""): x.Section.Equals(section))
                                     && interred.CemNo.Equals(x.CemNum));

            if (lotCardId != null)
            {
                LotCard lotCard = _context.LotCards
                    .FirstOrDefault(x => lotCardId.LotCardId == x.Id
                                         && (lot == null ? x.Lot.Equals("") : x.Lot.Equals(lot))
                                         && (block == null ? x.Block.Equals("") : x.Block.Equals(block))
                                         && (section == null ? x.Section.Equals("") : x.Section.Equals(section))
                                         && interred.CemNo.Equals(x.Cemid));
                if (lotCard != null)
                    return interred.LCFullPath + lotCard.Tifpath + lotCard.Lctif;
                return interred.LCFullPath;
            }

            return interred.LCFullPath;
        }

        public string GetDocumentsPath(Interment interred)
        {
            string grave = interred.GraveCrypt;
            string lot = interred.LotTier;
            string block = interred.BlockBuilding;
            string section = interred.SectionLocation;

            DocFile document = _context.DocFiles
                .FirstOrDefault(x => (lot == null ? x.Lot.Equals(""): x.Lot.Equals(lot))
                                     && (block == null ? x.Block.Equals(""): x.Block.Equals(block))
                                     && (section == null ? x.Section.Equals(""): x.Section.Equals(section))
                                     && interred.CemNo.Equals(x.Cemid)
                                     && (interred.GraveCrypt.Equals(x.Gravehigh) || interred.GraveCrypt.Equals(x.Gravelow)));

            if (document != null)
                return @"\\imageserver\CemeteryDocuments\" + interred.ParentCemName + document.Tifpath + document.Dftif;
            return string.Empty;
        }
    }
}
