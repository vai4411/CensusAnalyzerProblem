using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser : ICSVBuilder
    {
        private static readonly string JSON_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/CensusData.json";
        public delegate int totalRecords();
        public string path;
        public string header;
        public CountryEnum country;
        List<CensusDTO> censusList = new List<CensusDTO>();
        List<CensusDTO> sortedLists = new List<CensusDTO>();
        Dictionary<string, CensusDTO> map = new Dictionary<string, CensusDTO>();

        public CensusAnalyser(CountryEnum country,string path, string header)
        {
            this.path = path;
            this.header = header;
            this.country = country;
        }

        public int getCount() 
        {
            map = new CensusFactory().GetCensusData(country,path,header);
            return map.Count;
        }

        public string GetSortedData(string field, string order)
        {
            getCount();
            censusList = new List<CensusDTO>(map.Values);
            sortedLists = GetSoretdField(field, censusList);

            if (order.Equals("desc"))
                sortedLists.Reverse();
            string data = JsonConvert.SerializeObject(sortedLists);
            File.WriteAllText(JSON_FILE_PATH, data);
            return data;
        }

        public List<CensusDTO> GetSoretdField(string filedName, List<CensusDTO> censusList)
        {
            return filedName switch
            {
                "state" => censusList.OrderBy(x => x.state).ToList(),
                "stateCode" => censusList.OrderBy(x => x.stateCode).ToList(),
                "population" => censusList.OrderBy(x => x.population).ToList(),
                "density" => censusList.OrderBy(x => x.density).ToList(),
                "area" => censusList.OrderBy(x => x.area).ToList(),
                _ => censusList,
            };
        }
    }
}