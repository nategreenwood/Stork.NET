using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Exception
{
    public class InternalStorkNetException : StorkNetException
    {
        public InternalStorkNetException(string message) : base(message)
        {
        }
    }
}
