using System;
using LibrarySystem.Domain.Entities;
using MediatR;

namespace LibrarySystem.Application.Queries;

public class GetAllBooksQuery : IRequest<List<Book>>
{
    

}
