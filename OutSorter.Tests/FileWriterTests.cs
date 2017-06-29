using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OutSorter.Tests
{
    [TestClass]
    public class FileWriterTests
    {
        [TestMethod]
        public void Construct_ShouldBeTypeIFileWriter()
        {
            //----Setup---------------------------------------------
            //----Execute-------------------------------------------
            var sorter = new FileWriter();
            //----Assert--------------------------------------------
            Assert.IsInstanceOfType(sorter, typeof(IFileWriter));
        }
    }
}
