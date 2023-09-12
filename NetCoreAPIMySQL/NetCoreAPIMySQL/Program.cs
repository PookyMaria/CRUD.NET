
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Data;
using NetCoreAPIMySQL.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConection"));
builder.Services.AddSingleton(mySQLConfiguration);

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySQLConection")));

builder.Services.AddScoped<ICarsRepositorie, CarsRepository>();

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
