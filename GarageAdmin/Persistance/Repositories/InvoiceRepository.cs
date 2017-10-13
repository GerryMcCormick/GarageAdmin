using GarageAdmin.Core.Repositories;
using System;
using System.Data.Entity;

namespace GarageAdmin.Persistance.Repositories {
    public class InvoiceRepository : IInvoiceRepository {

        private readonly GarageModelContainer _context;

        public InvoiceRepository(GarageModelContainer context) {
            _context = context;
        }

        public DbSet<Invoice> GetLatestInvoice(string carReg) {
            throw new NotImplementedException();
        }
    }
}
