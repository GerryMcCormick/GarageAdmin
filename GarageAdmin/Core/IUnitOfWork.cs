using GarageAdmin.Core.Repositories;

namespace GarageAdmin.Core {
    interface IUnitOfWork {
        ICarRepository Cars { get; }
        IMechanicRepository Mechanics { get; }
        IServiceRepository Services { get; }
    }
}
