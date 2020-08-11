using CensusAnalyserProblem;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyserProblem.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private static string INDIA_CENSUS_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.csv";
        private static string Wrong_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyser/resources/StateCensusData.csv";
        private static string INVALID_FILE_TYPE = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.pdf";
        private static string WRONG_DELIMITER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusDataDelimiter.csv";
        private static string WRONG_HEADER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeHeader.csv";
        private static string STATE_CODE_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCode.csv";
        private static string STATE_CODE_WRONG_DELIMITER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeDelimiter.csv";
        private static string CENSUS_HEADER = "State,Population,AreaInSqKm,DensityPerSqKm";
        private static string STATE_CODE_HEADER = "SrNo,State Name,TIN,StateCode";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenIndianCensus_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            int entries = count();
            Assert.AreEqual(29,entries);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(Wrong_FILE_PATH,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFileType_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INVALID_FILE_TYPE,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongDelimiterFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(WRONG_DELIMITER_FILE_PATH,CENSUS_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFileHeader_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH,WRONG_HEADER_FILE_PATH);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, result.exceptionType);
        }

        [Test]
        public void givenIndianStateCode_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            int entries = count();
            Assert.AreEqual(37, entries);
        }

        [Test]
        public void givenIndianStateCode_WhenWrongFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(Wrong_FILE_PATH, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        [Test]
        public void givenIndianStateCode_WhenWrongFileType_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INVALID_FILE_TYPE, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        [Test]
        public void givenIndianStateCode_WhenWrongDelimiterFile_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_WRONG_DELIMITER_FILE_PATH, STATE_CODE_HEADER);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        [Test]
        public void givenIndianStateCode_WhenWrongFileHeader_ThenThrowException()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH,WRONG_HEADER_FILE_PATH);
            totalRecords count = new totalRecords(censusAnalyser.getCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER,result.exceptionType);
        }

        [Test]
        public void givenData_WhenCensusStatePass_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("state");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Andhra Pradesh", census[0].state);
        }

        [Test]
        public void givenData_WhenCensusStatePass_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("state");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("West Bengal", census[census.Length - 1].state);
        }

        [Test]
        public void givenData_WhenStateCodePass_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH, STATE_CODE_HEADER);
            string data = censusAnalyser.GetSortedData("stateCode");
            IndiaStateCodeDAO[] census = JsonConvert.DeserializeObject<IndiaStateCodeDAO[]>(data);
            Assert.AreEqual("Andhra Pradesh New", census[0].stateName);
        }

        [Test]
        public void givenData_WhenStateCodePass_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(STATE_CODE_CSV_FILE_PATH, STATE_CODE_HEADER);
            string data = censusAnalyser.GetSortedData("stateCode");
            IndiaStateCodeDAO[] census = JsonConvert.DeserializeObject<IndiaStateCodeDAO[]>(data);
            Assert.AreEqual("West Bengal", census[census.Length - 1].stateName);
        }

        [Test]
        public void givenData_WhenPopulationPass_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("population");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Sikkim", census[0].state);
        }

        [Test]
        public void givenData_WhenPopulationPass_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("population");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Uttar Pradesh", census[census.Length - 1].state);
        }

        [Test]
        public void givenData_WhenPopulationDensityPass_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("density");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Arunachal Pradesh", census[0].state);
        }

        [Test]
        public void givenData_WhenPopulationDensityPass_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CSVBuilderFactory factory = new CSVBuilderFactory();
            CensusAnalyser censusAnalyser = (CensusAnalyser)factory.builder(INDIA_CENSUS_CSV_FILE_PATH, CENSUS_HEADER);
            string data = censusAnalyser.GetSortedData("density");
            IndiaCensusDAO[] census = JsonConvert.DeserializeObject<IndiaCensusDAO[]>(data);
            Assert.AreEqual("Bihar", census[census.Length - 1].state);
        }
    }
}