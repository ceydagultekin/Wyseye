using MediatR;
using WyseyeCase.Cqrs.Commands;
using WyseyeCase.Interface;

namespace WyseyeCase.Cqrs.Handlers
{
    public class DeleteCarHandler : IRequestHandler<DeleteCarCommand, DeleteCarCommandResponse>
    {
        private readonly ICar _carRespository;

        public DeleteCarHandler(ICar carRespository)
        {
            _carRespository = carRespository;
        }
        public async Task<DeleteCarCommandResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await _carRespository.DeleteCar(request.Id);
            return new DeleteCarCommandResponse { CarId = request.Id, Message = "Araba bilgisi başarıyla silindi." };
        }
    }
}
