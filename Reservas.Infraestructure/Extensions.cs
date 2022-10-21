using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Application;
using Reservas.Application.UseCases.Consumers;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Reservas.Infraestructure {
	[ExcludeFromCodeCoverage]
	public static class Extensions {
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
			services.AddApplication();
			services.AddMediatR(Assembly.GetExecutingAssembly());

			var connectionString =
				configuration.GetConnectionString("ReservaDbConnectionString");

			services.AddDbContext<ReadDbContext>(context =>
				context.UseSqlServer(connectionString));
			services.AddDbContext<WriteDbContext>(context =>
				context.UseSqlServer(connectionString));


			services.AddScoped<IReservaRepository, ReservaRepository>();
			services.AddScoped<IAsientoRepository, AsientoRepository>();
			services.AddScoped<IPagoRepository, PagoRepository>();
			services.AddScoped<IFacturaRepository, FacturaRepository>();
			services.AddScoped<IReciboRepository, ReciboRepository>();
			services.AddScoped<IReservaAnuladoRepository, ReservaAnuladoRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			AddRabbitMq(services, configuration);

			return services;
		}

		private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration) {
			var rabbitMqHost = configuration["RabbitMq:Host"];
			var rabbitMqPort = configuration["RabbitMq:Port"];
			var rabbitMqUserName = configuration["RabbitMq:UserName"];
			var rabbitMqPassword = configuration["RabbitMq:Password"];

			services.AddMassTransit(config => {
				config.AddConsumer<VueloRegistradoConsumer>().Endpoint(endpoint => endpoint.Name = VueloRegistradoConsumer.QueueName);
				config.AddConsumer<CheckinConfirmadoConsumer>().Endpoint(endpoint => endpoint.Name = CheckinConfirmadoConsumer.QueueName);

				config.UsingRabbitMq((context, cfg) => {
					var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
					cfg.Host(uri);

					cfg.ReceiveEndpoint(VueloRegistradoConsumer.QueueName, endpoint => {
						endpoint.ConfigureConsumer<VueloRegistradoConsumer>(context);
					});
					cfg.ReceiveEndpoint(CheckinConfirmadoConsumer.QueueName, endpoint => {
						endpoint.ConfigureConsumer<CheckinConfirmadoConsumer>(context);
					});
				});
			});
		}

	}
}
