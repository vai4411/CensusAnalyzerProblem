using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class USCensusCSV
    {
        public string stateCode;
        public string state;
        public long population;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public USCensusCSV(string stateCode, string state, string population, string housingUnits, string totalArea, 
            string waterArea, string landArea, string populationDensity, string housingDensity)
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
