using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{

    [Serializable]
    public class GenderException : Exception
    {
        public GenderException() { }
        public GenderException(string message) : base(message) { }
        public GenderException(string message, Exception inner) : base(message, inner) { }
        protected GenderException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
