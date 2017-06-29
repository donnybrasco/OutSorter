using System.Collections.Generic;

namespace OutSorter
{
    public interface ISortManager
    {
        void Sort(IEnumerable<Record> records);
        IEnumerable<ISorter> Sorters { get; }
    }
}