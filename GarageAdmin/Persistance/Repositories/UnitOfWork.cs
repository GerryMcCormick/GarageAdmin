using GarageAdmin.Core;
using GarageAdmin.Core.Repositories;

namespace GarageAdmin.Persistance.Repositories {
    public class UnitOfWork : IUnitOfWork {

        private GarageModelContainer _context;

        public ICarRepository Cars { get; }
        public IMechanicRepository Mechanics { get; }
        public IServiceRepository Services { get; }

        public UnitOfWork(GarageModelContainer context) {
            _context = context;

            Cars = new CarRepository(_context);
            Mechanics = new MechanicRepository(_context);
            Services = new ServiceRepository(_context);
        }
    }
}
