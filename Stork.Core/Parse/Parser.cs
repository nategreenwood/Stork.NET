namespace Stork.NET.Core.Parse
{
    using System;

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
            throw new NotImplementedException();
        }

        protected Expr Expr2()
        {
            throw new NotImplementedException();
        }

        protected Expr Expr3()
        {
            throw new NotImplementedException();
        }

        protected Expr Expr4()
        {
            throw new NotImplementedException();
        }

        protected Expr Value()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            if(_tokenizer != null)
                _tokenizer.Close();
        }

        #endregion
    }
}
