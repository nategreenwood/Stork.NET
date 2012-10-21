namespace Stork.NET.Core.Parse
{
    public class EoF : TokenType
    {
        public EoF()
            : base(MetaType.Operator, "$")
        {
        }
    }
}