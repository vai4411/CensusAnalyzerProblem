using CensusAnalyserProblem;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyserProblem.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private static readonly string INDIA_CENSUS_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.csv";
        private static readonly string Wrong_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyser/resources/StateCensusData.csv";
        private static readonly string INVALID_FILE_TYPE = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.pdf";
        private static readonly string WRONG_DELIMITER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusDataDelimiter.csv";
        private static readonly string WRONG_HEADER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeHeader.csv";
        private static readonly string STATE_CODE_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCode.csv";
        private static readonly string STATE_CODE_WRONG_DELIMITER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeDelimiter.csv";
        private static readonly string US_CENSUS_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/USCensusData.csv";
        private static readonly string CENSUS_HEADER = "State,Population,AreaInSqKm,DensityPerSqKm";
        private static readonly string STATE_CODE_HEADER = "SrNo,State Name,TIN,StateCode";
        private static readonly string US_CENSUS_HEADER = "StateId,State,Population,HousingUnits,TotalArea,WaterArea,LandArea,PopulationDensity,HousingDensity";

        [SetUp]
        public void Setup()
        {
        }

        //load indian census data
        [Test]
        public void givenIndianCensus_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            int entries = count();
            Assert.AreEqual(29,entries);
        }

        //file not found exception
        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(Wrong_FILE_PATH,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        //invalid file type exception
        [Test]
        public void givenIndiaCensusData_WhenWrongFileType_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INVALID_FILE_TYPE,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        //invalid delimiter exception
        [Test]
        public void givenIndiaCensusData_WhenWrongDelimiterFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(WRONG_DELIMITER_FILE_PATH,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        //invalid header exception
        [Test]
        public void givenIndiaCensusData_WhenWrongFileHeader_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH,WRONG_HEADER_FILE_PATH);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, result.exceptionType);
        }

        //load indian state code data
        [Test]
        public void givenIndianStateCode_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            int entries = count();
            Assert.AreEqual(37, entries);
        }

        //file not found exception
        [Test]
        public void givenIndianStateCode_WhenWrongFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(Wrong_FILE_PATH, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        //invalid file type exception
        [Test]
        public void givenIndianStateCode_WhenWrongFileType_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INVALID_FILE_TYPE, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        //invalid delimiter exception
        [Test]
        public void givenIndianStateCode_WhenWrongDelimiterFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_WRONG_DELIMITER_FILE_PATH, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        //invalid header exception
        [Test]
        public void givenIndianStateCode_WhenWrongFileHeader_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH,WRONG_HEADER_FILE_PATH);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER,result.exceptionType);
        }

        //sort by state and display first state
        [Test]
        public void givenData_WhenCensusStatePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("state");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Andhra Pradesh", census[0].state);
        }

        //sort by state and display last state
        [Test]
        public void givenData_WhenCensusStatePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("state");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("West Bengal", census[census.Length - 1].state);
        }

        //sort by state code and display first state
        [Test]
        public void givenData_WhenStateCodePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH, STATE_CODE_HEADER);
            string data = censusAnalyser.GetSortedData("stateCode");
            IndiaStateCodeDAO[] census = JsonConvert.DeserializeObject<IndiaStateCodeDAO[]>(data);
            Assert.AreEqual("Andhra Pradesh New", census[0].stateName);
        }

        //sort by state code and display last state
        [Test]
        public void givenData_WhenStateCodePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH, STATE_CODE_HEADER);
            string data = censusAnalyser.GetSortedData("stateCode");
            IndiaStateCodeDAO[] census = JsonConvert.DeserializeObject<IndiaStateCodeDAO[]>(data);
            Assert.AreEqual("West Bengal", census[census.Length - 1].stateName);
        }

        //sort by population and display less populated state
        [Test]
        public void givenData_WhenPopulationPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulateState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("population");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Sikkim", census[0].state);
        }

        //sort by population and display most populated state
        [Test]
        public void givenData_WhenPopulationPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("population");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Uttar Pradesh", census[census.Length - 1].state);
        }

        //sort by population density and display less population density state
        [Test]
        public void givenData_WhenPopulationDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulationDensityState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("density");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Arunachal Pradesh", census[0].state);
        }

        //sort by population density and display less population density state
        [Test]
        public void givenData_WhenPopulationDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulationDensityState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("density");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Bihar", census[census.Length - 1].state);
        }

        //sort by area and display less area state
        [Test]
        public void givenData_WhenAreaPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessAreaState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("area");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Goa", census[0].state);
        }

        //sort by area and display most area state
        [Test]
        public void givenData_WhenAreaPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostAreaState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("area");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Rajasthan", census[census.Length - 1].state);
        }

        //load us census data
        [Test]
        public void givenUSCensus_WhenCSVFileLoad_ThenReturnsNumberOfRecords()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(US_CENSUS_CSV_FILE_PATH, US_CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            int entries = count();
            Assert.AreEqual(51, entries);
        }
    }
}