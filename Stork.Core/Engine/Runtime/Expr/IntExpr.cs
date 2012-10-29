namespace Stork.NET.Core.Engine.Runtime
{
    public sealed class IntExpr : Expr
    {
        private readonly long _value;
        public long Value
        {
            get { return _value; }
        }

        public IntExpr(long value)
        {
            _value = value;
        }
    }
}
