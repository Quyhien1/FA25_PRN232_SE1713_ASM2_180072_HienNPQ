using HotChocolate.Types;
using OEMEVWarrantyManagementSystem.GraphQl.WebAPI.HienNPQ.GraphQl;
using OEMEVWarrantyManagementSystem.Service.HienNPQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<Mutations>(); // <-- Add this

// GraphQL
builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()// Wire up your query resolvers
    .AddMutationType<Mutations>() // Wire up your mutation resolvers
    .BindRuntimeType<DateTime, DateTimeType>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// GraphQL endpoint
app.MapGraphQL();

app.Run();
