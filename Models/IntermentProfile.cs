using Centralization.Utilities;
using System.Collections.Generic;

namespace Centralization.Models
{
    public class IntermentProfile
    {
        public Interment Interred { get; }
        public List<string> IntermentOrderImages { get; }
        public List<string> EasementImages { get; }
        public List<string> LotCardImages { get; }

        public IntermentProfile(Interment interred)
        {
            Interred = interred;
            IntermentOrderImages = ImageGenerator.TiffToImages(interred.IOFullPath);
            EasementImages = ImageGenerator.TiffToImages(interred.EbFullPath);
            LotCardImages = ImageGenerator.TiffToImages(interred.LCFullPath);
        }
    }
}
