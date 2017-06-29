using System.Collections.Generic;
using System.Linq;

namespace OutSorter
{
    public interface ISorter
    {
        IEnumerable<string> PerformSort(IEnumerable<Record> records);
    }
}