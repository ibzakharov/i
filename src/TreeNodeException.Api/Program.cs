using Microsoft.EntityFrameworkCore;
using TreeNodeException.Api.Middlewares;
using TreeNodeException.Api.Middlewares.Extensions;
using TreeNodeException.Api.Models;
using TreeNodeException.Api.Repositories;

namespace TreeNodeException.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql("Host=desktop;Port=8001;Database=testdb;Username=postgres;Password=postgres"));

// Добавление DbContext в сервисы
        // builder.Services.AddDbContext<ApplicationDbContext>(options =>
        //     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        
        // builder.Services.AddScoped<ITreeRepository, TreeRepository>();
        builder.Services.AddScoped<INodeRepository, NodeRepository>();
        builder.Services.AddScoped<ITreeRepository, TreeRepository>();
        builder.Services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();

        builder.Services.AddAutoMapper(typeof(Program));

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
        
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.UseRedirect();
        app.UseException();
        
        app.Run();
    }
}