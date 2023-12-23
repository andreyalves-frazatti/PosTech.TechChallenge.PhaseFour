using FluentValidation;
using TechChallenge.Application.Commands.NewMessage;
using TechChallenge.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddGateways();
builder.Services.AddServices();

var rabbitMqOptions = new RabbitMqOptions();

builder.Configuration
    .GetSection(RabbitMqOptions.AppSettingsSection)
    .Bind(rabbitMqOptions);

builder.Services.AddConsumers(rabbitMqOptions);

builder.Services.AddScoped<IValidator<NewMessageCommand>, NewMessageCommandValidator>();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(NewMessageCommandHandler).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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