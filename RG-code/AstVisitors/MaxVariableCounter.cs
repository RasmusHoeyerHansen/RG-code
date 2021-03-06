using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Microsoft.VisualBasic;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;
using Type = RG_code.AST.Type;

namespace RG_code.AstVisitors
{
    public class MaxVariableCounter<TVisit> : ScopeTraveller<string, Declaration>, IVariableCounterVisitor<TVisit>
        where TVisit : Ast
    {
        
        private int _maxNeededVariables = 0;

        public int MaxNeededVariables
        {
            get => _maxNeededVariables;
            set
            {
                if (value > _maxNeededVariables)
                {
                    _maxNeededVariables = value;
                }
            }
        }

        private TryAddList<Declaration> UsedDeclarations { get; set; } = new TryAddList<Declaration>();

       

        public MaxVariableCounter(Stack<Scope<string, Declaration>> stack) : base(stack)
        {

        }


        public TVisit Visit(Program node)
        {
            foreach (Statement nodeProgramStatement in node.ProgramStatements)
            {
                Visit(nodeProgramStatement);
            }

            return (dynamic) node;
        }


        public TVisit Visit(Declaration node)
        {
            Visit((dynamic) node.Value);
            return (dynamic) node;
        }






        public TVisit Visit(Loop node)
        {
            Visit((dynamic) node.Condition);
            foreach (Ast ast in node.Body)
            {
                Visit((dynamic) ast);
            }
            return (dynamic) node;
        }




        public TVisit VisitInfixMath(InfixMath node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.LeftHandSide);
            return (dynamic) node;
        }


        public TVisit Visit(Plus node)
        {
            return VisitInfixMath(node);
        }

        public TVisit Visit(Minus node)
        {
            return VisitInfixMath(node);

        }

        public TVisit Visit(Multiplication node)
        {
            return VisitInfixMath(node);

        }

        
        public TVisit Visit(Divide node)
        {
            return VisitInfixMath(node);
        }

        public TVisit Visit(Power node)
        {
            return VisitInfixMath(node);

        }


        public TVisit Visit(Assign node)
        {
            Visit((dynamic) node.Value);

            return (dynamic) node;
        }

        public TVisit Visit(NameReference node)
        {
            Declaration n = GetDeclaration(node.Name);
            if (!UsedDeclarations.TryAdd(n))
                return (dynamic) node;

            switch (n.Type)
            {
                case Type.Point:
                    MaxNeededVariables = 2;
                    break;
                case Type.Number:
                    MaxNeededVariables = 1;
                    break;
            }

            return (dynamic) node;
        }


        public TVisit Visit(Number node)
        {
            return (dynamic) node;
        }

        public TVisit Visit(Point node)
        {
            Visit((dynamic) node.XValue);
            Visit((dynamic) node.YValue);
            return (dynamic) node;
        }

        public TVisit Visit(Line node)
        {
            Visit((dynamic) node.FromPoint);
            foreach (Ast ast in node.ToChain)
            {
                Visit((dynamic) ast);
            }

            UsedDeclarations.Clear();
            return (dynamic) node;
        }

        public TVisit Visit(Curve node)
        {
            Visit((dynamic) node.FromPoint);
            foreach (Ast ast in node.ToChain)
            {
                Visit((dynamic) ast);
            }
            Visit((dynamic) node.Angle);
            Visit((dynamic) node.FromPoint);
            
            return (dynamic) node;
        }

        public TVisit Visit(GreaterThan node)
        {
            return (dynamic) VisitInfixBool(node);

        }

        public TVisit Visit(LessThan node)
        {
            return (dynamic) VisitInfixBool(node);

        }

        private Ast VisitInfixBool(InfixBool node)
        {
            Visit((dynamic) node.LeftHandSide);
            Visit((dynamic) node.RightHandSide);
            return (dynamic) node;
        }

        public TVisit Visit(Equals node)
        {
            return (dynamic) VisitInfixBool(node);
        }

        public TVisit Visit(If node)
        {
            Visit((dynamic) node.Condition);
            foreach (Ast ast in node.Body)
            {
                Visit((dynamic) ast);
            }

            return (dynamic) node;
        }

        public TVisit Visit(IfElse node)
        {
            Visit((dynamic) node.Condition);

            foreach (Ast ast in node.Body)
            {
                Visit((dynamic) ast);
            }

            foreach (var ast in node.ElseBody)
            {
                Visit((dynamic) ast);
            }

            return (dynamic) node;
        }


        public TVisit Visit(Statement statement)
        {
            Visit((dynamic) statement);
            UsedDeclarations.Clear();
            return (dynamic) statement;
        }
    }
}