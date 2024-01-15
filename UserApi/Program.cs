using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration;

builder.Services.AddDbContext<UserContext>((options) => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IResearchApiService, ResearchApiService>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins(
                    "http://localhost:5177", // URL van je lokale ontwikkelingsserver
                    "http://localhost:5173", // Andere URL van je lokale ontwikkelingsserver
                    "http://localhost:3000",
                    "https://22082476.github.io" // GitHub Pages URL
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
    });


builder.Services.AddScoped<ILog, AdminLogger>();

builder.Services.AddScoped<IResearchApiService, ResearchApiService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 app.UseHttpsRedirection();

app.UseHsts();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();