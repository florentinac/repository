using System;
using FileOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace File.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SingleFileCopy()
        {
            var fileOperation = new CopierFiles(@"C:\Test\test.txt", @"C:\Destination");
            fileOperation.SimpleFileCopy();
            Assert.IsTrue(System.IO.File.Exists(@"C:\Destination\test.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Source file does not exists!")]
        public void WhenTryToCopyANonExistentFileSouldThrownAnException()
        {
            var fileOperation = new CopierFiles(@"C:\Test\text.txt", @"C:\Destination");
            fileOperation.SimpleFileCopy();
        }

        [TestMethod]
        public void CopyFileWithoutExtension()
        {
            var fileOperator = new CopierFiles(@"C:\Test\bbb", @"D:\Destination");
            fileOperator.CopyFileUsingFileInfo();
            Assert.IsTrue(System.IO.File.Exists(@"D:\Destination\bbb"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Source file does not exists!")]
        public void TryToCopyFileWhenThwSourceIsADirectoryInsteadOfFile()
        {
            var fileOperator = new CopierFiles(@"C:\Test\New", @"D:\Destination");
            fileOperator.CopyFileUsingFileInfo();           
        }

        [TestMethod]
        public void CopyFileUsingStreamReadAndWrite()
        {
            var fileOperator = new CopierFiles(@"C:\Test\ceva.txt", @"D:\Destination");
            fileOperator.CopyFileUsingStream();
            Assert.IsTrue(System.IO.File.Exists(@"D:\Destination\ceva.txt"));
        }

        [TestMethod]
        public void CopyAllFileFromADirectory()
        {
            var fileOperator = new CopierFiles(@"C:\Test\New", @"D:\Destination");
            fileOperator.CopyAllFiles();
            Assert.IsTrue(System.IO.File.Exists(@"D:\Destination\aaa.txt"));
            Assert.IsTrue(System.IO.File.Exists(@"D:\Destination\test.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "The source file is not a directory")]
        public void TryCopyAllFileWhenTheSourcePathIsAFile()
        {
            var fileOperator = new CopierFiles(@"C:\Test\test.txt", @"D:\Destination");
            fileOperator.CopyAllFiles();  
        }

        [TestMethod]
        public void CopyDirectory()
        {
            var directoryOperator = new CopierDirectory(@"C:\Test\New", @"D:\Destination");
            directoryOperator.CopyDirectoryEasier();
            Assert.IsTrue(System.IO.Directory.Exists(@"D:\Destination\New"));
        }

        [TestMethod]
        public void CopyADirectoryWithExtension()
        {
            var directoryOperator = new CopierDirectory(@"C:\Test\A.txt", @"D:\Destination");
            directoryOperator.CopyDirectoryEasier();
            Assert.IsTrue(System.IO.Directory.Exists(@"D:\Destination\A.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "The source file is not a directory")]
        public void CopyANonExistentDirectory()
        {
            var directoryOperator = new CopierDirectory(@"C:\Test\Abc", @"D:\Destination");
            directoryOperator.CopyDirectoryEasier();           
        }


    }
}
