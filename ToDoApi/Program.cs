using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Create;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Delete;
using ToDoApi.Application.ToDoCommandsQueries.Commands.Update;
using ToDoApi.Application.ToDoCommandsQueries.Queries.GetTodos;
using ToDoApi.Core.ToDoDtosProfiles.Profiles;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Data;
using ToDoApi.Infrastructure.Repositpry;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(7298); 
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader() 
              .AllowAnyMethod(); 
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(typeof(CreateTodoCommand).Assembly);
builder.Services.AddMediatR(typeof(UpdateTodoCommand).Assembly);
builder.Services.AddMediatR(typeof(DeleteTodoCommand).Assembly);
builder.Services.AddMediatR(typeof(GetTodosQuery).Assembly);

builder.Services.AddAutoMapper(typeof(TodoProfile).Assembly);

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
//builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddHttpContextAccessor();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//        c.RoutePrefix = string.Empty; 
//    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
