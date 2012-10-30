using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public class IntType : NumericType
    {
        public static readonly IntType INSTANCE = new IntType();

        public IntType()
        {
            
        }

        #region Overrides of Type

        public override string GetText()
        {
            return "Int";
        }

        public override int GetPrecision()
        {
            return 1000;
        }

        #endregion
    }
}
