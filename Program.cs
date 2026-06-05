using Trabajo_PrimerParcial.Interfaces;
using Trabajo_PrimerParcial.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICamisetaService, CamisetaService>();
builder.Services.AddScoped<DatabaseService>();


string? mensaje = builder.Configuration["Tienda:Mensaje"];
Console.WriteLine(mensaje);

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