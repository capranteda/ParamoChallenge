namespace Sat.Recruitment.Model.DTOs
{
    public class ResultDTO
    {
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        
        
        }
}