using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class UsageFinder<T> : ScopeBuilder<string,Declaration>
    {

        private int StatementCounter { get; set; } = 0;
        private Statement CurrentStatement { get; set; }
        private Scope<string, Declaration> CurrentScope {get;set;}
        private Scope<string, Declaration> StartScope { get; }

        public Dictionary<Declaration, DeclarationInformation> DeclarationInfos { get; } =
            new Dictionary<Declaration, DeclarationInformation>();


        public UsageFinder(Stack<Scope<string,Declaration>> stack) : base(stack)
        {
            StartScope = GetStartScope();
            CurrentScope = StartScope;
        }

        public Ast Visit(NameReference node)
        {
            var n = GetDeclaration(node.Name);
            DeclarationInformation foundDeclarationInfo;
            bool isAlreadyAdded = DeclarationInfos[n] != null;
            
            if (isAlreadyAdded)
            {
                DeclarationInfos[n].LatestUsageNumber = StatementCounter;
                DeclarationInfos[n].LatestUsageScope = ScopeStack.Peek();
            }
            else
            {
                DeclarationInfos.Add(n, 
                    new DeclarationInformation(ScopeStack.Peek(),n,StatementCounter, CurrentStatement));
            }
  
            
            return node;
        }

        public void TraverseScope()
        {
            TraverseScope(StartScope);
        }

        public void TraverseScope(Scope<string, Declaration> scope)
        {
            //Visit current scope statements;
            foreach (Statement statement in scope.ContainedStatements)
            {
                Visit(statement);
            }

            //Visit child scope statement
            foreach (Scope<string,Declaration> childScope in scope.ChildScopes)
            {
                CurrentScope = childScope;
                foreach (Statement s in childScope.ContainedStatements)
                {
                    Visit(s);
                }
            }
        }

        public Ast Visit(Statement node)
        {
            StatementCounter++;
            CurrentStatement = node;
            Visit((dynamic) node);
            return node;
        }

    }
}