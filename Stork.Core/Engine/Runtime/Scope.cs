using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Runtime
{
    public class Scope
    {
        private Dictionary<string, object> _vars;

        public Scope()
        {
            _vars = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> GetVars()
        {
            return _vars;
        }

        public Dictionary<string, object>.KeyCollection ListVars()
        {
            return GetVars().Keys;
        }

        public void DefineVar(string name, object value)
        {
            if (ListVars().Contains(name))
                throw new InternalRuntimeStorkNetException("Cannot re-define variable: " + name);
            GetVars().Add(name, value);
        }

        public void SetValue(string name, object value)
        {
            if(!ListVars().Contains(name))
                throw new InternalRuntimeStorkNetException("Cannot assign to undefined variable: " + name);
            GetVars()[name] = value;
        }

        public object GetValue(string name)
        {
            object result;
            if(! ListVars().Contains(name))
                throw new InternalRuntimeStorkNetException("No variable with name: " + name);
            else
            {
                result = GetVars()[name];
                if(result == null)
                    throw new InternalRuntimeStorkNetException("Variable has no value: " + name);
            }

            return result;
        }
    }
}
