using System.Collections.Generic;

namespace ReadCSV.FileReader
{
    public interface IReader
    {
        IList<DataModel> ReadData();
    }
}
