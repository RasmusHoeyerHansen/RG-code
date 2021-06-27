using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;

namespace RG_code.AstVisitors
{
    /// <summary>
    ///     Methods used to build the scopes
    /// </summary>
    public sealed class DeclarationChecker : StackTraveller, IStatementVisitor<Ast>, IProgramVisitor<Ast>
    {
        public Ast Visit(Program node)
        {
            foreach (Ast nodeProgramStatement in node.ProgramStatements) Visit((dynamic) nodeProgramStatement);

            return node;
        }

        public Ast Visit(GreaterThan node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Bool;
            return node;
        }

        public Ast Visit(LessThan node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Bool;
            return node;
        }

        public Ast Visit(Equals node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Number;
            return node;
        }

        public Ast Visit(Loop node)
        {
            Visit((dynamic) node.Condition);

            EnterScope();

            foreach (Ast ast in node.Body) Visit((dynamic) ast);

            ExitScope();
            return node;
        }

        public Ast Visit(Assign node)
        {
            Ast q = Visit((dynamic) node.Value);
            node.Type = q.Type;
            return node;
        }

        public Ast Visit(NameReference node)
        {
            if (!IsDeclared(node.Name))
                Errors.Add(new TypeError(node, TypeError.ErrorType.NotDeclared));

            return node;
        }

        public Ast Visit(Declaration node)
        {
            //Visit values
            Visit(node.AssignedValue);
            //If already declared, add error, else add the declaration
            if (IsDeclared(node))
                Errors.Add(new TypeError(node, TypeError.ErrorType.DoubleDeclared));
            else
                ScopeStack.Peek().ContainedVariables.Add(node.Name, node);


            return null;
        }


        public Ast Visit(Plus node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Number;
            return node;
        }

        public Ast Visit(Minus node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Number;
            return node;
        }

        public Ast Visit(Multiplication node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Number;

            return node;
        }

        public Ast Visit(Divide node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Number;

            return node;
        }

        public Ast Visit(Power node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            node.Type = Type.Number;
            return node;
        }

        public Ast Visit(Number node)
        {
            node.Type = Type.Number;
            return node;
        }

        public Ast Visit(Point node)
        {
            Visit((dynamic) node.XValue);
            Visit((dynamic) node.YValue);
            node.Type = Type.Point;
            return node;
        }

        public Ast Visit(Line node)
        {
            Visit((dynamic) node.FromPoint);


            foreach (Ast ast in node.ToChain) Visit((dynamic) ast);

            return node;
        }

        public Ast Visit(Curve node)
        {
            Visit((dynamic) node.FromPoint);
            foreach (Ast ast in node.ToChain) Visit((dynamic) ast);

            Visit((dynamic) node.Angle);
            return node;
        }

        public Ast Visit(If node)
        {
            EnterScope();
            foreach (Ast ast in node.Body)
            {
                dynamic q = Visit((dynamic) ast);
            }

            ExitScope();

            return Visit((dynamic) node.Condition);
        }

        public Ast Visit(IfElse node)
        {
            EnterScope();
            foreach (Ast ast in node.Body)
                Visit((dynamic) ast);

            ExitScope();
            EnterScope();
            foreach (Ast ast in node.ElseBody)
                Visit((dynamic) ast);

            ExitScope();


            return Visit((dynamic) node.Condition);
        }
    }
}