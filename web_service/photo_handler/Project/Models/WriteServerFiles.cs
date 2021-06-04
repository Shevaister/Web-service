using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
//using Emgu;
//using Emgu.CV;
//using Emgu.Util;
//using Emgu.CV.Structure;
//using Emgu.CV.Util;
using Project.Models;

namespace ConsoleServerApp
{
   public class WriteServerFiles
    {

        public void SaveImages()
        {

            for (int i = 0; i < StorageImage.storage.Count; i++)
            {
                Image image = StorageImage.storage[i].image;
                image.Save(@"C:\projects\py\NURE_practice_2021\web_service\media\buff\" + StorageImage.storage[i].nameFile + "_" + StorageImage.storage[i].CountPeople + ".png", System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();
                
            }
            //for (var i = 0; i < StorageImage.storage.Count; i++)
            //{
            //    Path.GetExtension(StorageImage.storage[i].path);
            //    if (File.Exists(StorageImage.storage[i].path))
            //    {
            //        File.Delete(StorageImage.storage[i].path);
            //    }
            //}
            StorageImage.storage.Clear();
            DirectoryInfo dir = new DirectoryInfo(@"C:\projects\py\NURE_practice_2021\web_service\media\raw_photos\");
            foreach (FileInfo delfiles in dir.GetFiles())
            {
                delfiles.Delete();
            }
        }
      

    }
}
