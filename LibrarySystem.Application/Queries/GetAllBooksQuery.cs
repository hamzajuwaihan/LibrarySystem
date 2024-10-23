using LibrarySystem.Domain.Entities;
using MediatR;

namespace LibrarySystem.Application.Queries;
/// <summary>
/// Get all books Query class.
/// </summary>
public class GetAllBooksQuery : IRequest<List<Book>>{}
