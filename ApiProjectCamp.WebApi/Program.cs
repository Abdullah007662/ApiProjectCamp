using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Mapping;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiContext>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//Proje küçükse ve belirli profilleri kontrol etmek istiyorsan ? typeof(GeneralMapping) kullanýlmalýdýr
//Proje büyüyorsa ve birçok mapping profili varsa ? Assembly.GetExecutingAssembly() daha pratik oluyor.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
