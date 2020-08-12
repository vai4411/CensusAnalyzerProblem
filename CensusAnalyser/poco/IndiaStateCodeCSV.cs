using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class IndiaStateCodeCSV
    {
        public int sr;
        public string stateName;
        public int tin;
        public string stateCode;

        public IndiaStateCodeCSV(string sr, string state, string tin, string stateCode)
        {
            this.sr = Int32.Parse(sr);
            this.stateName = state;
            this.tin = Int32.Parse(tin);
            this.stateCode = stateCode;
        }
    }
}
