using System;
using System.IO;
using FileOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace File.test
{
    [Binding]
    public class CopyFileOperationSteps
    {
        private string source;
        private FileCopy file;

        [Given(@"""(.*)"" file")]
        public void GivenFile(string source)
        {
            this.source = source;
        }
        
        [Given(@"""(.*)"" the source folder")]
        public void GivenTheSourceFolder(string source)
        {
            this.source = source;
        }
        
        [When(@"I copy in to ""(.*)"" folder")]
        public void WhenICopyInToFolder(string dest)
        {
            this.file = new FileCopy(source, dest);
            this.file.SimpleFileCopy();
        }
        
        [When(@"I copy all the file in to ""(.*)"" folder")]
        public void WhenICopyAllTheFileInToFolder(string dest)
        {
            this.file = new FileCopy(source, dest);
            this.file.CopyAllFiles();
        }
        
        [Then(@"the file ""(.*)"" is copied in ""(.*)"" folder")]
        public void ThenTheFileIsCopiedInFolder(string fileName, string dest)
        {
            Assert.IsTrue(System.IO.File.Exists(Path.Combine(dest, fileName)));
        }
        
        [Then(@"the files ""(.*)"" and ""(.*)"" are copied in ""(.*)"" folder")]
        public void ThenTheFilesAndAreCopiedInFolder(string fileName1, string fileName2, string dest)
        {
            Assert.IsTrue(System.IO.File.Exists(Path.Combine(dest, fileName1)));
            Assert.IsTrue(System.IO.File.Exists(Path.Combine(dest, fileName2)));
        }
    }
}
