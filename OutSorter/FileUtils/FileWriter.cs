using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OutSorter
{
    public class FileWriter
        : IFileWriter
    {
        public void Write(IEnumerable<dynamic> inputRecords, Func<dynamic, string> formatString, string fileOutputPath)
        {
            using (StreamWriter sw = new StreamWriter(fileOutputPath))
            {
                inputRecords.ToList().ForEach(p => { sw.WriteLine(formatString(p)); });
            }
            System.Diagnostics.Process.Start(fileOutputPath);
        }
    }
}