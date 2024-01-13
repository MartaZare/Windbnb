using Windbnb.WebApi.Clients;
using Windbnb.WebApi.Interfaces;
using Windbnb.WebApi.Middlewares;
using Windbnb.WebApi.Repositories;
using Windbnb.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Windbnb.WebApi.Contexts;
using OwnerStore.WebApi.csproj.Services;
using System.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = builder.Configuration["MySecrets:PostgreConnection"] ?? throw new ArgumentNullException("Connection string not found.");
builder.Services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));

builder.Services.AddDbContext<DataContext>(o => o.UseNpgsql(dbConnectionString));
builder.Services.AddTransient<IApartmentService, ApartmentService>();
builder.Services.AddTransient<IApartmentRepository, ApartmentRepository>();
builder.Services.AddTransient<IOwnerService, OwnerService>();
builder.Services.AddTransient<IOwnerRepository, OwnerRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRentalHistoryRepository, RentalHistoryRepository>();
builder.Services.AddHttpClient<IJsonPlaceholderClient, JsonPlaceholderClient>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();