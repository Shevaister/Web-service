using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleServerApp
{
   public class ServerImage
    {
        public string[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
        //public  List<String> GetAllFiles(String directory)
        //{
        //    List<String> filesFound = new List<String>();
        //    using (var stream = File.Open(directory, FileMode.Open, FileAccess.Write, FileShare.Read))
        //    {
        //        filesFound.Add(stream);
        //    }
        //    string[] allfiles = Directory.GetFiles(directory);
        //    foreach(var file in allfiles)
        //    {
        //        filesFound.Add(file);
        //    }
        //    return filesFound;
        //}
    }
}
