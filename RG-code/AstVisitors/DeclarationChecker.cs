using System.Collections.Generic;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;

namespace RG_code.AstVisitors
{
    public sealed partial class DeclarationChecker : IProgramVisitor<Ast>
    {
        public DeclarationChecker()
        {
            ScopeStack.Push(new Scope(null));
        }
        private Stack<Scope> ScopeStack { get; set; } = new Stack<Scope>();
        private List<TypeError> Errors { get; set; } = new List<TypeError>();

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

        private void EnterScope()
        {
            ScopeStack.Push(new Scope(ScopeStack.Peek()));
        }

        
        private void ExitScope()
        {
            ScopeStack.Pop();
        }

        public Ast Visit(Program node)
        {
            foreach (Ast nodeProgramStatement in node.ProgramStatements)
            {
                if (nodeProgramStatement is Statement s)
                {
                    Visit((dynamic)s);
                }
            }

            return node;
        }
    }

    /// <summary>
    /// Methods used to build the scopes
    /// </summary>
    partial class DeclarationChecker : StatementVisitor<Ast>
    {
        public Ast Visit(GreaterThan node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(LessThan node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Equals node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Loop node)
        {
            if (node.Condition is NameReference n)
            {
                Visit(n);
            }
            
            EnterScope();

            foreach (Ast ast in node.Body)
            {
                if (ast is Statement s)
                {
                    Visit((dynamic) s);
                }
            }

            ExitScope();
            return node;

        }

        public Ast Visit(Assign node)
        {
            if (node.Value is NameReference n)
            {
                Visit(n);
            }

            return node;
        }

        public Ast Visit(NameReference node)
        {
            if (!IsDeclared(node.Name))
            {
                Errors.Add(new TypeError(node, TypeError.ErrorType.NotDeclared));
            }
            
            return node;
      
        }

        public Ast Visit(Declaration node)
        {
            
            //If already declared, add error, else add the declaration
            if (IsDeclared(node))
            {
                Errors.Add(new TypeError(node, TypeError.ErrorType.DoubleDeclared));
            }
            else
            {
                ScopeStack.Peek().ContainedVariables.Add(node.Name,node);
            }
            
            return null;
        }

        private bool IsDeclared(string nodeName)
        {
            Scope foundScope;
            ScopeStack.TryPeek(out foundScope);
            Declaration foundDeclaration;

            while (foundScope != null)
            {
                if (foundScope.ContainedVariables.TryGetValue(nodeName, out foundDeclaration))
                {
                    return true;
                }

                foundScope = foundScope.ParentScope;
            }

            return false;
        }
        
        private bool IsDeclared(Declaration node)
        {
            return IsDeclared(node.Name);
        }

        public Ast Visit(Plus node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Minus node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Multiplication node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Divide node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Power node)
        {
            if (node.LeftHandSide is NameReference l)
            {
                Visit(l);
            }
            
            if (node.RightHandSide is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Number node)
        {
            return node;
        }

        public Ast Visit(Point node)
        {
            if (node.XValue is NameReference l)
            {
                Visit(l);
            }
            
            if (node.YValue is NameReference r)
            {
                Visit(r);
            }

            return node;
        }

        public Ast Visit(Line node)
        {
            if (node.FromPoint is NameReference n)
            {
                Visit(n);
            }

            foreach (Ast ast in node.ToChain)
            {
                if (ast is Statement s)
                {
                    Visit((dynamic) s);
                }
            }

            return node;

        }

        public Ast Visit(Curve node)
        {
            if (node.FromPoint is NameReference n)
            {
                Visit(n);
            }

            foreach (Ast ast in node.ToChain)
            {
                if (ast is Statement s)
                {
                    Visit((dynamic) s);
                }
            }

            Visit((dynamic)node.Angle);
            return node;
        }
    }
}