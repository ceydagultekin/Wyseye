using MediatR;

namespace WyseyeCase.Cqrs.Commands
{
    public class DeleteCarCommand:IRequest<DeleteCarCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCarCommand(int id)
        {
            Id = id;
        }
    }
}
