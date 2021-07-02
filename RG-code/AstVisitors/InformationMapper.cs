using System.Collections;
using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class InformationMapper : ScopeTraveller<string,Declaration>
    {

        private int StatementCounter { get; set; } = 0;
        private Statement CurrentStatement { get; set; }
        private Scope<string, Declaration> StartScope { get; }

        public Dictionary<Declaration, DeclarationInformation> DeclarationInfos { get; } =
            new Dictionary<Declaration, DeclarationInformation>();
        


        public InformationMapper(Stack<Scope<string,Declaration>> stack) : base(stack)
        {
            StartScope = GetStartScope();
            ScopeDeclarationInfos = new Dictionary<Scope<string, Declaration>, IEnumerable<DeclarationInformation>>();
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
                DeclarationInfos[n].LatestStatement = CurrentStatement;
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

        public IEnumerable<DeclarationInformation> GetAllDeclarationInfos(Scope<string, Declaration> scope)
        {
            List<DeclarationInformation> infoList = new List<DeclarationInformation>();

            //Create Information for all declarations inside current scope
            infoList = CreateInfoList(scope);
            ScopeDeclarationInfos.Add(scope, infoList);


            //create information for all child scopes
            foreach (Scope<string,Declaration> childScope in scope.ChildScopes)
            {
                infoList.AddRange(CreateInfoList(childScope));
            }

            return infoList;
        }
        
        public List<DeclarationInformation> GetAllDeclarationInfos()
        {
            List<DeclarationInformation> infoList = new List<DeclarationInformation>();

            //Create Information for all declarations inside current scope
            infoList = CreateInfoList(StartScope);
            ScopeDeclarationInfos.Add(StartScope, infoList);


            //create information for all child scopes
            foreach (Scope<string,Declaration> childScope in StartScope.ChildScopes)
            {
                infoList.AddRange(CreateInfoList(childScope));
            }

            return infoList;
        }

        private List<DeclarationInformation> CreateInfoList(Scope<string, Declaration> scope)
        {
            List<DeclarationInformation> infoList = new List<DeclarationInformation>();
            //CreateInformation
            foreach (Declaration declaration in scope.ContainedVariables.Values)
            {
                DeclarationInformation info = DeclarationInfos[declaration];
                infoList.Add(DeclarationInfos[declaration]);
            }

            return infoList;
        }
        

        public Dictionary<Scope<string, Declaration>, IEnumerable<DeclarationInformation>> ScopeDeclarationInfos { get; set; }
    }
}