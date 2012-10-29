namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class Parser
    {
        #region Fields/Properties

        private readonly Tokenizer _tokenizer;
        public Tokenizer Tokens
        {
            get { return _tokenizer; }
        }

        #endregion

        #region Ctors

        public Parser(Tokenizer tokens)
        {
            _tokenizer = tokens;
        }

        #endregion

        #region Member Methods

        public Expr Expr()
        {
            return Expr1();
        }

        protected Expr Expr1()
        {
            Expr result = Expr2();

            return result;
        }

        protected Expr Expr2()
        {
            Expr result = Expr3();

            return result;
        }

        protected Expr Expr3()
        {
            Expr result = null;

            return result;
        }

        protected Expr Expr4()
        {
            return Value();
        }

        protected Expr Value()
        {
            Expr result = null;


            return result;
        }

        public void Close()
        {
            if(_tokenizer != null)
                _tokenizer.Close();
        }

        #endregion
    }
}
