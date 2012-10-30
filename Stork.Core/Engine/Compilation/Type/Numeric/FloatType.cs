using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    public class FloatType : NumericType
    {
        public static readonly FloatType INSTANCE = new FloatType();

        public FloatType()
        {
            
        }

        #region Overrides of Type

        public override string GetText()
        {
            return "Float";
        }

        public override int GetPrecision()
        {
            return 2000;
        }

        #endregion
    }
}
