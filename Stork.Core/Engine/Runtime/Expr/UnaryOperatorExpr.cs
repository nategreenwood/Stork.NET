namespace Stork.NET.Core.Engine.Runtime
{
    public sealed class UnaryOperatorExpr : Expr
    {
        private readonly UnaryOperator _operator;
        public UnaryOperator Operator
        {
            get { return _operator; }
        }

        public Expr Child
        {
            get { return (Expr) GetChildren()[0]; }
        }

        public UnaryOperatorExpr(UnaryOperator @operator, Expr child)
        {
            _operator = @operator;
            AddChild(child);
        }
    }

    public class UnaryOperator
    {
        public static string Negative { get { return "-"; } }
        public static string Positive { get { return "+"; } }
    }
}
