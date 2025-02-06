using MediatR;

namespace WyseyeCase.Cqrs.Queries
{
    public class GetCarsQuery:IRequest<GetCarsQueryResponse>
    {
    }
}
