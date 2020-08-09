using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CSVBuilderFactory
    {
        public ICSVBuilder builder(string path,string header)
        {
            return new CensusAnalyser(path, header);
        }
    }
}
