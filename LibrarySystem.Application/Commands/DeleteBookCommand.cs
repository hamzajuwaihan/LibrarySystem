using MediatR;
namespace LibrarySystem.Application.Commands;
/// <summary>
/// Delete book command to send for MideatR
/// </summary>
/// <param name="id"></param>
public class DeleteBookCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; private init; } = id;
}
