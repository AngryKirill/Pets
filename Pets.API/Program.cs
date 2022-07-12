using Microsoft.EntityFrameworkCore;
using Pets.API.Mappers;
using Pets.BLL.Interfaces;
using Pets.BLL.Mappers;
using Pets.BLL.Services;
using Pets.DAL.Contexts;
using Pets.DAL.Interfaces;
using Pets.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddAutoMapper(typeof(ViewModelProfile), typeof(ModelProfile));  
builder.Services.AddDbContext<PetsContext>(options => options.UseSqlServer(connection));

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
