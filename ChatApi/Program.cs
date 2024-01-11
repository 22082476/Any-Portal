using ChatApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
// Add services to the container.

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins(
                    "http://localhost:5086/", // URL van je lokale ontwikkelingsserver
                    "http://localhost:3000/",
                    "https://22082476.github.io/" // GitHub Pages URL
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
    });


builder.Services.AddControllers();
builder.Services.AddDbContext<ChatContext>((options) => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
