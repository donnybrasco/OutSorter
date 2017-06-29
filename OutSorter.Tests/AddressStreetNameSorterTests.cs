using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace OutSorter.Tests
{
    [TestClass]
    public class AddressStreetNameSorterTests
    {
        #region Test Initiailize

        private IEnumerable<Record> _records;

        [TestInitialize]
        public void TestInitialize()
        {
            _records = new List<Record>
            {
                new Record {Address = "55 Edward St"},
                new Record {Address = "44 Duncan Rd"},
                new Record {Address = "33 Cathy Ave"},
                new Record {Address = "221 Apple St"},
                new Record {Address = "153 Becky Cir"},
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
            var sorter = new AddressStreetNameSorter(GetFileWriter());
            //----Assert--------------------------------------------
            Assert.IsInstanceOfType(sorter, typeof(ISorter));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Construct_GivenNullWriter_ShouldThrowArgumentNullException()
        {
            //----Setup---------------------------------------------
            //----Execute-------------------------------------------
            ISorter sorter = new AddressStreetNameSorter(null);
            //----Assert--------------------------------------------
            Assert.Fail("Expected Exception Not Thrown!");
        }
        [TestMethod]
        public void PerformSort_GivenCustomerRecords_ShouldSortByStreetName()
        {
            //----Setup---------------------------------------------
            ISorter sorter = new AddressStreetNameSorter(GetFileWriter());
            //----Execute-------------------------------------------
            var sortedList = sorter.PerformSort(_records);
            //----Assert--------------------------------------------
            Assert.IsTrue(sortedList.First() == "221 Apple St");
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
