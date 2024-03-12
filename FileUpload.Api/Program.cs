using FileUpload.Context;
using FileUpload.Repositories;
using FileUpload.Repositories.Interfaces;
using FileUpload.Services;
using FileUpload.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// database connection string
builder.Services.AddDbContext<FileUploadDbContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=FileUploadDatabase;Trusted_Connection=True;");
});
builder.Services.AddScoped<ITextFileRepository, TextFileRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<ITextFileService, TextFileService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
