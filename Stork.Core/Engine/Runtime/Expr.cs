namespace Stork.NET.Core.Engine.Runtime
{
    using Stork.NET.Core.Engine.Compilation;

    public abstract class Expr : AST
    {
        public BinaryOperatorExpr AsBinaryOperator()
        {
            return (BinaryOperatorExpr)this;
        }
    }
}
