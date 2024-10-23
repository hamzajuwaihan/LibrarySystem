using LibrarySystem.Application.Commands;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;
using LibrarySystem.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Api.Controllers;
using FluentValidation;
using LibrarySystem.Application.CommandHandlers;
using LibrarySystem.Api.Abstractions;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly));
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddDbContext<DbAppContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("LibraryDatabase")));


builder.Services.AddValidatorsFromAssemblyContaining<AddBookCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookCommandHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapBooksEndpoints();

// app.UseHttpsRedirection();
// app.UseAuthorization();

app.Run();
