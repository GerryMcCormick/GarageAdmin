using System;
using System.Runtime.Serialization;

namespace GarageAdmin.Exceptions {
    class InvalidRegException : Exception {

        public InvalidRegException() : base() { }

        public InvalidRegException(String message) : base(message) { }

        public InvalidRegException(String message, Exception innerException) 
            : base(message, innerException) { }

        public InvalidRegException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
