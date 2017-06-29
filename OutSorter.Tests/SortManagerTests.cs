using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace OutSorter.Tests
{
    [TestClass]
    public class SortManagerTests
    {
        [TestMethod]
        public void Construct_ShouldReturnInstanceOfISortManager()
        {
            //-----Setup------------------------------------
            //-----Execute----------------------------------
            var manager = new SortManager(null);
            //-----Assert-----------------------------------
            Assert.IsInstanceOfType(manager, typeof(ISortManager));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_Given_NullCustomerRecords_ShouldThrowArgumentNullException()
        {
            //-----Setup------------------------------------
            ISortManager manager = new SortManager(null);
            //-----Execute----------------------------------
            manager.Sort(null);
            //-----Assert-----------------------------------
            Assert.Fail("Expected Exception not thrown!");
        }
        [TestMethod]
        public void Sorters_ShouldReturnRegisteredSorters()
        {
            //-----Setup------------------------------------
            ISortManager manager = new SortManager(GetFileWriter());
            //-----Execute----------------------------------
            var sorters = manager.Sorters;
            //-----Assert-----------------------------------
            Assert.IsTrue(sorters.Any());
        }

        #region Factory Methods

        private IFileWriter GetFileWriter()
        {
            var mock = new Mock<IFileWriter>();
            return mock.Object;
        }

        #endregion
    }
}
