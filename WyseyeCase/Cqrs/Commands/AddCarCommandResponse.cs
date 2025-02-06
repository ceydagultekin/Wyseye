using WyseyeCase.Models.Model;

namespace WyseyeCase.Cqrs.Commands
{
    public class AddCarCommandResponse
    {
        public Car Car { get; set; }
        public string Message { get; set; }
    }
}
