using BingoBlitz_GameService;
using IO.Ably;
using DotNetEnv.Configuration;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
builder.Configuration.AddDotNetEnv();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(app => app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<Connector>(provider =>
    {
        IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
        IConfigurationSection rabbitMQ = configuration.GetRequiredSection("RabbitMQ");
        return new Connector(
            userName: rabbitMQ.GetValue<string>("UserName"),
            password: rabbitMQ.GetValue<string>("Password"),
            virtualHost: rabbitMQ.GetValue<string>("VirtualHost"),
            hostName: rabbitMQ.GetValue<string>("HostName"),
            port: rabbitMQ.GetValue<int>("Port")
        );
    });
    services.AddScoped<AblyRest>(provider =>
    {
        return new AblyRest(builder.Configuration.GetValue<string>("ABLY_API_KEY"));
    });
}