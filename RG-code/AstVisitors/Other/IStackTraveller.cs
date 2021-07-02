using System.Collections.Generic;

namespace RG_code.AstVisitors
{
    public interface IStackTraveller<TKey, TValue>
    {
        Stack<Scope<TKey, TValue>> ScopeStack { get; }
        void EnterScope();
        void ExitScope();
    }
}