
namespace IntegratedProtection.Application.Bases;

public class Response<TData>
{
    public Response() { }
    public Response(TData data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public Response(string message = null)
    {
        Succeeded = true;
        Message = message;
    }
    public Response(string message, bool succeeded)
    {
        Succeeded = true;
        Message = message;
    }
    public object Meta { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public TData? Data { get; set; }
    public List<string> Errors { get; set; }
}
public class ResponseHandler : Handler
{
    public ResponseHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }
    public Response<TData> Delete<TData>(string message = null) => new()
    {
        StatusCode = HttpStatusCode.OK,
        Succeeded = true,
        Message = message == null ? "Deleted Successfully" : message
    };
    public Response<TData> Success<TData>(TData data, object meta = null, string message = null)
        => new()
        {
            Data = data,
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = message == null ? "Retrieve Successfully" : message,
            Meta = meta
        };
    public Response<TData> Unauthorized<TData>() => new()
    {
        StatusCode = HttpStatusCode.Unauthorized,
        Succeeded = true,
        Message = "Un Authorized"
    };
    public Response<TData> BadRequest<TData>(string message = null, object meta = null) => new()
    {
        StatusCode = HttpStatusCode.BadRequest,
        Succeeded = false,
        Message = message == null ? "Bad Request" : message,
        Meta = meta
    };
    public Response<TData> NotFound<TData>(string message) => new()
    {
        StatusCode = HttpStatusCode.NotFound,
        Succeeded = false,
        Message = message == null ? "Not Found" : message,
    };
    public Response<TData> Created<TData>(TData data, object meta = null) => new()
    {
        Data = data,
        StatusCode = HttpStatusCode.Created,
        Succeeded = true,
        Message = "Created Successfully",
        Meta = meta
    };
    public Response<TData> NoContent<TData>(string message = null) => new()
    {
        Succeeded = true,
        StatusCode = HttpStatusCode.NoContent,
        Message = message == null ? "no data founded !" : message
    };
    public Response<TData> Accepted<TData>(TData data, string message = null, object meta = null) => new()
    {
        StatusCode = HttpStatusCode.Accepted,
        Data = data,
        Succeeded = true,
        Message = "Operation Success",
    };
}
