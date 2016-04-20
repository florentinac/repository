using System;
using System.IO;

namespace FileOperation
{
    public class CopierDirectory : CopierFiles
    {
        public CopierDirectory(string sourceDirectory, string destDirectory) : base(sourceDirectory, destDirectory)
        {
        }

        public void CopyDirectoryRecursiv()
        {
            
            CopyAllFiles();

            var dirs = Directory.GetDirectories(this.sourcePath);
            foreach (var dir in dirs)
            {
                this.destinationFilePath = Path.Combine(this.destinationFilePath, Path.GetFileName(dir));
                this.sourcePath = dir;  
                      
                InitialDestinationDirectory();
                CopyDirectoryRecursiv();
                this.destinationFilePath = Path.GetDirectoryName(this.destinationFilePath);
            }
        }

        public void CopyDirectory(string source, string destination)
        {
            if (!Directory.Exists(source))
            {
                throw new Exception("The source directory does not exists");
            }

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            var directory = new DirectoryInfo(source);

            var files = directory.GetFiles();
            foreach (var file in files)
            {
                File.Copy(file.FullName, Path.Combine(destination, Path.GetFileName(file.Name)), true);
            }

            var dirs = directory.GetDirectories();
            foreach (var dir in dirs)
            {
                var temppath = Path.Combine(destination, dir.Name);
                CopyDirectory(dir.FullName, temppath);
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
