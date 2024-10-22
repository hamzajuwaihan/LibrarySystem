using MediatR;

namespace LibrarySystem.Application.Commands;

public class DeleteBookCommand : IRequest<bool>
{
    public Guid Id {get; private init;}

    public DeleteBookCommand(Guid id){
        this.Id = id;
    }
}
