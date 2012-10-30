using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Core.Exception;

    public class InternalCompilationStorkNetException : StorkNetException
    {
        public InternalCompilationStorkNetException(string s)
            : base(s)
        {

        }
    }
}
