using AutoMapper;
using REST_API_Top_Articles.Models;
using REST_API_Top_Articles.Models.Dtos;
using REST_API_Top_Articles.Requests;
using REST_API_Top_Articles.Requests.Interfaces;
using REST_API_Top_Articles.Services;
using REST_API_Top_Articles.Services.Interfaces;
using Swashbuckle.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleRequest, ArticleRequest>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<Articles, ArticleDTO>();
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
