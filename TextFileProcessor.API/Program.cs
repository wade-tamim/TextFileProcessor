using Microsoft.EntityFrameworkCore;
using TexFileProcessor.Core.AutoMapper;
using TexFileProcessor.Core.Interfaces;
using TexFileProcessor.Core.Repository;
using TexFileProcessor.Core.Services;
using TextFileProcessor.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileProcessorServices, FileProcessorServices>();
builder.Services.AddAutoMapper(typeof(DataMappingProfile).Assembly);
builder.Services.AddScoped<IProcessedFileRepository, ProcessedFileRepository>();
builder.Services.AddDbContext<TextFileProcessorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TextFileProcessorDB")));

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