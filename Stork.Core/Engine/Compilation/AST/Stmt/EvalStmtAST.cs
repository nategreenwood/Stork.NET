using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class EvalStmtAST : StmtAST
    {
        private ExprAST _expr;

        public EvalStmtAST(ExprAST expr)
        {
            _expr = expr;
        }

        public ExprAST GetExpr()
        {
            return _expr;
        }

        #region Overrides of StmtAST

        public override Stmt Translate(Translator translator)
        {
            return translator.Translate(this);
        }

        #endregion
    }
}
