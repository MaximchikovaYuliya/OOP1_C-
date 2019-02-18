using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace LR_13
{
    static class MYSFileManager
    {
        public static void FilesAndCatalogs(string diskName)
        {
            string[] files = Directory.GetFiles(diskName);
            string[] catalogs = Directory.GetDirectories(diskName);
            Directory.CreateDirectory(@"D:\3_semestr\OOTP\LR№13\MYSInspect");
            MYSLog.GetLog("Creating new directory", "MYSInspect", @"D:\3_semestr\OOTP\LR№13\MYSInspect", DateTime.Now.ToString());

            StreamWriter file = File.CreateText(@"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt");
            MYSLog.GetLog("Creating new file", "MYSDirInfo.txt", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt", DateTime.Now.ToString());

            file.WriteLine($"   Files in {diskName} ");
            foreach(var x in files)
            {
                file.WriteLine(x);
            }

            file.WriteLine($"   Catalogs in {diskName} ");
            foreach (var x in catalogs)
            {
                file.WriteLine(x);
            }

            MYSLog.GetLog("Writing in file", "MYSDirInfo.txt", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt", DateTime.Now.ToString());
            file.Close();

            File.Copy(@"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfoCopy.txt", true);
            MYSLog.GetLog("Copying file", "MYSDirInfo.txt", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt", DateTime.Now.ToString());

            File.Delete(@"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt");
            MYSLog.GetLog("Deleting new file", "MYSDirInfo.txt", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSDirInfo.txt", DateTime.Now.ToString());
        }

        public static void FilesExtensions(string dirName, string extension)
        {
            DirectoryInfo dir = Directory.CreateDirectory(@"D:\3_semestr\OOTP\LR№13\MYSFiles");
            MYSLog.GetLog("Creating new directory", dir.Name, dir.FullName, DateTime.Now.ToString());

            DirectoryInfo source = new DirectoryInfo(dirName);
            MYSLog.GetLog("Creating new directory", source.Name, source.FullName, DateTime.Now.ToString());

            foreach (var x in source.GetFiles($"*{extension}", SearchOption.TopDirectoryOnly))
            {
                x.CopyTo(@"D:\3_semestr\OOTP\LR№13\MYSFiles\" + x.Name, true);
                MYSLog.GetLog("Copying file", x.Name, @"D:\3_semestr\OOTP\LR№13\MYSFiles\" + x.Name, DateTime.Now.ToString());
            }

            if (!Directory.Exists(@"D:\3_semestr\OOTP\LR№13\MYSInspect"))
            {
                Directory.CreateDirectory(@"D:\3_semestr\OOTP\LR№13\MYSInspect");
                MYSLog.GetLog("Creating directory", "MYSInspect", @"D:\3_semestr\OOTP\LR№13\MYSInspect", DateTime.Now.ToString());
            }

            Directory.CreateDirectory(@"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSFiles");
            MYSLog.GetLog("Creating directory", "MYSFiles", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSFiles", DateTime.Now.ToString());

            foreach (var x in dir.GetFiles())
            {
                x.CopyTo(@"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSFiles\" + x.Name, true);
                MYSLog.GetLog("Copying file", x.Name, @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSFiles\" + x.Name, DateTime.Now.ToString());
            }

            dir.Delete(true);
            MYSLog.GetLog("Deleting directory", dir.Name, dir.FullName, DateTime.Now.ToString());
        }

        public static void CreateArchiveAndExtract()
        {
            if (File.Exists(@"D:\3_semestr\OOTP\LR№13\Archive.zip"))
            {
                File.Delete(@"D:\3_semestr\OOTP\LR№13\Archive.zip");
                MYSLog.GetLog("Deleting file", "Archive.zip", @"D:\3_semestr\OOTP\LR№13\Archive.zip", DateTime.Now.ToString());
            }

            ZipFile.CreateFromDirectory(@"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSFiles\", @"D:\3_semestr\OOTP\LR№13\Archive.zip");
            MYSLog.GetLog("Zipping directory", "MYSFiles", @"D:\3_semestr\OOTP\LR№13\MYSInspect\MYSFiles\", DateTime.Now.ToString());

            DirectoryInfo dir = new DirectoryInfo(@"D:\3_semestr\OOTP\LR№13\MYSInspect\ZipArchive");
            MYSLog.GetLog("Creating new directory", dir.Name, dir.FullName, DateTime.Now.ToString());
            if (dir.Exists)
            {
                dir.Delete(true);
                MYSLog.GetLog("Deleting directory", dir.Name, dir.FullName, DateTime.Now.ToString());
            }

            ZipFile.ExtractToDirectory(@"D:\3_semestr\OOTP\LR№13\Archive.zip", @"D:\3_semestr\OOTP\LR№13\MYSInspect\ZipArchive");
            MYSLog.GetLog("Extracting files", "Archive.zip", @"D:\3_semestr\OOTP\LR№13\Archive.zip", DateTime.Now.ToString());
        }

    }
}
