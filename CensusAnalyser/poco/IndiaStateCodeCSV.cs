// <copyright file="IndiaStateCodeCSV.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

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
            this.sr = int.Parse(sr);
            this.stateName = state;
            this.tin = int.Parse(tin);
            this.stateCode = stateCode;
        }
    }
}
