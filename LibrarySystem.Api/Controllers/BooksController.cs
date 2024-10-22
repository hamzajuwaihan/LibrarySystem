using LibrarySystem.Application.Commands;
using LibrarySystem.Application.Queries;
using MediatR;
using LibrarySystem.Domain.Entities;
namespace LibrarySystem.Api.Controllers;


public static class BooksEndPoint
{
    public static void MapBooksEndpoints(this IEndpointRouteBuilder app)
    {

        RouteGroupBuilder group = app.MapGroup("api/books");

        group.MapPost("", async (AddBookCommand command, IMediator _mediator) =>
        {
            if (command == null)
                return Results.BadRequest("Book data is required");

            Book result = await _mediator.Send(command);
            return Results.Created($"/api/books/{result.Id}", result);
        })
        .Produces<Book>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Accepts<AddBookCommand>("application/json");


        group.MapGet("{id:Guid}", async (Guid id, IMediator _mediator) =>
        {

            GetBookByIdQuery query = new GetBookByIdQuery(id);
            Book book = await _mediator.Send(query);

            if (book == null)
                return Results.NotFound();

            return Results.Ok(book);
        })
        .Produces<Book>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id:guid}", async (Guid id, IMediator _mediator, UpdateBookCommand updatedBook) =>
        {
            if (updatedBook == null || updatedBook.Id != id)
                return Results.BadRequest("Invalid book data");


            Book result = await _mediator.Send(updatedBook);

            if (result == null)
                return Results.NotFound();

            return Results.Ok(result);
        })
        .Produces<Book>(StatusCodes.Status202Accepted)
        .Produces(StatusCodes.Status404NotFound)
        .Accepts<UpdateBookCommand>("application/json");

        group.MapDelete("{id:guid}", async (Guid id, IMediator _mediator) =>
        {
            DeleteBookCommand command = new DeleteBookCommand(id);
            bool result = await _mediator.Send(command);

            if (!result)
                return Results.NotFound();

            return Results.NoContent();

        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("", async (IMediator _mediator) =>
        {
            GetAllBooksQuery query = new GetAllBooksQuery();
            List<Book> books = await _mediator.Send(query);

            return Results.Ok(books);
        })
        .Produces<List<Book>>(StatusCodes.Status200OK);


    }
}