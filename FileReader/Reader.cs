using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;

namespace ReadCSV.FileReader
{
    public class Reader : IReader
    {
        private ILogger _logger;
        private string _path = ConfigMapper.sourceFileLocation;
        private List<DataModel> _DataField;
        
        public Reader(ILogger logger) // passing the same logger instance from the registered
        {
            _logger = logger;
        }

        public IList<DataModel> ReadData()
        {
            try
            {
                string rawData = System.IO.File.ReadAllText(_path);
                _logger.Information("Reading file from {0}", _path);
                _logger.Information("Total character received: {0}", rawData.Length);

                _DataField = JsonConvert.DeserializeObject<List<DataModel>>(rawData);
            }
            catch (Exception e)
            {
                _logger.Error("File not found.");
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return _DataField;
        }
    }
}