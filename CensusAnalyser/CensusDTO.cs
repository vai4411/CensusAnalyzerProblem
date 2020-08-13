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
        /// <param name="indiaCensusDAO">IndiaCensusCSV.</param>
        public CensusDTO(IndiaCensusCSV indiaCensusDAO)
        {
            this.state = indiaCensusDAO.state;
            this.population = indiaCensusDAO.population;
            this.area = indiaCensusDAO.area;
            this.density = indiaCensusDAO.density;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="indiaCensusDAO">IndiaStateCodeCSV.</param>
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
        /// <param name="indiaCensusDAO">USCensusCSV.</param>
        public CensusDTO(USCensusCSV usCensusDAO)
        {
            this.stateCode = usCensusDAO.stateCode;
            this.state = usCensusDAO.state;
            this.population = usCensusDAO.population;
            this.housingUnits = usCensusDAO.housingUnits;
            this.totalArea = usCensusDAO.totalArea;
            this.waterArea = usCensusDAO.waterArea;
            this.landArea = usCensusDAO.landArea;
            this.populationDensity = usCensusDAO.populationDensity;
            this.housingDensity = usCensusDAO.housingDensity;
        }
    }
}
