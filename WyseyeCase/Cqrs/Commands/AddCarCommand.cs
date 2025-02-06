using MediatR;
using WyseyeCase.Cqrs.Queries;
using WyseyeCase.Models.Model;

namespace WyseyeCase.Cqrs.Commands
{
    public class AddCarCommand:IRequest<AddCarCommandResponse>
    {
        public Car Car { get; set; }

        public AddCarCommand(Car car)
        {
            Car = car;
        }
    }
}
