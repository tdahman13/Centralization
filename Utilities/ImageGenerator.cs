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

        //public static byte[] TiffToPdf(string path)
        //{
        //    // creation of the document with a certain size and certain margins
        //    MemoryStream ms = new MemoryStream();
        //    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);

        //    // Creation of the different writers
        //    PdfWriter writer = PdfWriter.GetInstance(document, ms);

        //    // Load the tiff image and count the total number of pages
        //    Bitmap bmp = new Bitmap(path);
        //    int total = bmp.GetFrameCount(FrameDimension.Page);

        //    document.Open();
        //    PdfContentByte cb = writer.DirectContent;
        //    for (int k = 0; k < total; ++k)
        //    {
        //        bmp.SelectActiveFrame(FrameDimension.Page, k);
        //        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bmp, ImageFormat.Bmp);
        //        // Scale the image to fit in the page
        //        img.ScalePercent(72f / img.DpiX * 100);
        //        img.SetAbsolutePosition(0, 0);
        //        cb.AddImage(img);
        //        document.NewPage();
        //    }

        //    //Flushing memory
        //    bmp.Dispose();
        //    writer.Flush();
        //    document.Close();
        //    document.Dispose();

        //    byte[] pdf = ms.ToArray();
        //    return pdf;
        //}
    }
}
