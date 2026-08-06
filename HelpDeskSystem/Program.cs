using HelpDeskAPI.Models;
using HelpDeskAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var ConnectionString = builder.Configuration.GetConnectionString("HelpDeskConnection");
            builder.Services.AddDbContext<TicketDbContext>(
                options=>options.UseSqlServer(ConnectionString));

            builder.Services.AddScoped<ITicketRepository, TicketRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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
