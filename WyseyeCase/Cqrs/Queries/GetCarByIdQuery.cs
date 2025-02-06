using MediatR;

namespace WyseyeCase.Cqrs.Queries
{
    public class GetCarByIdQuery:IRequest<GetCarByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
