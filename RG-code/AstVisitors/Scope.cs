using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class Scope<TKey,TValue>
    {
        public Dictionary<string, Declaration> ContainedVariables { get; } =
            new();

        public Scope<TKey,TValue> ParentScope { get; private set; }


        public Scope(Scope<TKey,TValue> parentScope, List<Scope<TKey, TValue>> childScopes)
        {
            ParentScope = parentScope;
            ChildScopes = childScopes;
        }
        
        public Scope(Scope<TKey,TValue> parentScope)
        {
            ParentScope = parentScope;
            ChildScopes = new List<Scope<TKey, TValue>>();
            ContainedStatements = new List<Statement>();
        }

        public List<Scope<TKey, TValue>> ChildScopes { get; private set; }
        public List<Statement> ContainedStatements { get; private set; }
    }

  

}