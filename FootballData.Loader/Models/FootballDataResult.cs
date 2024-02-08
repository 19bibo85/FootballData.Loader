namespace FootballData.Loader.Models
{
    public class FootballDataResult<T> where T : class
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; } = "OK";

        public T Data { get; set; }
    }
}
