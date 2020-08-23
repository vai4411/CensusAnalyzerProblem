// <copyright file="CensusCSV.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    /// <summary>
    /// This class used for manage indian and us census data.
    /// </summary>
    public class CensusCSV
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
        /// This is default constructor.
        /// </summary>
        public CensusCSV()
        {
        }

        /// <summary>
        /// This constructor used for indian census csv.
        /// </summary>
        /// <param name="state">State name.</param>
        /// <param name="population">State population.</param>
        /// <param name="area">State area.</param>
        /// <param name="density">State density.</param>
        public CensusCSV(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = long.Parse(population);
            this.area = long.Parse(area);
            this.density = long.Parse(density);
        }

        /// <summary>
        /// This constructor used for us census data.
        /// </summary>
        /// <param name="stateCode">State code.</param>
        /// <param name="state">State name.</param>
        /// <param name="population">State population.</param>
        /// <param name="housingUnits">State housing unit.</param>
        /// <param name="totalArea">State total area.</param>
        /// <param name="waterArea">State water area.</param>
        /// <param name="landArea">State land area.</param>
        /// <param name="populationDensity">State population density.</param>
        /// <param name="housingDensity">State housing density.</param>
        public CensusCSV(string stateCode, string state, string population, string housingUnits, string totalArea, string waterArea, string landArea, string populationDensity, string housingDensity)
        {
            this.stateCode = stateCode;
            this.state = state;
            this.population = long.Parse(population);
            this.housingUnits = long.Parse(housingUnits);
            this.totalArea = double.Parse(totalArea);
            this.waterArea = double.Parse(waterArea);
            this.landArea = double.Parse(landArea);
            this.populationDensity = double.Parse(populationDensity);
            this.housingDensity = double.Parse(housingDensity);
        }
    }
}
