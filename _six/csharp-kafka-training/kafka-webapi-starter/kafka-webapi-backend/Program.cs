// these namespaces have been added for you as part of the starter project
using kafka_webapi_backend.Models;
using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// TODO: add kafka configuration code
var producerConfig = new ProducerConfig();
builder.Configuration.Bind("ProducerConfig", producerConfig);
builder.Services.AddSingleton<ProducerConfig>(producerConfig);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();