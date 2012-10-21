namespace Stork.NET.Core.Expressions
{
    public sealed class BinaryOperatorExpr : Expr
    {
        private static BinaryOperator _operator;
        public BinaryOperator Operator
        {
            get { return _operator; }
        }

        public Expr LeftExpr
        {
            get { return (Expr)GetChildren()[0]; }
        }

        public Expr RightExpr
        {
            get { return (Expr)GetChildren()[1]; }
        }

        public BinaryOperatorExpr(BinaryOperator @operator, Expr left, Expr right)
        {
            _operator = @operator;
        }
    }

    public class BinaryOperator
    {
        public static string Plus
        {
            get { return "+"; }
        }

        public static string Minus
        {
            get { return "-"; }
        }

        public static string Times
        {
            get { return "*"; }
        }

        public static string Divide
        {
            get { return "/"; }
        }

        public static string Mod
        {
            get { return "%"; }
        }
    }
}
