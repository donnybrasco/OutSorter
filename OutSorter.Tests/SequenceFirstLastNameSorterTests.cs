using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace OutSorter.Tests
{
    [TestClass]
    public class SequenceFirstLastNameSorterTests
    {
        #region Test Initiailize

        private IEnumerable<Record> _records;

        [TestInitialize]
        public void TestInitialize()
        {
            _records = new List<Record>
            {
                new Record {FirstName = "Tom", LastName = "Smith"},
                new Record {FirstName = "Harry", LastName = "Beans"},
                new Record {FirstName = "Nate", LastName = "Tom"},
                new Record {FirstName = "Harry", LastName = "Potter"},
                new Record {FirstName = "Carl", LastName = "Tom"},
            };
        }
        #endregion

        #region Test Cleanup

        [TestCleanup]
        public void TestCleanup()
        {
            _records = null;
        }

        #endregion
        
        #region Tests

        [TestMethod]
        public void Construct_ShouldBeTypeISorter()
        {
            //----Setup---------------------------------------------
            //----Execute-------------------------------------------
            var sorter = new SequenceFirstLastNameSorter(GetFileWriter());
            //----Assert--------------------------------------------
            Assert.IsInstanceOfType(sorter, typeof(ISorter));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Construct_GivenNullWriter_ShouldThrowArgumentNullException()
        {
            //----Setup---------------------------------------------
            //----Execute-------------------------------------------
            ISorter sorter = new SequenceFirstLastNameSorter(null);
            //----Assert--------------------------------------------
            Assert.Fail("Expected Exception Not Thrown!");
        }
        [TestMethod]
        public void PerformSort_GivenCustomerRecords_ShouldSortBySequence()
        {
            //----Setup---------------------------------------------
            ISorter sorter = new SequenceFirstLastNameSorter(GetFileWriter());
            //----Execute-------------------------------------------
            var sortedList = sorter.PerformSort(_records);
            //----Assert--------------------------------------------
            Assert.IsTrue(sortedList.First() == "Tom, 3");
        }

        #endregion

        #region Factory Methods
        private IFileWriter GetFileWriter()
        {
            var fileWriter = new Mock<IFileWriter>();
            return fileWriter.Object;
        }

        #endregion

    }
}
