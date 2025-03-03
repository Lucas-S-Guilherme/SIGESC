using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Entity Framework (DbContext)
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// 2. Configuração dos Controladores com JsonOptions
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.WriteIndented = true;
});

// 3. Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Configuração de JsonOptions global (opcional)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var app = builder.Build();

// 5. Configuração do Ambiente de Desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Middlewares
app.UseAuthentication(); // Habilita autenticação (se necessário)
app.UseAuthorization();  // Habilita autorização

// 7. Mapeamento dos Controladores
app.MapControllers();

// 8. Execução da Aplicação
app.Run();