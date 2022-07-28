using Amazon.SimpleEmail;
using AWS.SES.NET6.Interfaces;
using AWS.SES.NET6.Services;
using Serilog;

namespace AWS.SES.NET6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

            // Add services to the container.
            builder.Services
                .AddDefaultAWSOptions(builder.Configuration.GetAWSOptions())
                .AddAWSService<IAmazonSimpleEmailService>(ServiceLifetime.Scoped)
                .AddScoped<IEmailSender, EmailSender>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}