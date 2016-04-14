using System;
using System.IO;

namespace FileOperation
{
    public class FileCopy
    {
        private string fileName;
        protected string sourcePath;
        protected string destinationFilePath;

        public FileCopy(string sourcePath, string destinationFilePath)
        {
            this.sourcePath = sourcePath;
            this.destinationFilePath = destinationFilePath;
            InitialDestinationDirectory();
        }

        public void SimpleFileCopy()
        {
            GetFileName();
            File.Copy(sourcePath, Path.Combine(destinationFilePath, fileName), true);
        }

        public void CopyAllFiles()
        {
            if (IsDirectory())
            {
                var files = Directory.GetFiles(sourcePath);
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
            var file = new FileInfo(sourcePath);
            file.CopyTo(Path.Combine(destinationFilePath, fileName), true);
        }

        public void CopyFileUsingStream()
        {
            GetFileName();

            var fileContent = GetFileContent();
            WriteContent(fileContent);
        }

        protected void InitialDestinationDirectory()
        {
            Directory.CreateDirectory(destinationFilePath);
        }

        private void GetFileName()
        {
            if (File.Exists(sourcePath))
            {
                fileName = Path.GetFileName(sourcePath);
            }
            else
            {
                throw new Exception("Source file does not exist!");
            }
        }

        private bool IsDirectory()
        {
            var result = false;

            if (!File.Exists(sourcePath) && !Directory.Exists(sourcePath)) return false;

            var attr = File.GetAttributes(sourcePath);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                result = true;

            return result;
        }

        private string GetFileContent()
        {
            string fileContent;
            using (var reader = new StreamReader(sourcePath))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }

        private void WriteContent(string fileContent)
        {
            using (var fileStream = File.Create(Path.Combine(destinationFilePath, fileName)))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(fileContent);
            }
        }      
    }
}
