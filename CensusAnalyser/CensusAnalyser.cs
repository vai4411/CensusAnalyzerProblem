using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser : ICSVBuilder
    {
        public delegate int totalRecords();
        public string path;
        public string header;
        List<string> censusList = new List<string>();
        Dictionary<string, string> map = new Dictionary<string,string>();

        public CensusAnalyser(string path, string header)
        {
            this.path = path;
            this.header = header;
        }

        public int getCount()
        {
            if (!File.Exists(path))
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            string[] data = File.ReadAllLines(path);
            
            map = data.ToDictionary(key => key, value => value);
            if (map.ElementAt(0).Value != header)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER);
            foreach (string record in map.Values)
            {
                if (record.Split(',').Length != header.Split(',').Length)
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
            }
            return map.Count - 1;
        }

        public string SortStatePopulationWise(string column)
        {
            getCount();
            string[] demo = header.Split(',');
            int index = Array.IndexOf(demo, column);
            var data = map.Values.Skip(1);
            IEnumerable<string> sort =
            from entry in data
            let feild = entry.Split(',')
            orderby feild[index]
            select entry;
            censusList = sort.ToList<string>();
            return JsonConvert.SerializeObject(censusList);
        }
    }
}
