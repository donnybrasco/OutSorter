using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OutSorter.Tests
{
    [TestClass]
    public class CsvLoaderTests
    {
        [TestMethod]
        public void Construct_ShouldReturnType_IFileLoader()
        {
            //---Setup-------------------------------
            //---Execute-----------------------------
            var fileLoader = new CsvFileLoader();
            //---Assert------------------------------
            Assert.IsInstanceOfType(fileLoader, typeof(IFileLoader));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Load_Given_NoFilePath_ShouldThrowArgumentNullException()
        {
            //---Setup-------------------------------
            IFileLoader fileLoader = new CsvFileLoader();
            string filePath = null;
            //---Execute-----------------------------
            fileLoader.Load(filePath);
            //---Assert------------------------------
            Assert.Fail("Expected Exception not thrown!");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Load_Given_NoInvalidFilePath_ShouldThrowFileNotFoundException()
        {
            //---Setup-------------------------------
            IFileLoader fileLoader = new CsvFileLoader();
            string filePath = @"C:\SomeLocationSomeWhereInNeverLand\SomeFile.ext";
            //---Execute-----------------------------
            fileLoader.Load(filePath);
            //---Assert------------------------------
            Assert.Fail("Expected Exception not thrown!");
        }

        [TestMethod]
        public void Load_Given_ValidFilePath_ShouldReturnRecords()
        {
            //---Setup-------------------------------
            IFileLoader fileLoader = new CsvFileLoader();
            string filePath = @"data.csv";
            //---Execute-----------------------------
            var records = fileLoader.Load(filePath);
            //---Assert------------------------------
            Assert.IsTrue(records.Count > 0);
        }
    }
}
