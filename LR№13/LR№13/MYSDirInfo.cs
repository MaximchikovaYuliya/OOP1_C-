using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LR_13
{
    static class MYSDirInfo
    {
        public static void GetFilesCount(string dirName)
        {
            string[] files = Directory.GetFiles(dirName);

            if(Directory.Exists(dirName))
            {
                Console.WriteLine($"\nDirectory name: {dirName}");
                Console.WriteLine($"Count of files: {files.Length}");

                MYSLog.GetLog("Getting count of files in input directory", dirName, Directory.GetParent(dirName).ToString(), DateTime.Now.ToString());
            }
        }

        public static void DirCreationTime(string dirName)
        {
            if(Directory.Exists(dirName))
            {
                Console.WriteLine($"\nDirectory name: {dirName}");
                Console.WriteLine($"Directory creation time: {Directory.GetCreationTime(dirName)}");

                MYSLog.GetLog("Getting creation time of files in input directory", dirName, Directory.GetParent(dirName).ToString(), DateTime.Now.ToString());
            }
        }

        public static void GetSubDirCount(string dirName)
        {
            string[] subDirs = Directory.GetDirectories(dirName);
            if (Directory.Exists(dirName))
            {
                Console.WriteLine($"\nDirectory name: {dirName}");
                Console.WriteLine($"Count of subdirectories: {subDirs.Length}");

                MYSLog.GetLog("Getting count of subdirectories in input directory", dirName, Directory.GetParent(dirName).ToString(), DateTime.Now.ToString());
            }
        }

        public static void GetParentDir(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Console.WriteLine($"\nDirectory name: {dirName}");
                Console.WriteLine($"Directory parent: {Directory.GetParent(dirName)}");

                MYSLog.GetLog("Getting parent of input directory", dirName, Directory.GetParent(dirName).ToString(), DateTime.Now.ToString());
            }
        }
    }
}
