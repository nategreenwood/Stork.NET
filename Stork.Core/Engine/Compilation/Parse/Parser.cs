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



        public StmtAST Stmt()
        {
            StmtAST result = null;

            return result;
        }

        protected void Term()
        {
            if(Tokens.PeekType().GetText() == new EoF().GetText())
            {
                // Do nothing. EoF qualifies as statement terminator
            }
            else if(Tokens.PeekType().GetText() == new SemiColon().GetText())
            {
                // Semicolon is explicit statement terminator
                
            }
        }

        protected ExprAST Expr()
        {
            return Expr1();
        }

        protected ExprAST Expr1()
        {
            ExprAST result = Expr2();

            return result;
        }

        protected ExprAST Expr2()
        {
            ExprAST result = Expr3();

            return result;
        }

        protected ExprAST Expr3()
        {
            ExprAST result = null;

            return result;
        }

        protected ExprAST Expr4()
        {
            ExprAST result = null;

            return result;
        }
        
        public ExprAST Expr5()
        {
            return Value();
        }

        protected ExprAST Value()
        {
            ExprAST result = null;


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
