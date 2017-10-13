using System.Data.Entity;

namespace GarageAdmin.Core.Repositories {
    public interface IInvoiceRepository {
        DbSet<Invoice> GetLatestInvoice(string carReg);
    }
}
