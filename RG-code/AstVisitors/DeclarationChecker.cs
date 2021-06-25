using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;

namespace RG_code.AstVisitors
{
    /// <summary>
    /// Methods used to build the scopes
    /// </summary>
    public sealed class DeclarationChecker : StackTraveller, IStatementVisitor<Ast>, IProgramVisitor<Ast>
    {
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
            Visit((dynamic)node.Value);
            

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
            
            //Visit values
            Visit(node.AssignedValue);
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