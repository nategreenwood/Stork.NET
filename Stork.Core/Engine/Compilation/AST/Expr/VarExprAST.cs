using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class VarExprAST : ExprAST
    {
        private string _name;

        public VarExprAST(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        #region ExprAST Members

        public override Expr Translate(Translator translator)
        {
            return translator.Translate(this);
        }

        public override Expr Assign(Translator translator, ExprAST value)
        {
            return translator.Assign(this, value);
        }

        public override Type TypeOf(Translator translator)
        {
            return translator.TypeOf(this);
        }

        #endregion
    }
}
