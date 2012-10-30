using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class Translator
    {
        private Gamma _global;

        public Translator()
        {
            _global = new Gamma();
            _global.AddType("Int", Type.INT);
            _global.AddType("Float", Type.FLOAT);
        }

        protected Gamma GetGlobe()
        {
            return _global;
        }

        #region STATEMENT TRANSLATION

        public Stmt Translate(EvalStmtAST ast)
        {
            return new object() as Stmt;
        }


        public Stmt Translate(DeclareStmtAST ast)
        {
            return new object() as Stmt;
        }

        #endregion

        #region EXPRESSION TRANSLATION

        public Expr Translate(ExprAST expr)
        {
            return new object() as Expr;
        }

        public Expr Assign(ExprAST exprAST, ExprAST value)
        {
            return new object() as Expr;
        }

        public Type TypeOf(ExprAST exprAST)
        {
            return new object() as Type;
        }

        public Type Eval(TypeExpr typeExpr)
        {
            return new object() as Type;
        }

        #endregion

        #region TYPE EVALUATION

        #endregion

        #region UTILITY

        #endregion
    }
}
