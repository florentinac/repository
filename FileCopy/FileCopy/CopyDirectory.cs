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

            var dirs = Directory.GetDirectories(this.sourcePath);
            foreach (var dir in dirs)
            {
                this.destinationFilePath = Path.Combine(this.destinationFilePath, Path.GetFileName(dir));
                this.sourcePath = dir;
                InitialDestinationDirectory();
                CopyDirRecursiv();
            }
        }

        public void CopyDir(string srcDirectory, string destDirectory)
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
            if (!Directory.Exists(this.sourcePath))
            {
                throw new Exception("The source directory does not exists");
            }
            var directory = new DirectoryInfo(this.sourcePath);
            Directory.CreateDirectory(this.sourcePath.Replace(directory.Parent.FullName, this.destinationFilePath));

            var dirs = Directory.GetDirectories(this.sourcePath, "*", SearchOption.AllDirectories);
            foreach (var dirPath in dirs)
            {
                Directory.CreateDirectory(dirPath.Replace(directory.Parent.FullName, this.destinationFilePath));
            }

            var files = Directory.GetFiles(this.sourcePath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                File.Copy(file, file.Replace(directory.Parent.FullName, this.destinationFilePath), true);
            }
        }
    }
}
