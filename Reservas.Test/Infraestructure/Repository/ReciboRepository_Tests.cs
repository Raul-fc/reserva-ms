using Microsoft.EntityFrameworkCore;
using Moq;
using Reservas.Domain.Model.Pagos;
using Reservas.Infraestructure.EF.Repository;
using System.Linq;
using Xunit;

namespace Reservas.Test.Infraestructure.Repository {
	public class ReciboRepository_Tests {
		private readonly Mock<DbSet<Recibo>> _reservaRepository;
		[Fact]
		public void CreateAsync_Tests() {

		}
	}
}
