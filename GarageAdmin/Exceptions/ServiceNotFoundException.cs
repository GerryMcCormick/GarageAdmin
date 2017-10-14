using System;
using System.Runtime.Serialization;

namespace GarageAdmin.Exceptions {
    class ServiceNotFoundException : Exception {
        public ServiceNotFoundException() : base() { }

        public ServiceNotFoundException(String message) : base(message) { }

        public ServiceNotFoundException(String message, Exception innerException) 
            : base(message, innerException) { }

        public ServiceNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
