
using Emgu.CV;
using Emgu.CV.Structure;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ConsoleServerApp
{
    public class ChangePicture
    {
        private Image<Bgr, byte> inputImage;
        private int Counter;
        public void AddDate()
        {
            for (int i = 0; i < StorageImage.storage.Count; i++)
            {
                inputImage = new Image<Bgr, byte>(StorageImage.storage[i].path);
                Bitmap bitmapImage = new Bitmap(inputImage.Bitmap);
                string facePath = Path.GetFullPath("lbpcascade_frontalface.xml");


                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = inputImage.Convert<Gray, byte>().Clone();
                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var face in faces)
                {
                    inputImage.Draw(face, new Bgr(0, 0, 255), 2);
                    Counter++;
                    imgGray.ROI = face;
                }
                StorageImage.storage[i].CountPeople = Counter;
                StorageImage.storage[i].image = inputImage.Bitmap;
                Counter = 0;
            }
        }
       

    }
}
