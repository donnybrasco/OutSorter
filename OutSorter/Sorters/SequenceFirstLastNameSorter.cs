using System;
using System.Collections.Generic;
using System.Linq;

namespace OutSorter
{
    public class SequenceFirstLastNameSorter
        : ISorter
    {
        private readonly IFileWriter _writer;

        public SequenceFirstLastNameSorter(IFileWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            _writer = writer;
        }

        public IEnumerable<string> PerformSort(IEnumerable<Record> records)
        {
            var col = records as IList<Record> ?? records.ToList();
            IEnumerable<string> listOfAllNames = col.Select(p => p.FirstName).Concat(col.Select(p => p.LastName));

            //Group Names and get Count
            IEnumerable<string> groupListOfCustomers = listOfAllNames.GroupBy(info => info)
                                                            .Select(group => new
                                                            {
                                                                Name = group.Key,
                                                                Count = group.Count()
                                                            })
                                                            .OrderByDescending(x => x.Count)
                                                            .ThenBy(y => y.Name)
                                                            .Select(obj=> $"{obj.Name}, {obj.Count}")
                                                            .ToList();

            _writer.Write(groupListOfCustomers, obj => $"{obj}", @"Result_1.txt");

            return groupListOfCustomers;
        }
    }
}