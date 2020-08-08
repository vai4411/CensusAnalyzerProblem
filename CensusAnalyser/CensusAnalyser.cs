using System;
using System.IO;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        public static int getCount(string path)
        {
            int count = 0;
            if (!path.Contains("IndiaStateCensusData"))
                throw new CensusAnalyserException("Incorrect File");
            if (!path.Contains(".csv"))
                throw new CensusAnalyserException("Incorrect File Type");

            string[] n = File.ReadAllLines(path);
                for (int i = 0; i < n.Length; i++)
                {
                    count++;
                }
                return count - 1;
        }
    }
}
