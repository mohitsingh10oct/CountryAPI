namespace CountryAPI.Utility.ApiResponse
{
    public class ServiceResponse<T>
    {
        public bool IsSuccessfull { get; set; }
        public int Count { get; set; }
        public T ResponseData { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public ExceptionType ExceptionType { get; set; }
    }

    public enum ExceptionType
    {
        None = 0,
        Custom = 3,
        BadData = 4,
        Internal = 5
    }
}
