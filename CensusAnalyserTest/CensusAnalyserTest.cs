using CensusAnalyserProblem;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private static string INDIA_CENSUS_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.csv";
        private static string Wrong_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyser/resources/csv/StateCensusData.csv";
        private static string INVALID_FILE_TYPE = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.pdf";
        private static string WRONG_DELIMITER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusDataDelimiter.csv";
        private static string WRONG_HEADER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusDataHeader.csv";
        private static string STATE_CODE_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCode.csv";
        private static string INVALID_STATE_CODE_FILE_TYPE = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCode.pdf";
        private static string STATE_CODE_WRONG_DELIMITER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeDelimiter.csv";
        private static string STATE_CODEWRONG_HEADER_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeHeader.csv";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenIndianCensus_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            int count = CensusAnalyser.getStateCensusCount(INDIA_CENSUS_CSV_FILE_PATH);
            Assert.AreEqual(29,count);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ThenThrowException()
        {
            try {
                CensusAnalyser.getStateCensusCount(Wrong_FILE_PATH);
            }catch(CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect File", e.Message);
            }
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFileType_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCensusCount(INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect File Type", e.Message);
            }
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongDelimiterFile_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCensusCount(WRONG_DELIMITER_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect DELIMITER", e.Message);
            }
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFileHeader_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCensusCount(WRONG_HEADER_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect File Header", e.Message);
            }
        }

        [Test]
        public void givenIndianStateCode_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            int count = CensusAnalyser.getStateCodeCount(STATE_CODE_CSV_FILE_PATH);
            Assert.AreEqual(37, count);
        }

        [Test]
        public void givenIndianStateCode_WhenWrongFile_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCodeCount(Wrong_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect File", e.Message);
            }
        }

        [Test]
        public void givenIndianStateCode_WhenWrongFileType_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCodeCount(INVALID_STATE_CODE_FILE_TYPE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect File Type", e.Message);
            }
        }

        [Test]
        public void givenIndianStateCode_WhenWrongDelimiterFile_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCodeCount(STATE_CODE_WRONG_DELIMITER_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect DELIMITER", e.Message);
            }
        }

        [Test]
        public void givenIndianStateCode_WhenWrongFileHeader_ThenThrowException()
        {
            try
            {
                CensusAnalyser.getStateCodeCount(STATE_CODEWRONG_HEADER_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect File Header", e.Message);
            }
        }
    }
}