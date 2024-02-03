using Microsoft.EntityFrameworkCore;
using SegurosCrecerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder => builder
//            .WithOrigins("http://localhost:300") // Reemplaza esto con el origen correcto
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials());
//});

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddDbContext<SegurosCrecerContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-LKJ3L4T\\SQLEXPRESS;Initial Catalog=SegurosCrecer;Integrated Security=True;TrustServerCertificate=True"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    //NextJs
    options.AddPolicy("clientApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("clientApp");

app.Run();
