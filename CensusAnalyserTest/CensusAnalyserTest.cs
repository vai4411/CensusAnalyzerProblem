using CensusAnalyserProblem;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private static string INDIA_CENSUS_CSV_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.csv";
        private static string Wrong_FILE_PATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyser/resources/csv/IndiaStateCensusData.csv";

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
    }
}