using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Model;
using Play.Catalog.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddTransient<IItemService,ItemService>();
builder.Services.Configure<Settings>(options =>
    {
        options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.Database = configuration.GetSection("MongoConnection:Database").Value;
    });
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

app.Run();
