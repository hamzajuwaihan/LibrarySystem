using LibrarySystem.infrastructure;
using LibrarySystem.Application;
using LibrarySystem.Presentation.Api.Routes;
using LibrarySystem.Presentation.Api;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure()
.AddApplication()
.AddPresentation();

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


public partial class Program {}