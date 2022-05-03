using RentCarStore.Customers.Endpoints;
using RentCarStore.Customers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomersServices, CustomerServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
CustomerEndpoints.RegisterEndpoints(app);

app.Run();