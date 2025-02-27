using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;

var builder = WebApplication.CreateBuilder(args); // ok

builder.Services.AddControllers().AddJsonOptions(x =>
   {
       x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
       x.JsonSerializerOptions.WriteIndented = true;
   }); //ok
   
builder.Services.AddEndpointsApiExplorer(); //ok

builder.Services.AddSwaggerGen(); //ok

var app = builder.Build(); // ok

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Busca string de conex�o e adiciona a classe AppDbContext Service do EF
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run(); //ok

