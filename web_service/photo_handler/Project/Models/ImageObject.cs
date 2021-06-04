using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleServerApp
{
    public class ImageObject
    {
        public string path { get;private set; }
        public string nameFile { get; private set; }
        public int numberOfFile { get; private set; }
        public Image image { get; set; }
        public ImageObject(string path,string nameFile,Image img)
        {
            this.path = path;
            this.nameFile = nameFile;
         
            image = img;
        }
        public int CountPeople =0;
        public void AddCount(int Count)
        {
            CountPeople = Count;
        }
    }
}
