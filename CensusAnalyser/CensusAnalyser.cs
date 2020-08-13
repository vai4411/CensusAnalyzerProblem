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

        public string GetSortedData(SortParameters field, string order)
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

        public List<CensusDTO> GetSoretdField(SortParameters filedName, List<CensusDTO> censusList)
        {
            return filedName switch
            {
                SortParameters.STATE => censusList.OrderBy(x => x.state).ToList(),
                SortParameters.STATE_CODE => censusList.OrderBy(x => x.stateCode).ToList(),
                SortParameters.POPULATION => censusList.OrderBy(x => x.population).ToList(),
                SortParameters.DENSITY => censusList.OrderBy(x => x.density).ToList(),
                SortParameters.AREA => censusList.OrderBy(x => x.area).ToList(),
                SortParameters.POPULATION_DENSITY => censusList.OrderBy(x => x.populationDensity).ToList(),
                SortParameters.POPULATION_WITH_DENSITY => censusList.OrderBy(x => x.population).ThenBy(x => x.populationDensity).ToList(),
                _ => censusList,
            };
        }
    }
}