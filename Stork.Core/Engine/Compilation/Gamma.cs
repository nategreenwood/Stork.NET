using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Engine.Compilation
{
    using Exception = System.Exception;

    public class Gamma
    {
        private Dictionary<string, Slot> _slots;
        private Dictionary<string, Type> _types;

        public Gamma()
        {
            _slots = new Dictionary<string, Slot>();
            _types = new Dictionary<string, Type>();
        }

        protected Dictionary<string, Slot> GetSlots()
        {
            return _slots;
        }

        public Dictionary<string,Slot>.KeyCollection ListSlots()
        {
            return GetSlots().Keys;
        }

        public Slot GetSlot(string name)
        {
            Slot result = GetSlots()[name];
            if (result == null)
                throw new InternalCompilationStorkNetException("No such slot: " + name);
            
            return result;
        }

        public void AddSlot(string name, Type type)
        {
            GetSlots().Add(name, new Slot(type));
        }

        protected Dictionary<string, Type> GetTypes()
        {
            return _types;
        }

        public Dictionary<string, Type>.KeyCollection ListTypes()
        {
            return GetTypes().Keys;
        }

        public Type GetType(string name)
        {
            Type result = GetTypes()[name];
            if(result == null)
                throw new InternalCompilationStorkNetException("No such type: " + name);

            return result;
        }

        public void AddType(string name, Type type)
        {
            GetTypes().Add(name, type);
        }

        public class Slot
        {
            public enum Flag
            {
                Initialized
            }

            internal Slot(Type type)
            {
                this._type = type;
                _flags = null;
            }

            private Type _type;
            private ISet<Flag> _flags;

            public new Type GetType()
            {
                return _type;
            }

            protected ISet<Flag> GetFlags()
            {
                return _flags;
            }

            public bool HasFlag(Flag flag)
            {
                return GetFlags().Contains(flag);
            }

            public void SetFlag(Flag flag)
            {
                GetFlags().Add(flag);
            }
        }
    }
}
