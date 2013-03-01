using Stork.NET.Core.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Runtime
{
    public class InternalRuntimeStorkNetException : InternalStorkNetException
    {
        public InternalRuntimeStorkNetException(string message) : base(message)
        {
            
        }
    }
}
