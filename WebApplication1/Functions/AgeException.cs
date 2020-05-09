using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{

    [Serializable]
    public class AgeException : Exception
    {
        public AgeException() { }
        public AgeException(string message) : base(message) { }
        public AgeException(string message, Exception inner) : base(message, inner) { }
        protected AgeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
