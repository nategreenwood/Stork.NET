namespace Stork.NET.Core.Engine.Compilation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Runtime;

    public abstract class ExprAST : AST
    {
        public BinaryOperatorExprAST AsBinaryOperator()
        {
            return (BinaryOperatorExprAST)this;
        }

        public UnaryOperatorExprAST AsUnaryOperator()
        {
            return (UnaryOperatorExprAST) this;
        }

        public IntExprAST AsInt()
        {
            return (IntExprAST) this;
        }

        public FloatExprAST AsFloat()
        {
            return (FloatExprAST) this;
        }

        public abstract Expr Translate(Translator translator);

        public abstract Expr Assign(Translator translator, ExprAST value);

        public abstract Type TypeOf(Translator translator);
    }
}
