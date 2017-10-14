using System;
using System.Runtime.Serialization;

namespace GarageAdmin.Exceptions {
    class MechanicNotFoundException : Exception {
        public MechanicNotFoundException() : base() { }

        public MechanicNotFoundException(String message) : base(message) { }

        public MechanicNotFoundException(String message, Exception innerException) 
            : base(message, innerException) { }

        public MechanicNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
