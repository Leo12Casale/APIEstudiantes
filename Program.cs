using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Configure the services before calling builder.Build()

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configuracion para Validar Autenticacion.
builder.Services.AddAuthentication(options  =>
{
	options.DefaultAuthenticateScheme  =  JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme  =  JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options  =>
{
	// Agregar URL de su cuenta de Auth0 de cada uno.
	options.Authority = "https://dev-ihndiga48a7qj1ca.us.auth0.com/";
    options.Audience = "https://api.example.com/estudiantes";
});



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Estudiantes", Version = "v1" });
});

var app = builder.Build();

//Habilitamos Autenticacion.
app.UseAuthentication();

//Habilitamos Autorización. 
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Estudiantes");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
