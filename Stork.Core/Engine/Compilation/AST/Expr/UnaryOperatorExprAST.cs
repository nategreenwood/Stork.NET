using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class UnaryOperatorExprAST : ExprAST
    {
        public enum Operator
        {
            Positive,
            Negative
        }

        private readonly Operator _operator;

        public UnaryOperatorExprAST(Operator @operator, ExprAST child)
        {
            _operator = @operator;
            AddChild(child);
        }

        public Operator GetOperator()
        {
            return _operator;
        }

        public ExprAST GetChild()
        {
            return (ExprAST) GetChildren()[0];
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
