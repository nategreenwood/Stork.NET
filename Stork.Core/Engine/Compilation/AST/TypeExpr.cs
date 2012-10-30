using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public class TypeExpr
    {
        private string _name;

        public TypeExpr(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public Type Eval(Translator translator)
        {
            return translator.Eval(this);
        }
    }
}
