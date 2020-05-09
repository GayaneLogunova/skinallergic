using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{

    [Serializable]
    public class DiseaseException : Exception
    {
        public DiseaseException() { }
        public DiseaseException(string message) : base(message) { }
        public DiseaseException(string message, Exception inner) : base(message, inner) { }
        protected DiseaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
