using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Runtime
{
    public abstract class Stmt
    {
        public abstract object Exec(Scope scope);
    }
}
