using MediatR;
using WyseyeCase.Cqrs.Commands;
using WyseyeCase.Interface;

namespace WyseyeCase.Cqrs.Handlers
{
    public class UpdateCarHandler : IRequestHandler<UpdateCarCommand, UpdateCarCommandResponse>
    {
        private readonly ICar _carRespository;

        public UpdateCarHandler(ICar carRespository)
        {
            _carRespository = carRespository;
        }

        public async Task<UpdateCarCommandResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var updatedCar = await _carRespository.UpdateCar(request.Car);
            return new UpdateCarCommandResponse { Car = updatedCar , Message = "Araba bilgisi başarıyla güncellendi."};

        }
    }
}
