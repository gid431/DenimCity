using dc_repository.Context;
using dc_repository.Entities;
using dc_repository.interfaces;
using dc_repository.repositories;
using dc_service.interfaces;
using dc_service.services;
using Microsoft.EntityFrameworkCore;


namespace dc_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DcContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            AddServices(builder.Services);

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

        private static void AddServices(IServiceCollection services)
        {
            //metodo che implementa l'interfaccia di irepository di categoria
            services.AddTransient<IRepository<Categoria>, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

        }
    }
}
