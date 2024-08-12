using Microsoft.EntityFrameworkCore;
using TreeNodeException.Api.Middlewares.Extensions;
using TreeNodeException.Api.Models;
using TreeNodeException.Api.Repositories;

namespace TreeNodeException.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<INodeRepository, NodeRepository>();
        builder.Services.AddScoped<ITreeRepository, TreeRepository>();
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers();
        
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

        app.UseException();

        app.Run();
    }
}