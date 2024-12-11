namespace PT_SalasDario.API.Infra
{
    public class ErrorResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
