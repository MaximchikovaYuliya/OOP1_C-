using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LR_13
{
    static class MYSFileInfo
    {
        public static void GetFullPath(string path)
        {
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"\nFile name: {file.Name}");
            Console.WriteLine($"Full path: {file.DirectoryName}");

            MYSLog.GetLog("Getting full path of file", file.Name,file.FullName, DateTime.Now.ToString());
        }

        public static void GetFileInfo(string path)
        {
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"\nFile name: {file.Name}");
            Console.WriteLine($"File size: {file.Length}");
            Console.WriteLine($"File extension: {file.Extension}");

            MYSLog.GetLog("Getting file info", file.Name, file.FullName, DateTime.Now.ToString());
        }

        public static void GetCreationTime(string path)
        {
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"\nFile name: {file.Name}");
            Console.WriteLine($"Creation time of file: {file.CreationTime}");

            MYSLog.GetLog("Getting creating time of file", file.Name, file.FullName, DateTime.Now.ToString());
        }
    }
}
