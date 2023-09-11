using MediatR;

namespace Application.Features.Company.CreateResponse;

public class CreateResponseRequest : IRequest<CreateResponseResponse>
{
    public int TeamId { get; set; }
    public int RequestId { get; set; }
    public int Price { get; set; }
}