using GraphQLSample.Data;
using GraphQLSample.GraphQL.Mutation;
using GraphQLSample.GraphQL.Query;
using GraphQLSample.GraphQL.Subscription;
using GraphQLSample.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("GraphQLSample"));

builder.Services.AddGraphQLServer()
    .AddQueryType<ProductQueries>()
    .AddMutationType<ProductMutations>()    
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
app.UseWebSockets();
app.MapGraphQL();

app.UseAuthorization();

app.MapControllers();

app.Run();
