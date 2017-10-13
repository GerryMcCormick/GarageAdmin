﻿using GarageAdmin.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GarageAdmin.Persistance.Repositories {
    public class MechanicRepository : IMechanicRepository {

        private GarageModelContainer _context;

        public MechanicRepository(GarageModelContainer context) {
            _context = context;
        }

        public IEnumerable<Mechanic> GetMechanics() {
            return _context.Mechanics
                           .OrderBy(x => x.Surname);
        }
    }
}
