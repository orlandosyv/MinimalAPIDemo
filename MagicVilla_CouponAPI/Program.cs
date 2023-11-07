var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/helloworld/{id:int}", (int id) => 
{
    return Results.Ok("ID!" + id);
});

app.MapPost("/helloWorld2", () => Results.Ok("Hallo Welt 2"));

app.UseHttpsRedirection();

app.Run();
