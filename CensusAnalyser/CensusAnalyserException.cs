using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CensusAnalyserException:Exception
    {
        public string message;
               public enum ExceptionType
               {
                   FILE_NOT_FOUND,
                   INVALID_HEADER,
                   INVALID_DELIMITER,
                   INVALID_FILE_TYPE,
               }
               public ExceptionType exceptionType;

        public CensusAnalyserException(ExceptionType exceptionType) : base(exceptionType.ToString()) 
        {
            this.exceptionType = exceptionType;
        }
    }
}
