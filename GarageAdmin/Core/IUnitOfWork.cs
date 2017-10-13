using GarageAdmin.Core.Repositories;

namespace GarageAdmin.Core {
    interface IUnitOfWork {
        ICarRepository Cars { get; }
        IInvoiceRepository Invoices { get; }
        IMechanicRepository Mechanics { get; }
        IServicePartRepository ServiceParts { get; }
        IServiceRepository Services { get; }
    }
}
