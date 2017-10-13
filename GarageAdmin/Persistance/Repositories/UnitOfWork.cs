using GarageAdmin.Core;
using GarageAdmin.Core.Repositories;

namespace GarageAdmin.Persistance.Repositories {
    public class UnitOfWork : IUnitOfWork {

        private GarageDbContext _context;

        public ICarRepository Cars { get; }
        public IInvoiceRepository Invoices { get; }
        public IMechanicRepository Mechanics { get; }
        public IServicePartRepository ServiceParts { get; }
        public IServiceRepository Services { get; }

        public UnitOfWork(GarageDbContext context) {
            _context = context;

            Cars = new CarRepository(_context);
            Invoices = new InvoiceRepository(_context);
            Mechanics = new MechanicRepository(_context);
            ServiceParts = new ServicePartRepository(_context);
            Services = new ServiceRepository(_context);
        }
    }
}
