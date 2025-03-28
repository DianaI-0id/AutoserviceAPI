using AutoserviceAPI.Infrastructure.Repositories.Repositories;
using AutoserviceAPI.Infrastructure.Repositories;
using Supabase.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using DotNetEnv;

var dotenv = Path.Combine(Directory.GetCurrentDirectory(), ".env");
Env.Load(dotenv);


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Настройки Supabase
var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

// Инициализация клиента Supabase
var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};
builder.Services.AddSingleton<ISupabaseClient>(new SupabaseClient(supabaseUrl, supabaseKey, options));

builder.Services.AddTransient<IClientRepository, ClientRepository>();

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

// Интерфейс для клиента Supabase
public interface ISupabaseClient
{
    Supabase.Client Client { get; }
}

// Реализация клиента Supabase
public class SupabaseClient : ISupabaseClient
{
    public SupabaseClient(string url, string key, Supabase.SupabaseOptions options = null)
    {
        Client = new Supabase.Client(url, key, options);
    }

    public Supabase.Client Client { get; }
}
