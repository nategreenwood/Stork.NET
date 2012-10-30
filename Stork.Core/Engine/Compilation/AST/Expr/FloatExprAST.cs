using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class FloatExprAST : ExprAST
    {
        private double _value;

        public FloatExprAST(double value)
        {
            _value = value;
        }

        public double GetValue()
        {
            return _value;
        }

        #region ExprAST Members

        public override Expr Translate(Translator translator)
        {
            return translator.Translate(this);
        }

        public override Expr Assign(Translator translator, ExprAST value)
        {
            return translator.Assign(this, value);
        }

        public override Type TypeOf(Translator translator)
        {
            return translator.TypeOf(this);
        }

        #endregion
    }
}
