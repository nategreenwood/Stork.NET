namespace Stork.NET.Core.Engine.Compilation
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using Runtime;

    public abstract class StmtAST : AST
    {
        public EvalStmtAST AsEval()
        {
            return (EvalStmtAST)this;
        }

        public DeclareStmtAST AsDeclare()
        {
            return (DeclareStmtAST)this;
        }

        public abstract Stmt Translate(Translator translate);
    }
}
