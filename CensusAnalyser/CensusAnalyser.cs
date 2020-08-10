using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser:ICSVBuilder
    {
        public delegate int totalRecords();
        public string path;
        public string header;
        List<string> list = new List<string>();

        public CensusAnalyser(string path,string header)
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
            list = data.ToList<string>();
            if (list[0] != header)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER);
            foreach (string record in list)
            {
                if (record.Split(',').Length != header.Split(',').Length)
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
            }
            return list.Count - 1;
        }

        public string SortStatePopulationWise(string feild)
        {
            getCount();
            DataSort(feild);
            string sortedString = JsonConvert.SerializeObject(list);
            return sortedString;
        }


        void DataSort(string feild)
        {
            string[] demo = header.Split(',');
            int index = Array.IndexOf(demo, feild);
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count - 1; j++)
                {
                    string census1 = list.ElementAt(j);
                    string census2 = list.ElementAt(j + 1);
                    string[] census3 = census1.Split(',');
                    string[] census4 = census2.Split(',');
                    if (census3[index].CompareTo(census4[index]) > 0)
                    {
                        list[j] = census2;
                        list[j + 1] = census1;
                    }
                }
            }
        }

    }
}
