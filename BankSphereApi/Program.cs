using BankSphere.Api.Aplication.ExceptionHandler;
using BankSphere.Api.Aplication.Handlers.Client;
using BankSphere.Api.Middleware;
using BankSphere.Domain.Exceptions;
using BankSphere.Infrastructure;
using BankSphere.Infrastructure.Exceptions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClientHandler).Assembly));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseHttpsRedirection();

app.UseMiddleware<HandlerErrorMiddleware>(new Dictionary<Type, IExceptionHandler>
            {
                {typeof(ArgumentException), new ArgumentExceptionHandler() },
                {typeof(DomainException), new DomainExceptionHandler() },
                {typeof(InfraestructureException), new InfraestructureExceptionHandler() },
                {typeof(NotFoundException), new NotFoundExceptionHandler() }
            });

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
