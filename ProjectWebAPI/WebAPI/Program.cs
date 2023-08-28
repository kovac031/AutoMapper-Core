
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using Service.Common;
using Service;
using Repository;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // DBcontext -----------------------------------------
            builder.Services.AddDbContext<JustStudentsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBconnection")));
            // -----------------------------------------------

            // dependency injection
            builder.Services.AddScoped<IService, StudentService>();
            builder.Services.AddScoped<IRepository, StudentRepository>();
            // ------------------------------------------------

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
