using System.Text.Json;

namespace Sat.Recruitment.Api.ExceptionHandler
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
            
        }
    }
}