using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace elva
{
    class FileProcessor
    {
        private string BasePath = @"D:\MapPictures\";
        private IFileGetter Source { get; set; }
        public FileProcessor(IFileGetter getter)
        {
            Source = getter;
        }
        public void Process(string name, int n, string fileName)
        {
            byte[] byteArrayResult = null;
            MemoryStream bmpStream = new MemoryStream();
            Bitmap resultBitmap = null;
            using (var image = new Bitmap(Source.GetFile(name)))
            {
                resultBitmap = new Bitmap(image.Width - image.Width / n + image.Width % n, image.Height);
                for(int i=0;i<image.Height;i++)
                {
                    for (int j = 0, k = 0; j < image.Width; j++) 
                    {
                        if (j % n == 0)
                        {

                        }
                        else
                        {
                            resultBitmap.SetPixel(k, i, image.GetPixel(j,i));
                            k++;
                        }
                    }
                }
                image.Save(BasePath + "source.bmp",ImageFormat.Bmp);
            }
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);
            
             resultBitmap.Save(BasePath + fileName + ".bmp", ImageFormat.Bmp);
            
        }
    }
}
