namespace Stork.NET.Core
{
    using Stork.NET.Core.Expressions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Expr : AST
    {
        public BinaryOperatorExpr AsBinaryOperator()
        {
            return (BinaryOperatorExpr)this;
        }
    }
}
