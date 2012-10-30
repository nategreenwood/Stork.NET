using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class IntExprAST : ExprAST
    {
        private long _value;

        public IntExprAST(long value)
        {
            _value = value;
        }

        public long GetValue()
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
