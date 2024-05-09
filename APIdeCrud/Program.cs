using APIdeCrud.Data;
using APIdeCrud.Repositorios;
using APIdeCrud.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using Microsoft.Extensions.Options;

namespace APIdeCrud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDBContex>(
                    options => options.UseMySQL(builder.Configuration.GetConnectionString("conexaoMySQL"))
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRespositorio>();

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
