using Pets.API.Mappers;
using Pets.API.Middlewares;
using Pets.BLL.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBLLServices(builder.Configuration);

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(ViewModelProfile), typeof(ModelProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandler>();

app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapControllers();

app.Run();
