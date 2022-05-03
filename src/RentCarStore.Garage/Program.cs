using RentCarStore.Garage.Endpoints;
using RentCartStore.Core.Messaging.Extensions;
using RestCarStore.Garage.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessaging("host=localhost");
builder.Services.AddScoped<IGarageServices, GarageServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

GarageEndpoints.RegisterEndpoints(app);

app.Run();