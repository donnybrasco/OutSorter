using System.Collections.Generic;

namespace OutSorter
{
    public interface IFileLoader
    {
        List<Record> Load(string filePath, bool isFirstRowHeader = true);
    }
}