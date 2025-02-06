using MediatR;
using WyseyeCase.Models.Model;

namespace WyseyeCase.Cqrs.Commands
{
    public class UpdateCarCommand:IRequest<UpdateCarCommandResponse>
    {
        public Car Car { get; set; }

        public UpdateCarCommand(Car car)
        {
            Car = car;
        }
    }
}
