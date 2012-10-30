using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class Translator
    {
        public Translator()
        {
            
        }

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
    }
}
