using System;
using System.Collections.Generic;
using System.Linq;

namespace OutSorter
{
    public class SortManager
        : ISortManager
    {
        private readonly IFileWriter _writer;

        #region Ctor

        public SortManager(IFileWriter writer)
        {
            _writer = writer;
        }

        #endregion

        #region ISortManager Members

        public void Sort(IEnumerable<Record> records)
        {
            if (records == null) throw new ArgumentNullException(nameof(records));
            Sorters.ToList().ForEach(p => p.PerformSort(records));
        }

        #endregion
        
        #region Registered Sorters

        public IEnumerable<ISorter> Sorters => new List<ISorter>
        {
            new SequenceFirstLastNameSorter(_writer),
            new AddressStreetNameSorter(_writer)
        };

        #endregion

    }
}