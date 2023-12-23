using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TechChallenge.Application.Gateways;
using TechChallenge.Application.Services;
using TechChallenge.Infrastructure.Consumers;
using TechChallenge.Infrastructure.Gateways;
using TechChallenge.Infrastructure.Services;

namespace TechChallenge.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageService, MessageService>();
    }

    public static void AddGateways(this IServiceCollection services)
    {
        services.AddScoped<IMessageGateway, MessageGateway>();
    }

    public static void AddConsumers(this IServiceCollection services, RabbitMqOptions rabbitMqOptions)
    {
        services.AddMassTransit(c =>
        {
            c.AddConsumer<MessageConsumer>();
            
            c.UsingRabbitMq((context, configure) =>
            {
                configure.Host(host: rabbitMqOptions.Host, virtualHost: rabbitMqOptions.VirtualHost, configure: o =>
                {
                    o.Username(rabbitMqOptions.Username);
                    o.Password(rabbitMqOptions.Password);
                });

                configure.ReceiveEndpoint(rabbitMqOptions.QueueName, e => { e.Consumer<MessageConsumer>(context); });
            });
        });
    }

    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDb");

        services.AddScoped<IMongoClient>(_ => new MongoClient(connectionString));
    }
}