namespace OrderManagement.Api;

public record ApiResponse<T>(string Message, T Data) : ApiResponse(Message);

public record ApiResponse(string Message)
{
    public DateTime ResponseDate { get; init; } = DateTime.UtcNow;
    public string Message { get; init; } = Message;
}