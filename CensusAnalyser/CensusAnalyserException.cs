using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CensusAnalyserException:Exception
    {
      //  private string message;

        public CensusAnalyserException(string message):base(message)
        {
           // this.message = message;
        }

        public override string Message => base.Message;
    }
}
