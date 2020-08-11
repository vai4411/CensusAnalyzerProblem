using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class IndiaCensusDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public IndiaCensusDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = long.Parse(population);
            this.area = long.Parse(area);
            this.density = long.Parse(density);
        }
    }
}
