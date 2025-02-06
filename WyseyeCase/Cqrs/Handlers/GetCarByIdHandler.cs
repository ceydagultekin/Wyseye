using MediatR;
using WyseyeCase.Cqrs.Queries;
using WyseyeCase.Interface;

namespace WyseyeCase.Cqrs.Handlers
{
    public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResponse>
    {
        private readonly ICar _carRespository;

        public GetCarByIdHandler(ICar carRespository)
        {
            _carRespository = carRespository;
        }
        public async Task<GetCarByIdQueryResponse> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRespository.GetCarByIdAsync(request.Id);
            return new GetCarByIdQueryResponse { CarId = car.Id, Message = "Araç bilgisi getirildi." };
        }
    }
}
