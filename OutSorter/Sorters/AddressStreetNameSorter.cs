using System;
using System.Collections.Generic;
using System.Linq;

namespace OutSorter
{
    public class AddressStreetNameSorter
        : ISorter
    {
        private readonly IFileWriter _writer;

        public AddressStreetNameSorter(IFileWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            _writer = writer;
        }

        public IEnumerable<string> PerformSort(IEnumerable<Record> records)
        {
            IEnumerable<string> listOfAddresses = records.Select(p => p.Address);

            //Sort Addresses by Street Name
            IOrderedEnumerable<string> sortedAddresses = listOfAddresses.OrderBy(s => s.Split(' ')[1]);

            _writer.Write(sortedAddresses, address => $"{address}", @"Result_2.txt");

            return sortedAddresses;
        }
    }
}