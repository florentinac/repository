using FileOperation;

namespace FileCopyApplication
{
    using System;

    class Program
    {
        private static void Main(string[] args)
        {
            var fileCopy = new FileCopy(@"C:\Test\xxx.txt", @"C:\Destination");
            try
            {
                fileCopy.SimpleFileCopy();
                fileCopy.CopyAllFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var allFileCopy = new FileCopy(@"C:\Test3", @"C:\Destination");

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
            
            var copyDirectory = new CopyDirectory(@"C:\Test2", @"C:\Destination");             
            copyDirectory.CopyDirectoryEasier();

            CopyDirectory.CopyDir(@"C:\Test2", @"C:\Dest");


        }
    }
}
