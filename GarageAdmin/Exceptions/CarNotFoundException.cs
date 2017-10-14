using System;
using System.Runtime.Serialization;

namespace GarageAdmin.Exceptions {
    class CarNotFoundException : Exception {
        public CarNotFoundException() : base() { }

        public CarNotFoundException(String message) : base(message) { }

        public CarNotFoundException(String message, Exception innerException) 
            : base(message, innerException) { }

        public CarNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
