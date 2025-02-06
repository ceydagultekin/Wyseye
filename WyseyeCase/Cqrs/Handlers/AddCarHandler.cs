using MediatR;
using WyseyeCase.Cqrs.Commands;
using WyseyeCase.Interface;

namespace WyseyeCase.Cqrs.Handlers
{
    public class AddCarHandler : IRequestHandler<AddCarCommand, AddCarCommandResponse>
    {
        private readonly ICar _carRespository;

        public AddCarHandler(ICar carRespository)
        {
            _carRespository = carRespository;
        }

        public async Task<AddCarCommandResponse> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var addedCar = await _carRespository.AddCar(request.Car);
            return new AddCarCommandResponse { Car = addedCar , Message = "Araba başarıyla eklendi."};
        }
    }
}
