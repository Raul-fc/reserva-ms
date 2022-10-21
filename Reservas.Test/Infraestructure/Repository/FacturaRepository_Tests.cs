using Microsoft.EntityFrameworkCore;
using Moq;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Infraestructure.Repository {
	public class FacturaRepository_Tests {
		public readonly Mock<DbSet<Factura>> _factura;
		public readonly Mock<WriteDbContext> _context;
		public FacturaRepository_Tests() {
			_factura = new Mock<DbSet<Factura>>();
			_context = new Mock<WriteDbContext>();
		}

		[Fact]
		public void GetAllVolunteersMethodWorks() {
			//var pagoIdTest = Guid.NewGuid();
			//var nroFacturaTest = "F-001";
			//var importedTest = 100;

			//var objFactura = new Factura(pagoIdTest, nroFacturaTest, importedTest);
			//var aaaa = new FacturaRepository(_context.Object);

			//var repositoryMock = new Mock<IFacturaRepository>();
			//repositoryMock
			//	.Setup(r => r.CreateAsync(objFactura))
			//	.Returns(Task.FromResult(objFactura));



			//var result = objRepository.CreateAsync(objFactura);
			/*
			var pagoIdTest = Guid.NewGuid();
			var nroFacturaTest = "F-001";
			var importedTest = 100;
		
			var objFactura = new Factura(pagoIdTest, nroFacturaTest, importedTest);
			// Arrange
			var repositoryMock = new Mock<IFacturaRepository>();
			repositoryMock
				.Setup(r => r.CreateAsync(objFactura))
				.Returns(Task.FromResult(objFactura));


			Assert.NotNull(objFactura);
			*/
		}

		/*
        private readonly Mock<IFacturaRepository> _repositoryFactura;

        public FacturaRepository_Tests()
        {
            _repositoryFactura = new Mock<IFacturaRepository>();
        }
        [Fact]
        public void FacturaCreateRepository()
        {
            var pagoIdTest = Guid.NewGuid();
            var nroFacturaTest = "F-0001";
            var importeTest = 100;
            var objreservaTest = new Factura(pagoIdTest, nroFacturaTest, importeTest);

            _repositoryFactura.Setup(mock => mock.CreateAsync(objreservaTest)).Returns(Task.FromResult(objreservaTest));

            Assert.NotNull(objreservaTest);

        }

        [Fact]
        public void FacturaFindByIdAsyncRepository()
        {
            var factoryIdTest = Guid.NewGuid();


            var pagoIdTest = Guid.NewGuid();
            var nroFacturaTest = "F-0001";
            var importeTest = 100;
            var objreservaTest = new Factura(pagoIdTest, nroFacturaTest, importeTest);

            _repositoryFactura.Setup(mock => mock.FindByIdAsync(factoryIdTest)).Returns(Task.FromResult(objreservaTest));

            Assert.NotNull(objreservaTest);

        }
        */
	}
}
