using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public abstract class StackDeclarationTracker<TKey, TValue> : IStackTraveller<TKey, TValue>
    {
        public StackDeclarationTracker()
        {
            ScopeStack.Push(new Scope<TKey, TValue>(null));
        }

        public StackDeclarationTracker(Stack<Scope<TKey,TValue>> stack)
        {
            ScopeStack = stack;
        }

        public Stack<Scope<TKey,TValue>> ScopeStack { get; } = new();
        public List<TypeError> Errors { get; } = new();

        public virtual string GetErrorText()
        {
            string result = string.Empty;

            if (Errors.Count == 0)
                return "No type error";

            result += "Type Errors: \n";
            foreach (TypeError typeErrors in Errors) result += typeErrors.ToString() + '\n';
            return result;
        }

        public void EnterScope()
        {
            ScopeStack.Push(new Scope<TKey,TValue>(ScopeStack.Peek()));
        }


        public void ExitScope()
        {
            ScopeStack.Pop();
        }

        protected Declaration GetDeclaration(NameReference node)
        {
            return GetDeclaration(node.Name);
        }


        protected Declaration GetDeclaration(string nodeName)
        {
            Scope<TKey,TValue> foundScope;
            ScopeStack.TryPeek(out foundScope);
            Declaration foundDeclaration;

            while (foundScope != null)
            {
                if (foundScope.ContainedVariables.TryGetValue(nodeName, out foundDeclaration)) return foundDeclaration;

                foundScope = foundScope.ParentScope;
            }

            return null;
        }

        protected bool IsDeclared(string nodeName)
        {
            return GetDeclaration(nodeName) is null ? false : true;
        }

        protected bool IsDeclared(Declaration node)
        {
            return IsDeclared(node.Name);
        }
    }
    
}