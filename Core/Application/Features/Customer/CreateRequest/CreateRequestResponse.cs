namespace Application.Features.Customer.CreateRequest;

public class CreateRequestResponse
{
    public int RequestId { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}