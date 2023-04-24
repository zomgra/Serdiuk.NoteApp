using AspNetCoreRateLimit;
using Serdiuk.NoteApp.Appication;
using Serdiuk.NoteApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddMemoryCache();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestRateLimitMiddleware>(1, TimeSpan.FromMinutes(4));

app.UseAuthorization();

app.MapControllers();

app.Run();
