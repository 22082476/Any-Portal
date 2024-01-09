using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Expressions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration;

builder.Services.AddDbContext<UserContext>((options) => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IResearchApiService, ResearchApiService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// builder.Services.AddHttpContextAccessor();

 //add service voor de zelfde gemaakte logger ILogger;
// builder.Services.AddSingleton(sp =>
//     {
//         var logger = sp.GetRequiredService<ILog<AdminLogger>>();
//         return new AdminLogger(config.GetConnectionString("LogFileSource"));
//     });

builder.Services.AddScoped<IResearchApiService, ResearchApiService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHsts();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();