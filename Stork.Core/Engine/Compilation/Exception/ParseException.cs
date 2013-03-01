using Stork.NET.Core.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public class ParseException : InternalStorkNetException
    {
        public ParseException(string message) : base(message)
        {
            
        }
    }
}
