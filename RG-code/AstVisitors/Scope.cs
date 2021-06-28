using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class Scope
    {
        public Dictionary<string, Declaration> ContainedVariables { get; } =
            new();

        public Scope ParentScope { get; private set; }


        public Scope(Scope parentScope)
        {
            ParentScope = parentScope;
        }
    }
}