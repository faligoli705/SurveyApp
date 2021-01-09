
namespace SurveyApp.Infrastucture.Execptions
{
    public class LogicExeption : AppException
    {
        public LogicExeption(string message) 
            : base( message, ApiResultStatusCode.LogicError)
        {
        }
    }
}
