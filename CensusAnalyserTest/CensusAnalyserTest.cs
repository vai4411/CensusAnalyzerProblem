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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenIndianCensus_WhenCSVFileInterate_ThenReturnsNumberOfRecords()
        {
            int count = CensusAnalyser.getCount(INDIA_CENSUS_CSV_FILE_PATH);
            Assert.AreEqual(29,count);
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongFile_ThenThrowException()
        {
            try {
                CensusAnalyser.getCount(Wrong_FILE_PATH);
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
                CensusAnalyser.getCount(INVALID_FILE_TYPE);
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
                CensusAnalyser.getCount(WRONG_DELIMITER_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect DELIMITER", e.Message);
            }
        }
    }
}