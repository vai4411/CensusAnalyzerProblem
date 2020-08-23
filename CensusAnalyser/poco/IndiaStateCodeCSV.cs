// <copyright file="IndiaStateCodeCSV.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    /// <summary>
    /// This class used for manage indian state code data.
    /// </summary>
    public class IndiaStateCodeCSV
    {
        public int sr;
        public string stateName;
        public int tin;
        public string stateCode;

        /// <summary>
        /// This constructor used for manage indian state code.
        /// </summary>
        /// <param name="sr">State sr.</param>
        /// <param name="state">State name.</param>
        /// <param name="tin">State tin.</param>
        /// <param name="stateCode">State code.</param>
        public IndiaStateCodeCSV(string sr, string state, string tin, string stateCode)
        {
            this.sr = int.Parse(sr);
            this.stateName = state;
            this.tin = int.Parse(tin);
            this.stateCode = stateCode;
        }
    }
}
