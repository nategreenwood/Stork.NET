using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Exception
{
    public abstract class StorkNetException : ApplicationException
    {
        protected StorkNetException(string message)
            : base(message)
        {
            
        }
    }
}
