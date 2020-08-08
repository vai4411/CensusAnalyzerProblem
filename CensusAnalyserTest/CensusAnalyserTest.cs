using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        private static string IndianCensus = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.csv";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int count = CensusAnalyserProblem.CensusAnalyser.getCount(IndianCensus);
            Assert.AreEqual(29,count);
        }
    }
}