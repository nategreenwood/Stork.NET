using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Expressions
{
    public sealed class FloatExpr : Expr
    {
        private readonly float _value;
        public float Value
        {
            get { return _value; }
        }

        public FloatExpr(float value)
        {
            _value = value;
        }
    }
}
