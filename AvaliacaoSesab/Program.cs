using AvaliacaoSesab.Data;
using AvaliacaoSesab.Helper;
using AvaliacaoSesab.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoSesab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlite(
              builder.Configuration.GetConnectionString("DefaultConnection")
              ));
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
            builder.Services.AddScoped<IStatRepository, StatRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            


            builder.Services.AddScoped<ISessionUser, SessionUser>();

            builder.Services.AddCors();

            // Add services to the container.

            builder.Services.AddControllers();


           

            var app = builder.Build();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()) ;

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

           
            app.MapControllers();

            app.Run();
        }
    }
}