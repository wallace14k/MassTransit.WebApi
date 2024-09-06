using MassTransit.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransitExtension();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.AddAppMap();
app.Run();

