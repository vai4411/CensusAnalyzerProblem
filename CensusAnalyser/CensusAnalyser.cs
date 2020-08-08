using System;
using System.IO;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        public static int getCount(string path)
        {
            try
            {
                int count = 0;
                string[] n = File.ReadAllLines(path);
                for (int i = 0; i < n.Length; i++)
                {
                    count++;
                }
                return count - 1;
            }catch(Exception e)
            {
                throw new CensusAnalyserException("Incorrect File");
            }
        }
    }
}
