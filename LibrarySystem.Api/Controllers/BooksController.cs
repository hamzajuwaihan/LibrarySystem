using LibrarySystem.Application.Commands;
using LibrarySystem.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Domain.Entities;
namespace LibrarySystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/books
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
    {
        if (command == null)
            return BadRequest("Book data is required");

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, result);
    }

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var query = new GetBookByIdQuery(id);
        var book = await _mediator.Send(query);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] Book updatedBook)
    {
        if (updatedBook == null || updatedBook.Id != id)
            return BadRequest("Invalid book data");

        var updateCommand = new UpdateBookCommand(updatedBook);
        var result = await _mediator.Send(updateCommand);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var command = new DeleteBookCommand(id);
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }

    // GET: api/books
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var query = new GetAllBooksQuery();
        var books = await _mediator.Send(query);

        return Ok(books);
    }
}