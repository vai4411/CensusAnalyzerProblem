using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CensusDTO
    {
        public string state;
        public int sr;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;

        public CensusDTO(IndiaCensusDAO indiaCensusDAO)
        {
            this.state = indiaCensusDAO.state;
            this.population = indiaCensusDAO.population;
            this.area = indiaCensusDAO.area;
            this.density = indiaCensusDAO.density;
        }

        public CensusDTO(IndiaStateCodeDAO stateCodeDAO)
        {
            this.sr = stateCodeDAO.sr;
            this.state = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }
    }
}
