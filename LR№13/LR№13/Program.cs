using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LR_13
{
    class Program
    {
        static void Main(string[] args)
        {
            MYSDiskInfo.GetDiskInfo(@"D:\");
            MYSDiskInfo.GetFileSystem(@"C:\");
            MYSDiskInfo.GetFreeDiskSpace(@"C:\");

            MYSFileInfo.GetCreationTime(@"D:\3_semestr\OOTP\LR№13\file.txt");
            MYSFileInfo.GetFileInfo(@"D:\3_semestr\OOTP\LR№13\file.txt");
            MYSFileInfo.GetFullPath(@"D:\3_semestr\OOTP\LR№13\file.txt");

            MYSDirInfo.DirCreationTime(@"D:\3_semestr");
            MYSDirInfo.GetFilesCount(@"D:\3_semestr");
            MYSDirInfo.GetParentDir(@"D:\3_semestr");
            MYSDirInfo.GetSubDirCount(@"D:\3_semestr");

            MYSFileManager.FilesAndCatalogs(@"D:\");
            MYSFileManager.FilesExtensions(@"D:\3_semestr", ".pdf");
            MYSFileManager.CreateArchiveAndExtract();

            MYSLog.Search("28.11.2018");
            MYSLog.Search("Copying file");
            Console.WriteLine($"\nCount of records: {MYSLog.GetCount()}");
            MYSLog.LeaveForCurrentHour();
            Console.WriteLine($"\nCount of records: {MYSLog.GetCount()}");

            Console.ReadKey();
        }
    }
}
