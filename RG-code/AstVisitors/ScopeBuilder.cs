using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public abstract class ScopeBuilder<TKey, TValue> : IStackTraveller<TKey, TValue>
    {
        public ScopeBuilder()
        {
            ScopeStack.Push(new Scope<TKey, TValue>(null));
        }

        public ScopeBuilder(Stack<Scope<TKey,TValue>> stack)
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
            //Create new scope and set parent to current scope
            var scopeToEnter = new Scope<TKey, TValue>(ScopeStack.Peek());
            //Add contained scope to child scope
            ScopeStack.Peek().ChildScopes.Add(scopeToEnter);
            //Enter scope
            ScopeStack.Push(scopeToEnter);
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
        
        protected Scope<TKey, TValue> GetStartScope()
        {
            Scope<TKey,TValue> foundScope = ScopeStack.Peek();

            while (foundScope.ParentScope != null)
            {
                foundScope = foundScope.ParentScope;
            }

            return foundScope;

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