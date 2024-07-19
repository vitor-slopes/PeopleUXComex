using Microsoft.Extensions.Configuration;
using PeopleUXComex.Application.Services;
using PeopleUXComex.Core.Interfaces;
using PeopleUXComex.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

// Adicionar servi�os do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PeopleUXComex API",
        Description = "API para o projeto PeopleUXComex"
    });
});

// L� a string de conex�o do arquivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Testa a conex�o com o banco de dados
try
{
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Conex�o bem-sucedida com o banco de dados.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
}

// Registra o DbContext no sistema de DI
builder.Services.AddDbContext<PeopleUXComexContext>(options =>
    options.UseSqlServer(connectionString));

// Registra PersonRepository e AddressRepository no sistema de DI
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

// Registra PersonService e AddressService no sistema de DI
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<AddressService>();

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeopleUXComex API V1");
    c.RoutePrefix = "swagger"; // Para acessar o Swagger UI na raiz do site (http://localhost:<porta>/)
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Atualize a rota padr�o para abrir PersonView/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PersonView}/{action=Index}/{id?}");

app.Run();
