using System;
using System.Collections.Generic;

namespace OutSorter
{
    public interface IFileWriter
    {
        void Write(IEnumerable<dynamic> inputRecords, Func<dynamic, string> formatString, string fileOutputPath);
    }
}