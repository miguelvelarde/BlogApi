namespace BlogApi.Services;

public class ApiResponse
{
    public ApiResponse()
    {
        ErrorMessage = [];
    }

    public HttpStatusCode StatusCode { get; set; }

    public bool IsSuccess { get; set; }

    public List<string> ErrorMessage { get; set; }

    public object Result { get; set; }
}
