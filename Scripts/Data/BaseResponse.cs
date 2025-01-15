using System.Net;

public class BaseResponse<T>
{
    public T? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}