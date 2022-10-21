using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Repositories;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Asientos.registrarAsientos {
	public class RegistrarAsientoHandler : IRequestHandler<RegistrarAsientoCommand, bool> {
		private readonly IAsientoRepository _asientoRepository;
		private readonly ILogger<RegistrarAsientoHandler> _logger;
		private readonly IAsientoFactory _asientoFactory;
		private readonly IUnitOfWork _unitOfWork;

		public RegistrarAsientoHandler(IAsientoRepository asientoRepository, ILogger<RegistrarAsientoHandler> logger, IAsientoFactory asientoFactory, IUnitOfWork unitOfWork) {
			_asientoRepository = asientoRepository;
			_logger = logger;
			_asientoFactory = asientoFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(RegistrarAsientoCommand request, CancellationToken cancellationToken) {
			bool resp = false;
			try
			{
				var objAsientos = request;
				if (objAsientos is null)
				{
					throw new BussinessRuleValidationException("No se encontro asientos");
				}

				for (int i = 0; i < objAsientos.NroAsientos; i++)
				{
					var nroAsiento = "A-00" + i + 1;
					Asiento objAsiento = _asientoFactory.Create(nroAsiento, objAsientos.AvionId, objAsientos.VueloId);
					await _asientoRepository.CreateAsync(objAsiento);
					await _unitOfWork.Commit();
					resp = true;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al registrar la anulacion");
				throw new BussinessRuleValidationException(ex.Message);
			}

			return resp;
		}
	}
}
