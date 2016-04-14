using System;
using System.IO;

namespace FileOperation
{
    public class CopyDirectory : FileCopy
    {
        public CopyDirectory(string sourceDirectory, string destDirectory) : base(sourceDirectory, destDirectory)
        {
        }

        public void CopyDirRecursiv()
        {
            CopyAllFiles();

            var dirs = Directory.GetDirectories(sourcePath);
            foreach (var dir in dirs)
            {
                destinationFilePath = Path.Combine(destinationFilePath, Path.GetFileName(dir));
                sourcePath = dir;
                InitialDestinationDirectory();
                CopyDirRecursiv();
            }
        }

        public static void CopyDir(string srcDirectory, string destDirectory)
        {
            if (!Directory.Exists(srcDirectory))
            {
                throw new Exception("The source directory does not exists");
            }

            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }

            var directory = new DirectoryInfo(srcDirectory);

            var files = directory.GetFiles();
            foreach (var file in files)
            {
                File.Copy(file.FullName, Path.Combine(destDirectory, Path.GetFileName(file.Name)), true);
            }

            var dirs = directory.GetDirectories();
            foreach (var dir in dirs)
            {
                var temppath = Path.Combine(destDirectory, dir.Name);
                CopyDir(dir.FullName, temppath);
            }
        }

        public void CopyDirectoryEasier()
        {
            if (!Directory.Exists(sourcePath))
            {
                throw new Exception("The source directory does not exists");
            }

            var dirs = Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories);
            foreach (var dirPath in dirs)
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationFilePath));
            }

            var files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                File.Copy(file, file.Replace(sourcePath, destinationFilePath), true);
            }
        }
    }
}
