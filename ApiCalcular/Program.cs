var builder = WebApplication.CreateBuilder(args);

// Agrega servicios para controladores
builder.Services.AddControllers();

// Agrega y configura Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Usa los controladores (como AreaController)
app.MapControllers();

app.Run();
