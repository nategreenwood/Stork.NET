namespace Stork.NET.Core.Engine.Runtime
{
    public sealed class FloatExpr : Expr
    {
        private readonly float _value;
        public float Value
        {
            get { return _value; }
        }

        public FloatExpr(float value)
        {
            _value = value;
        }
    }
}
