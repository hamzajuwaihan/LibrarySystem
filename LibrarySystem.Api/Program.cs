using LibrarySystem.Application.Commands;
using LibrarySystem.Infrastructure.Repositories;
using MediatR;
using LibrarySystem.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Api.Controllers;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly));
builder.Services.AddScoped<IBookRepository, BookRepository>();


// Configure PostgreSQL database context
builder.Services.AddDbContext<DbAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LibraryDatabase")));


// Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapBooksEndpoints();

// app.UseHttpsRedirection();
// app.UseAuthorization();

app.Run();
