using flamingoflights.Data;
using Microsoft.EntityFrameworkCore;

namespace flamingoflights
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddDbContext<FlightContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

      builder.Services.AddCors(options =>
      {
        options.AddPolicy("AllowAngularApp", policy =>
        {
          policy.WithOrigins("http://localhost:4200") 
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
      });

      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      app.UseCors("AllowAngularApp");

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
