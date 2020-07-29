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
            
            if(string.IsNullOrEmpty(interred.EbTifPath) || string.IsNullOrEmpty(interred.EbTifName))
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
        }
    }

    class BackupPathGenerator
    {
        private readonly DocumentContext _context = new DocumentContext();


        public string GetIntermentOrderPathBackup(Interment interred)
        {
            var intermentOrder = _context.IntermentOrders.Where(
                x => interred.GraveCrypt.Equals(x.Grave) && interred.LotTier.Equals(x.Lot)
                && interred.BlockBuilding.Equals(x.Block) && interred.SectionLocation.Equals(x.Section)
                && interred.CemNo.Equals(x.Cemid))
                .FirstOrDefault();

            string path = interred.IOFullPath + intermentOrder.Tifpath + intermentOrder.Iotif;
            return path;
        }

        public string GetEasementPathBackup(Interment interred)
        {
            var easement = _context.Easements.Where(
                x => interred.EasementNo.Equals(x.Easementno) && interred.CemNo.Equals(x.Cemid)
                && interred.IDate == x.Date)
                .FirstOrDefault();

            string path = interred.EbFullPath + easement.Tifpath + easement.Ebtif;
            return path;
        }

        public string GetLotCardPathBackup(Interment interred)
        {
            var lotCardID = _context.LotCardInventory.Where(
                x => interred.GraveCrypt.Equals(x.Grave) && interred.LotTier.Equals(x.Lot)
                && interred.BlockBuilding.Equals(x.Block) && interred.SectionLocation.Equals(x.Section)
                && interred.CemNo.Equals(x.CemNum))
                .FirstOrDefault().LotCardId;

            var lotCard = _context.LotCards.Find(lotCardID);

            string path = interred.LCFullPath + lotCard.Tifpath + lotCard.Lctif;
            return path;
        }
    }
}
