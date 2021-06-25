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
        public Stack<Scope> ScopeStack { get; set; } = new Stack<Scope>();
        protected List<TypeError> Errors { get; set; } = new List<TypeError>();

        public string GetErrorText()
        {
            string result = string.Empty;

            if (Errors.Count == 0)
                return result;
                    
            result += "Type Errors: \n";
            foreach (TypeError typeErrors in Errors)
            {
                result += typeErrors.ToString() + '\n';
            }
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

        protected Declaration FindDeclaration(NameReference node)
        {
            return FindDeclaration(node.Name);
        }
        

        protected Declaration FindDeclaration(string nodeName)
        {
            Scope foundScope;
            ScopeStack.TryPeek(out foundScope);
            Declaration foundDeclaration;

            while (foundScope != null)
            {
                if (foundScope.ContainedVariables.TryGetValue(nodeName, out foundDeclaration))
                {
                    return foundDeclaration;
                }

                foundScope = foundScope.ParentScope;
            }

            return null;
        }

        protected bool IsDeclared(string nodeName)
        {
            return FindDeclaration(nodeName) is null ? false : true; 
           }
        
        protected bool IsDeclared(Declaration node)
        {
            return IsDeclared(node.Name);
        }

 
    }
}