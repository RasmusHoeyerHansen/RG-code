using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class Scope<Key,Value>
    {
        public Dictionary<string, Declaration> ContainedVariables { get; } =
            new();

        public Scope<Key,Value> ParentScope { get; private set; }


        public Scope(Scope<Key,Value> parentScope)
        {
            ParentScope = parentScope;
        }
    }
}