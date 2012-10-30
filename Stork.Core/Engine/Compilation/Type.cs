using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public abstract class Type
    {
        public static FloatType FLOAT   = Type.FLOAT;
        public static IntType INT       = Type.INT;

        public abstract string GetText();

        public override string ToString()
        {
            return GetText();
        }
    }
}
