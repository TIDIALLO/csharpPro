using GraphQL.Server; // GraphQLOptions
using Northwind.GraphQL; // GreetQuery, NorthwindSchema
using Packt.Shared; // AddNorthwindContext extension method

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddNorthwindContext();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.WebHost.UseUrls("https://localhost:5005/");

builder.Services.AddScoped<NorthwindSchema>();
builder.Services.AddGraphQL()
 .AddGraphTypes(typeof(NorthwindSchema), ServiceLifetime.Scoped)
 .AddDataLoader()
 .AddSystemTextJson(); // serialize responses as JSON
// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (builder.Environment.IsDevelopment())
{
 app.UseGraphQLPlayground(); // default path is /ui/playground
}
app.UseGraphQL<NorthwindSchema>(); // default path is /graphql
app.UseHttpsRedirection();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
