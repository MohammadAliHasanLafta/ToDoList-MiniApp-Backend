using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Delete;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Update;
using ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;
using ToDoApi.Core.ToDoDtosProfiles.Profiles;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Data;
using ToDoApi.Infrastructure.Repositpry;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(typeof(CreateTodoCommand).Assembly);
builder.Services.AddMediatR(typeof(UpdateTodoCommand).Assembly);
builder.Services.AddMediatR(typeof(DeleteTodoCommand).Assembly);
builder.Services.AddMediatR(typeof(GetTodosQuery).Assembly);

builder.Services.AddAutoMapper(typeof(TodoProfile).Assembly);

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

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
