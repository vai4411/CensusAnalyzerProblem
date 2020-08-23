// <copyright file="CensusDTO.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    /// <summary>
    /// This class used as DTO class.
    /// </summary>
    public class CensusDTO
    {
        public string state;
        public int sr;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="stateCodeDAO">IndiaStateCodeCSV.</param>
        public CensusDTO(IndiaStateCodeCSV stateCodeDAO)
        {
            this.sr = stateCodeDAO.sr;
            this.state = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="censusDAO">censusCSV.</param>
        public CensusDTO(CensusCSV censusDAO)
        {
            this.state = censusDAO.state;
            this.population = censusDAO.population;
            this.area = censusDAO.area;
            this.density = censusDAO.density;
            this.stateCode = censusDAO.stateCode;
            this.housingUnits = censusDAO.housingUnits;
            this.totalArea = censusDAO.totalArea;
            this.waterArea = censusDAO.waterArea;
            this.landArea = censusDAO.landArea;
            this.populationDensity = censusDAO.populationDensity;
            this.housingDensity = censusDAO.housingDensity;
        }
    }
}
