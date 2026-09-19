using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;
using WebAPI.Database;
using WebAPI.Middlewares;
using WebAPI.Services;
using WebAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<ExpenseValidators>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection"))
);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.WriteAsync("Server is up an running!");
});

app.MapControllers();

app.Run();
