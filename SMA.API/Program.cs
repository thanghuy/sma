using Microsoft.Extensions.Options;
using SMA.API.Models.Config;
using SMA.Domain.Base;
using SMA.Domain.Interfaces.Repositories;
using SMA.Repository.Context;
using SMA.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);


//db

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongodbSetting"));
builder.Services.Configure<StaticFile>(builder.Configuration.GetSection("StaticFile"));

builder.Services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton<IMongoContext, MongoContext>();
builder.Services.AddSingleton<ISmaUserRepository, SmaUserRepository>();
builder.Services.AddSingleton<ISmaStaticFileRepository, SmaStaticFileRepository>();
//log
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpLogging();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
