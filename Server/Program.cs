
//��"�

using Bl;
using BL.Api;

namespace Server
{

    public class Program
    {


        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IBl,BLManager>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(c => c.AddPolicy("AllowAll",
             option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            //������ ���� ����� � app
         

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseCors("AllowAll");
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