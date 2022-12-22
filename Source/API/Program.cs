using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using OCBManager.API.Extensions;
using OCBManager.API.FileReaders;
using OCBManager.Data.Data;
using OCBManager.Data.Stores;
using OCBManager.Domain.FileStorage;
using OCBManager.Domain.Import;
using OCBManager.Domain.Parsing;
using OCBManager.Domain.Stores;

namespace OCBManager.API
{
    public class Program
    {
        private const string OCBConnectionString = "OCB";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OCBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString(OCBConnectionString), 
                    opts => opts.MigrationsAssembly("OCBManager.API")));

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBoundaryLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });

            builder.Services.AddScoped<IFormFileReader, FormFileReader>();
            builder.Services.AddScoped<IOCBImporter, OCBImporter>();
            builder.Services.AddScoped<IFileStorage, FileStorage>();
            builder.Services.AddScoped<ISheetParser, ExcelParser.Parsers.ExcelParser>();
            builder.Services.AddScoped<ITurnoverSheetStore, TurnoverSheetStore>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

            app.MapControllers();
            app.UseGlobalExceptionHandling();

            app.Run();
        }
    }
}