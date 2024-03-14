
using DevoraLime.Abstraction.Interfaces.Repositories;
using DevoraLime.Application.Services;
using DevoraLime.Application.Services.Interfaces;
using DevoraLime.Domain.Factories;
using DevoraLime.Domain.Factories.Interfaces;
using DevoraLime.Infrastructure.Repositories;

namespace DevoraLime.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IHeroFactory, RandomHeroFactory>();

            builder.Services.AddScoped<IBattleService, BattleService>();
            builder.Services.AddScoped<IArenaService, ArenaService>();
            builder.Services.AddScoped<IArenaRepository, ArenaRepository>();


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

            app.Run();
        }
    }
}
