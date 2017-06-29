using System;
using System.Collections.Generic;
using System.IO;

namespace OutSorter
{
    public class CsvFileLoader
        : IFileLoader
    {
        public List<Record> Load(string filePath, bool isFirstRowHeader = true)
        {
            if(filePath==null) throw new ArgumentNullException(nameof(filePath));

            if(!System.IO.File.Exists(filePath)) throw new FileNotFoundException(filePath);

            var records = new List<Record>();
            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            {
                if (isFirstRowHeader) reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var values = line?.Split(',');

                    records.Add(new Record
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        Address = values[2],
                        Phone = values[3]
                    });
                }
            }

            return records;
        }
    }
}