using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public abstract class StackTraveller
    {
        public StackTraveller()
        {
            ScopeStack.Push(new Scope(null));
        }

        public StackTraveller(Stack<Scope> stack)
        {
            ScopeStack = stack;
        }

        public Stack<Scope> ScopeStack { get; } = new();
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

        protected void EnterScope()
        {
            ScopeStack.Push(new Scope(ScopeStack.Peek()));
        }


        protected void ExitScope()
        {
            ScopeStack.Pop();
        }

        protected Declaration GetDeclaration(NameReference node)
        {
            return GetDeclaration(node.Name);
        }


        protected Declaration GetDeclaration(string nodeName)
        {
            Scope foundScope;
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