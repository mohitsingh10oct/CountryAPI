using CountryAPI.Services;

namespace CountryAPI.Utility.ApiResponse
{
    public class BuildResponse
    {
        public static ServiceResponse<T> SuccessResponse<T>(T data, string successmessage = "")
        {
            int responseCount = GetResponseCount(data);
            return new ServiceResponse<T>
            {
                IsSuccessfull = true,
                ExceptionType = ExceptionType.None,
                ResponseData = data,
                Count = responseCount,
                SuccessMessage = ((!string.IsNullOrEmpty(successmessage)) ? successmessage : "Successfull"),
                ErrorMessage = string.Empty
            };
        }

        public static int GetResponseCount<T>(T data)
        {
            int result = 0;
            try
            {
                result = ((object)data is List<T> list) ? list.Count : 0;
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
