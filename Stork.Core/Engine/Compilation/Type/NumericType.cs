using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public abstract class NumericType : Type
    {
        public static readonly FloatType FLOAT = FloatType.INSTANCE;
        public static readonly IntType INT = IntType.INSTANCE;

        public abstract int GetPrecision();
    }
}
