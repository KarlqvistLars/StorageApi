using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;


namespace StorageApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("StorageApiContext") ?? throw new InvalidOperationException("Connection string 'StorageApiContext' not found.");

            builder.Services.AddDbContext<StorageApiContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddMvc();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Storage API",
                    Description = "An ASP.NET Core Web API for managing storage products",
                    Contact = new OpenApiContact {
                        Name = "Lars Karlqvist",
                        Email = "info@mail.com"
                    }
                });
            });

            builder.Services.AddDbContext<StorageApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StorageApiContext")));

            builder.Services
                .AddControllers()
                .AddNewtonsoftJson();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
