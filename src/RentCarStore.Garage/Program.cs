using RentCarStore.Garage.Endpoints;
using RentCarStore.Garage.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ResolveDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

GarageEndpoints.RegisterEndpoints(app);

app.Run();