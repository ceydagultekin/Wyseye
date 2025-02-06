using MediatR;
using WyseyeCase.Models.Model;

namespace WyseyeCase.Cqrs.Commands
{
    public class UpdateCarCommandResponse
    {
        public Car Car { get; set; }
        public string Message { get; set; }
    }
}
