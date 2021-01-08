using SurveyApp.WebFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.WebFramework.Execptions
{
    public class LogicExeption : AppException
    {
        public LogicExeption(string message) 
            : base( message, ApiResultStatusCode.LogicError)
        {
        }
    }
}
