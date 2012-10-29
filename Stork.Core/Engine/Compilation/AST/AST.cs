namespace Stork.NET.Core.Engine.Compilation
{
    using System.Collections.Generic;

    public abstract class AST
    {
        private readonly List<AST> _children;

        protected AST()
        {
            _children = new List<AST>();
        }

        protected void AddChild(AST child)
        {
            _children.Add(child);
        }

        public List<AST> GetChildren()
        {
            return _children;
        }
    }
}
    