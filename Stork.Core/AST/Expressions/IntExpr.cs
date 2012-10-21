using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Expressions
{
    public sealed class IntExpr : Expr
    {
        private readonly long _value;
        public long Value
        {
            get { return _value; }
        }

        public IntExpr(long value)
        {
            _value = value;
        }
    }
}
