using System;
using System.IO;

namespace FileOperation
{
    public class CopierFiles
    {
        private string fileName;
        protected string sourcePath;
        protected string destinationFilePath;

        public CopierFiles(string sourcePath, string destinationFilePath)
        {
            this.sourcePath = sourcePath;
            this.destinationFilePath = destinationFilePath;
            this.InitialDestinationDirectory();
        }

        public void SimpleFileCopy()
        {
            GetFileName();
            File.Copy(sourcePath, Path.Combine(this.destinationFilePath, this.fileName), true);
        }

        public void CopyAllFiles()
        {
            if (IsDirectory())
            {
                var files = Directory.GetFiles(this.sourcePath);
                foreach (var file in files)
                {
                    File.Copy(file, Path.Combine(destinationFilePath, Path.GetFileName(file)), true);
                }
            }
            else
            {
                throw new Exception("The source file is not a directory");
            }
        }

        public void CopyFileUsingFileInfo()
        {
            GetFileName();
            var file = new FileInfo(this.sourcePath);
            file.CopyTo(Path.Combine(this.destinationFilePath, this.fileName), true);
        }

        public void CopyFileUsingStream()
        {
            GetFileName();

            var fileContent = GetFileContent();
            WriteContent(fileContent);
        }

        protected void InitialDestinationDirectory()
        {
            Directory.CreateDirectory(this.destinationFilePath);
        }

        private void GetFileName()
        {
            if (File.Exists(this.sourcePath))
            {
                fileName = Path.GetFileName(this.sourcePath);
            }
            else
            {
                throw new Exception("Source file does not exist!");
            }
        }

        private bool IsDirectory()
        {
            var result = false;

            if (!File.Exists(this.sourcePath) && !Directory.Exists(this.sourcePath)) return false;

            var attr = File.GetAttributes(this.sourcePath);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                result = true;

            return result;
        }

        private string GetFileContent()
        {
            string fileContent;
            using (var reader = new StreamReader(this.sourcePath))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }

        private void WriteContent(string fileContent)
        {
            using (var fileStream = File.Create(Path.Combine(this.destinationFilePath, this.fileName)))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(fileContent);
            }
        }      
    }
}
