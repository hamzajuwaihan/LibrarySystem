using LibrarySystem.Application.Commands;
using LibrarySystem.Application.Queries;
using MediatR;
using LibrarySystem.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LibrarySystem.Presentation.Api.Routes;

public static class BooksEndPoint
{
    public static void MapBooksEndpoints(this IEndpointRouteBuilder app)
    {

        RouteGroupBuilder group = app.MapGroup("api/books");

        group.MapPost("", async (AddBookCommand command, IValidator<AddBookCommand> validator, IMediator _mediator) =>
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

            if (command == null) return Results.BadRequest("Book data is required");

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

            if (book == null) return Results.NotFound();

            return Results.Ok(book);
        })
        .Produces<Book>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id:guid}", async (Guid id, IMediator _mediator, IValidator<UpdateBookCommand> validator, UpdateBookCommand updatedBook) =>
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(updatedBook);

            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

            if (updatedBook == null || updatedBook.Id != id) return Results.BadRequest("Invalid book data");

            Book result = await _mediator.Send(updatedBook);

            if (result == null) return Results.NotFound();

            return Results.Ok(result);
        })
        .Produces<Book>(StatusCodes.Status202Accepted)
        .Produces(StatusCodes.Status404NotFound)
        .Accepts<UpdateBookCommand>("application/json");

        group.MapDelete("{id:guid}", async (Guid id, IMediator _mediator) =>
        {
            DeleteBookCommand command = new DeleteBookCommand(id);

            bool result = await _mediator.Send(command);

            if (!result) return Results.NotFound();

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

        group.MapPatch("{id:guid}", async (Guid id, PatchBookCommand command, IMediator _mediator) =>
       {
           if (id != command.Id) return Results.BadRequest("Mismatched book ID in the path and request body.");

           Book updatedBook = await _mediator.Send(command);

           if (updatedBook == null) return Results.NotFound();

           return Results.Ok(updatedBook);
       })
       .Produces<Book>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status400BadRequest)
       .Produces(StatusCodes.Status404NotFound)
       .Accepts<PatchBookCommand>("application/json");

    }
}
