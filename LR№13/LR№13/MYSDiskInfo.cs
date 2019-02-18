using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LR_13
{
    static class MYSDiskInfo
    {
        public static void GetFreeDiskSpace(string diskName)
        {
            DriveInfo disk = new DriveInfo(diskName);
            Console.WriteLine($"\nDisk name: {disk.Name}");
            Console.WriteLine($"Free disk space: {disk.AvailableFreeSpace}");

            MYSLog.GetLog("Getting free disk space", diskName, disk.RootDirectory.ToString(), DateTime.Now.ToString());
        }

        public static void GetFileSystem(string diskName)
        {
            DriveInfo disk = new DriveInfo(diskName);
            Console.WriteLine($"\nDisk name: {disk.Name}");
            Console.WriteLine($"File system: {disk.AvailableFreeSpace}");

            MYSLog.GetLog("Getting file system of disk", diskName, disk.RootDirectory.ToString(), DateTime.Now.ToString());
        }

        public static void GetDiskInfo(string diskName)
        {
            DriveInfo disk = new DriveInfo(diskName);
            Console.WriteLine($"\nDisk name: {disk.Name}");
            Console.WriteLine($"Total size: {disk.TotalSize}");
            Console.WriteLine($"Free disk space: {disk.AvailableFreeSpace}");
            Console.WriteLine($"Root directory: {disk.RootDirectory}");

            MYSLog.GetLog("Getting disk info", diskName, disk.RootDirectory.ToString(), DateTime.Now.ToString());
        }
    }
}
