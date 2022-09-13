using LaRecipe;
using LaRecipe.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddLaRecipe()  // <- 
    .AddControllers();

var app = builder.Build();

app.UseHttpsRedirection()
    .UseLaRecipe()  // <- 
    .UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "Visit /docs 🎉");

app.Run();