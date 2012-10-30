using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class BinaryOperatorExprAST : ExprAST
    {
        private Operator _operator;

        public BinaryOperatorExprAST(Operator @operator, ExprAST left, ExprAST right)
        {
            _operator = @operator;

            AddChild(left);
            AddChild(right);
        }

        public Operator GetOperator()
        {
            return _operator;
        }

        public ExprAST GetLeft()
        {
            return (ExprAST) GetChildren()[0];
        }

        public ExprAST GetRight()
        {
            return (ExprAST) GetChildren()[1];
        }

        #region Overrides of ExprAST

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

        public enum Operator
        {
            Plus,
            Minus,
            Times,
            Divide,
            Mod,
            EQ
        }
    }
}
