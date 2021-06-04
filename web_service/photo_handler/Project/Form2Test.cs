using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleServerApp;
using Emgu.CV;
using Emgu.CV.Structure;
using Project.Models;

namespace Project
{
    public partial class Form2Test : Form
    {
        private System.Object lockThis = new System.Object();
        public Form2Test()
        {
            InitializeComponent();
            
            Task task = new Task(StartApp);
            task.Start();
        }
        private string[] Filter = new string[] { "jpg", "jpeg", "png" };
        private String searchFolder = @"C:\projects\py\NURE_practice_2021\web_service\media\raw_photos\";
        private ImageObject imageObject;
        WriteServerFiles serverFiles = new WriteServerFiles();
        ChangePicture change = new ChangePicture();
        public void ScanImage()
        {
            ServerImage image = new ServerImage();
            var files = image.GetFilesFrom(searchFolder, Filter, false);
            string result;
            foreach (var file in files)
            {
                result = Path.GetFileNameWithoutExtension(file);
                Image image1 = Image.FromFile(file);
                image1.Dispose();
                imageObject = new ImageObject(file, result,image1);
                StorageImage.storage.Add(imageObject);
                result = null;
                image1 = null;
            }
        }
        public void StartApp()
        {
            while (true)
            {
                try
                {
                    lock (lockThis)
                    {
                        ScanImage();
                        if (StorageImage.storage.Count > 0)
                        {
                            change.AddDate();
                            serverFiles.SaveImages();
                        }
                        else
                        {

                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Thread.Sleep(2000);

            }
        }
        
        private void Form2Test_Load(object sender, EventArgs e)
        {
            
        }
    }
}
