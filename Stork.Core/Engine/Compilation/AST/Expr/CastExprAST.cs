using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class CastExprAST : ExprAST
    {
        private TypeExpr _type;
        private ExprAST _expr;

        public CastExprAST(TypeExpr type, ExprAST expr)
        {
            _type = type;
            _expr = expr;
        }

        public new TypeExpr GetType()
        {
            return _type;
        }

        public ExprAST GetExpr()
        {
            return _expr;
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
