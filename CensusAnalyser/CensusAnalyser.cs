using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser : ICSVBuilder
    {
        private static readonly string CENSUS_HEADER = "State,Population,AreaInSqKm,DensityPerSqKm";
        private static readonly string STATE_CODE_HEADER = "SrNo,State Name,TIN,StateCode";
        private static readonly string JSON_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/CensusData.json";
        public delegate int totalRecords();
        public string path;
        public string header;
        List<CensusDTO> censusList = new List<CensusDTO>();
        List<CensusDTO> sortedLists = new List<CensusDTO>();
        Dictionary<string, CensusDTO> map = new Dictionary<string, CensusDTO>();

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
            if (data.ElementAt(0) != header)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER);
            foreach (string record in data.Skip(1))
            {
                string[] entries = record.Split(',');
                if (record.Split(',').Length != header.Split(',').Length)
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DELIMITER);

                if (header.Equals(CENSUS_HEADER))
                    map.Add(entries[0], new CensusDTO(new IndiaCensusCSV(entries[0], entries[1], entries[2], entries[3])));
                else
                    if (header.Equals(STATE_CODE_HEADER))
                    map.Add(entries[1], new CensusDTO(new IndiaStateCodeCSV(entries[0], entries[1], entries[2], entries[3])));
                else
                    map.Add(entries[1], new CensusDTO(new USCensusCSV(entries[0], entries[1], entries[2]
                        , entries[3], entries[4], entries[5], entries[6], entries[7], entries[8])));
            }
            return map.Count;
        }

        public string GetSortedData(string field, string order)
        {
            getCount();
            censusList = new List<CensusDTO>(map.Values);
            sortedLists = getSoretdField(field, censusList);

            if (order.Equals("desc"))
                sortedLists.Reverse();
            string data = JsonConvert.SerializeObject(sortedLists);
            File.WriteAllText(JSON_FILE_PATH, data);
            return data;
        }

        public List<CensusDTO> getSoretdField(string filedName, List<CensusDTO> censusList)
        {
            switch (filedName)
            {
                case "state":
                    return censusList.OrderBy(x => x.state).ToList();
                case "stateCode":
                    return censusList.OrderBy(x => x.stateCode).ToList();
                case "population":
                    return censusList.OrderBy(x => x.population).ToList();
                case "density":
                    return censusList.OrderBy(x => x.density).ToList();
                case "area":
                    return censusList.OrderBy(x => x.area).ToList();
                default: return censusList;
            }
        }
    }
}