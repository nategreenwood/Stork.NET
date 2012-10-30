using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Runtime;

    public class DeclareStmtAST : StmtAST
    {
        private string _name;
        private TypeExpr _type;
        private ExprAST _init;

        public DeclareStmtAST(string name, TypeExpr type, ExprAST init)
        {
            _name = name;
            _type = type;
            _init = init;
        }

        public string GetName()
        {
            return _name;
        }

        public new TypeExpr GetType()
        {
            return _type;
        }

        public ExprAST GetInit()
        {
            return _init;
        }

        #region Overrides of StmtAST

        public override Stmt Translate(Translator translator)
        {
            return translator.Translate(this);
        }

        #endregion
    }
}
