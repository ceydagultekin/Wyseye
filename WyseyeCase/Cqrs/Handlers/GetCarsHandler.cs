using MediatR;
using WyseyeCase.Cqrs.Queries;
using WyseyeCase.Interface;

namespace WyseyeCase.Cqrs.Handlers
{
    public class GetCarsHandler : IRequestHandler<GetCarsQuery, GetCarsQueryResponse>
    {
        private readonly ICar _carRespository;

        public GetCarsHandler(ICar carRespository)
        {
            _carRespository = carRespository;
        }

        public async Task<GetCarsQueryResponse> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRespository.GetCarsAsync();
            return new GetCarsQueryResponse { Cars = cars, Message = "Liste başarıyla getirildi" };
        }
    }
}
