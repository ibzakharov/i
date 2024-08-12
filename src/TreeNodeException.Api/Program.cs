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

        Console.WriteLine("Start apply migrations");
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred applying migrations: {ex.Message}");
            }
        }
        Console.WriteLine("Finish apply migrations");

        app.UseRedirectToSwagger();
        app.UseException();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}