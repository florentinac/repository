using FileOperation;

namespace FileCopyApplication
{
    using System;

    class Program
    {
        private static void Main(string[] args)
        {
            var fileCopy = new CopierFiles(@"C:\Test\xxx.txt", @"C:\Destination");
            try
            {
                fileCopy.SimpleFileCopy();
                fileCopy.CopyAllFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var allFileCopy = new CopierFiles(@"C:\Test3", @"C:\Destination");

            try
            {
                allFileCopy.CopyAllFiles();
                fileCopy.CopyFileUsingFileInfo();
                fileCopy.CopyFileUsingStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            var copyDirectory = new CopierDirectory(@"C:\Test2", @"C:\Destination");
            copyDirectory.CopyDirectoryRecursiv();
            copyDirectory.CopyDirectoryEasier();

            copyDirectory.CopyDirectory(@"C:\Test2", @"C:\Dest");
                     
        }
    }
}
