// <copyright file="Tests.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserTest
{
    using CensusAnalyserProblem;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using static CensusAnalyserProblem.CensusAnalyser;

    /// <summary>
    /// Test cases.
    /// </summary>
    public class Tests
    {
        // india census and state code file paths
        private static readonly string IndiaCensusCSVFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.csv";
        private static readonly string WrongFILEPATH = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyser/resources/StateCensusData.csv";
        private static readonly string InvalidFileType = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusData.pdf";
        private static readonly string WrongDelimiterFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCensusDataDelimiter.csv";
        private static readonly string WrongHeaderFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeHeader.csv";
        private static readonly string StateCodeCSVFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCode.csv";
        private static readonly string StateCodeWrongDelimiterFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/IndiaStateCodeDelimiter.csv";

        // us census file paths
        private static readonly string UsCensusCSVFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/USCensusData.csv";
        private static readonly string USCensusWrongDelimiterFilePath = "C:/Users/Vaibhav/source/repos/CensusAnalyser/CensusAnalyserTest/resources/csv/USCensusDataDelimiter.csv";

        // header files
        private static readonly string CensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        private static readonly string StateCodeHeader = "SrNo,State Name,TIN,StateCode";
        private static readonly string USCensusHeader = "StateId,State,Population,HousingUnits,TotalArea,WaterArea,LandArea,PopulationDensity,HousingDensity";

        /// <summary>
        /// setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// load indian census data.
        /// </summary>
        [Test]
        public void GivenIndianCensus_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            int entries = count();
            Assert.AreEqual(29, entries);
        }

        /// <summary>
        /// file not found exception.
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenWrongFile_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, WrongFILEPATH, CensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        /// <summary>
        /// invalid file type exception.
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenWrongFileType_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, InvalidFileType, CensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        /// <summary>
        /// invalid delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenWrongDelimiterFile_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, WrongDelimiterFilePath, CensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        /// <summary>
        /// invalid header exception.
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenWrongFileHeader_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, WrongHeaderFilePath);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, result.exceptionType);
        }

        /// <summary>
        /// load indian state code data.
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenCSVFileIterate_ThenReturnsNumberOfRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, StateCodeCSVFilePath, StateCodeHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            int entries = count();
            Assert.AreEqual(37, entries);
        }

        /// <summary>
        /// file not found exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenWrongFile_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, WrongFILEPATH, StateCodeHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        /// <summary>
        /// invalid file type exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenWrongFileType_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, InvalidFileType, StateCodeHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        /// <summary>
        /// invalid delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenWrongDelimiterFile_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, StateCodeWrongDelimiterFilePath, StateCodeHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        /// <summary>
        /// invalid header exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenWrongFileHeader_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, StateCodeCSVFilePath, WrongHeaderFilePath);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, result.exceptionType);
        }

        /// <summary>
        /// sort by state and display first state.
        /// </summary>
        [Test]
        public void GivenData_WhenCensusStatePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.STATE, "asc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Andhra Pradesh", census[0].state);
        }

        /// <summary>
        /// sort by state and display last state.
        /// </summary>
        [Test]
        public void GivenData_WhenCensusStatePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.STATE, "desc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("West Bengal", census[0].state);
        }

        /// <summary>
        /// sort by state code and display first state.
        /// </summary>
        [Test]
        public void GivenData_WhenStateCodePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayFirstState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, StateCodeCSVFilePath, StateCodeHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.STATE_CODE, "asc");
            IndiaStateCodeCSV[] census = JsonConvert.DeserializeObject<IndiaStateCodeCSV[]>(data);
            Assert.AreEqual("Andhra Pradesh New", census[0].stateName);
        }

        /// <summary>
        /// sort by state code and display last state.
        /// </summary>
        [Test]
        public void GivenData_WhenStateCodePassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLastState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, StateCodeCSVFilePath, StateCodeHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.STATE_CODE, "desc");
            IndiaStateCodeCSV[] census = JsonConvert.DeserializeObject<IndiaStateCodeCSV[]>(data);
            Assert.AreEqual("West Bengal", census[0].stateName);
        }

        /// <summary>
        /// sort by population and display less populated state.
        /// </summary>
        [Test]
        public void GivenData_WhenPopulationPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION, "asc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Sikkim", census[0].state);
        }

        /// <summary>
        /// sort by population and display most populated state.
        /// </summary>
        [Test]
        public void GivenData_WhenPopulationPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION, "desc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Uttar Pradesh", census[0].state);
        }

        /// <summary>
        /// sort by population density and display less population density state.
        /// </summary>
        [Test]
        public void GivenData_WhenPopulationDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulationDensityState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.DENSITY, "asc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Arunachal Pradesh", census[0].state);
        }

        /// <summary>
        /// sort by population density and display less population density state.
        /// </summary>
        [Test]
        public void GivenData_WhenPopulationDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulationDensityState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.DENSITY, "desc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Bihar", census[0].state);
        }

        /// <summary>
        /// sort by area and display less area state.
        /// </summary>
        [Test]
        public void GivenData_WhenAreaPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessAreaState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.AREA, "asc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Goa", census[0].state);
        }

        /// <summary>
        /// sort by area and display most area state.
        /// </summary>
        [Test]
        public void GivenData_WhenAreaPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostAreaState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.AREA, "desc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Rajasthan", census[0].state);
        }

        /// <summary>
        /// load us census data.
        /// </summary>
        [Test]
        public void GivenUSCensus_WhenCSVFileLoad_ThenReturnsNumberOfRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            int entries = count();
            Assert.AreEqual(51, entries);
        }

        /// <summary>
        /// file not found exception.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenWrongFile_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, WrongFILEPATH, USCensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, result.exceptionType);
        }

        /// <summary>
        /// invalid file type exception.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenWrongFileType_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, InvalidFileType, USCensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, result.exceptionType);
        }

        /// <summary>
        /// invalid delimiter exception.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenWrongDelimiterFile_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, USCensusWrongDelimiterFilePath, USCensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, result.exceptionType);
        }

        /// <summary>
        /// invalid header exception.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenWrongFileHeader_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, WrongHeaderFilePath);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADER, result.exceptionType);
        }

        /// <summary>
        /// invalid country exception.
        /// </summary>
        [Test]
        public void GivenUSCensus_WhenChooseWrongCountry_ThenThrowException()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.OTHER, UsCensusCSVFilePath, USCensusHeader);
            TotalRecords count = new TotalRecords(censusAnalyser.GetCount);
            var result = Assert.Throws<CensusAnalyserException>(() => count());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_COUNTRY, result.exceptionType);
        }

        /// <summary>
        /// sort by population and display less populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenPopulationPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION, "asc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("Wyoming", census[0].state);
        }

        /// <summary>
        /// sort by population and display most populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenPopulationPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION, "desc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("California", census[0].state);
        }

        /// <summary>
        /// sort by population density and display less populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenPopulationDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION_DENSITY, "asc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("Alaska", census[0].state);
        }

        /// <summary>
        /// sort by population density and display most populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenPopulationDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION_DENSITY, "desc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("District of Columbia", census[0].state);
        }

        /// <summary>
        /// sort by area and display less populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenAreaPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayLessPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.AREA, "asc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("Alabama", census[0].state);
        }

        /// <summary>
        /// sort by area and display most populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenAreaPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.AREA, "desc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("Wyoming", census[0].state);
        }

        /// <summary>
        /// sort by population with density and display most populated state.
        /// </summary>
        [Test]
        public void GivenIndianCensusData_WhenPopulationAndDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.INDIA, IndiaCensusCSVFilePath, CensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION_WITH_DENSITY, "desc");
            IndiaCensusCSV[] census = JsonConvert.DeserializeObject<IndiaCensusCSV[]>(data);
            Assert.AreEqual("Uttar Pradesh", census[0].state);
        }

        /// <summary>
        /// sort by population with density and display most populated state.
        /// </summary>
        [Test]
        public void GivenUSCensusData_WhenPopulationAndDensityPassAsSortingParameter_ThenSortDataInJsonFormatAndDisplayMostPopulateState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(CountryEnum.US, UsCensusCSVFilePath, USCensusHeader);
            string data = censusAnalyser.GetSortedData(SortParameters.POPULATION_WITH_DENSITY, "desc");
            USCensusCSV[] census = JsonConvert.DeserializeObject<USCensusCSV[]>(data);
            Assert.AreEqual("California", census[0].state);
        }
    }
}