using System;
using System.Configuration;

namespace ReadCSV
{
    public class ConfigMapper
    {
        public static string sourceFileLocation => String("filename");

        private static string String(string v)
        {
            string stringValue;
            try{
                stringValue = ConfigurationManager.AppSettings[v];
            }
            
            catch{
                throw new NotImplementedException();
            }
            return stringValue;
        }
    }
}
