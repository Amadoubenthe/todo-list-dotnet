using Microsoft.EntityFrameworkCore;
using TodoList.BusinessLogic.Interfaces;
using TodoList.BusinessLogic.Services;
using TodoList.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoApiDbContext")));

builder.Services.AddScoped<ITodo, TodoService>();

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
