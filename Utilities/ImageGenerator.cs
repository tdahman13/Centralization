using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Centralization.Utilities
{
    public class ImageGenerator
    {
        public static List<string> TiffToImages(string path)
        {
            if (!File.Exists(path))
            {
                return new List<string>();
            }

            // Create a bitmap from file counts pages in tiff and converts to images
            List<string> images = new List<string>();
            Bitmap bitmap = (Bitmap)Image.FromFile(path);
            int count = bitmap.GetFrameCount(FrameDimension.Page);
            for (int idx = 0; idx < count; idx++)
            {
                // save each frame to a bytestream
                bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                MemoryStream byteStream = new MemoryStream();
                bitmap.Save(byteStream, ImageFormat.Jpeg);

                // and then create a new URL from it
                byte[] bit = byteStream.ToArray();
                string imreBase64Data = Convert.ToBase64String(bit);
                string imgDataURL = string.Format("data:image/jpeg;charset=utf-8;base64,{0}", imreBase64Data);
                images.Add(imgDataURL);
                byteStream.Dispose();
            }
            bitmap.Dispose();
            return images;
        }
    }
}
