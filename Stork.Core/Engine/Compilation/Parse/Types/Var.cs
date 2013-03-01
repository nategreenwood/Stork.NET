using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public class Var : TokenType
    {
        public Var()
            : base(MetaType.Keyword, "var")
        {
        }
    }
}
