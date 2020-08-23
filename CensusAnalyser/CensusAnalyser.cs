// <copyright file="CensusAnalyser.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// This class use for load data and sort data.
    /// </summary>
    public class CensusAnalyser : ICSVBuilder
    {
        private static readonly string JSONFILEPATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/CensusData.json";

        public delegate int TotalRecords();

        private string path;
        private string header;
        private CountryEnum country;
        private List<CensusDTO> censusList = new List<CensusDTO>();
        private List<CensusDTO> sortedLists = new List<CensusDTO>();
        private Dictionary<string, CensusDTO> map = new Dictionary<string, CensusDTO>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyser"/> class.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="path"></param>
        /// <param name="header"></param>
        public CensusAnalyser(CountryEnum country, string path, string header)
        {
            this.path = path;
            this.header = header;
            this.country = country;
        }

        /// <summary>
        /// This method returns total entry count.
        /// </summary>
        /// <returns>Total number of entries.</returns>
        public int GetCount()
        {
            this.map = new CensusFactory().GetCensusData(this.country, this.path, this.header);
            return this.map.Count;
        }

        /// <summary>
        /// This method returns sorted data in asending and descending order.
        /// </summary>
        /// <param name="field">Enum parameter.</param>
        /// <param name="order">Oredr of sorting.</param>
        /// <returns>Sorted string data.</returns>
        public string GetSortedData(SortParameters field, string order)
        {
            this.GetCount();
            this.censusList = new List<CensusDTO>(this.map.Values);
            this.sortedLists = this.GetSoretdField(field, this.censusList);

            if (order.Equals("desc"))
            {
                this.sortedLists.Reverse();
            }

            string data = JsonConvert.SerializeObject(this.sortedLists);
            File.WriteAllText(JSONFILEPATH, data);
            return data;
        }

        /// <summary>
        /// This method used for analyse sorted data between india and us census data.
        /// </summary>
        /// <param name="indiaCensus">Indian census data.</param>
        /// <param name="usCensus">US census data.</param>
        /// <returns></returns>
        public static string GetSortedDataFromIndianAndUs(IndiaCensusCSV indiaCensus, USCensusCSV usCensus)
        {
           return _ = (indiaCensus.population.CompareTo(usCensus.population) > 0) ? indiaCensus.state : usCensus.state;
        }

        /// <summary>
        /// This method returns list of sorted data.
        /// </summary>
        /// <param name="filedName">Enum parameter.</param>
        /// <param name="censusList">List of data.</param>
        /// <returns>List of sorted data.</returns>
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