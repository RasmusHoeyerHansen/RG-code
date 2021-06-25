using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;
using Type = RG_code.AST.Type;

namespace RG_code.AstVisitors
{
    public class ExpressionUsageChecker :  StackTraveller, IStatementVisitor<Type>, IProgramVisitor<Ast>
    {
        public ExpressionUsageChecker(Stack<Scope> scope) : base(scope)
        {
        }
        public Type Visit(Plus node)
        {
            return ExamineInfix(node);
        }

        public Type Visit(Minus node)
        {
            return ExamineInfix(node);
        }

        public Type Visit(Multiplication node)
        {
            return ExamineInfix(node);

        }

        public Type Visit(Divide node)
        {
            return ExamineInfix(node);

        }

        public Type Visit(Power node)
        {
            return ExamineInfix(node);
        }

        public Type Visit(Number node)
        {
            return SetAndReturn(node, Type.Number);
        }

        public Type Visit(Point node)
        {
            Type xType = Visit((dynamic)node.XValue);
            Type yType = Visit((dynamic)node.YValue);

            if (xType != Type.Number || yType != Type.Number)
            {
                Errors.Add(new TypeError(node, TypeError.ErrorType.ExpressionInconsistency, xType, yType));
                return Type.Wrong;
            }

            return SetAndReturn(node, Type.Point);
        }

        public Type Visit(Line node)
        {
            if (Visit((dynamic)node.FromPoint) != Type.Point)
            {
                Errors.Add(new TypeError(node.FromPoint, TypeError.ErrorType.IncorrectUsage, "start point is wrongly typed."));
            }

            bool containsWrongType = false;
            foreach (Ast ast in node.ToChain)
            {
                if (Visit((dynamic) ast) == Type.Point) continue;
                Errors.Add(new TypeError(ast, TypeError.ErrorType.IncorrectUsage, "point in to chain is wrongly typed."));
                containsWrongType = true;
            }

           
            return containsWrongType ? SetAndReturn(node, Type.Wrong) :  SetAndReturn(node, Type.Ok);;
            
        }

        public Type Visit(Curve node)
        {
            if (Visit((dynamic) node.Angle) != Type.Number)
            {
                Errors.Add(new TypeError(node.Angle, TypeError.ErrorType.IncorrectUsage, "angle is wrongly typed."));
                return Type.Wrong;
            }

            if (Visit((dynamic)node.FromPoint) != Type.Point)
            {
                Errors.Add(new TypeError(node.FromPoint, TypeError.ErrorType.IncorrectUsage, "start point is wrongly typed."));
            }

            bool containsWrongType = false;
            foreach (Ast ast in node.ToChain)
            {
                if (Visit((dynamic) ast) == Type.Point) continue;
                Errors.Add(new TypeError(ast, TypeError.ErrorType.IncorrectUsage, "point in to chain is wrongly typed."));
                containsWrongType = true;
            }

            if (containsWrongType)
            {
                return SetAndReturn(node, Type.Wrong);
            }
            
            return Type.Ok;
        }

        public Type Visit(Assign node)
        {
            node.Type = Visit((dynamic)node.Value);
            return node.Type;
        }

        public Type Visit(NameReference node)
        {
            Declaration foundNode = FindDeclaration(node);
            if (foundNode == null)
            {
                return Type.NotDeclared;
            }

            return foundNode.Type;
        }

        public Type Visit(Declaration node)
        {
            Type expected = node.Type;
            Type gotten = Visit(node.AssignedValue);

            if (expected != gotten)
            {
                return SetAndReturn(node, Type.Wrong);
            }
            
            //Nodes are already typed when created
            return Type.Ok;
        }

        public Type Visit(GreaterThan node)
        {
            return ExamineInfix(node);
        }

        public Type Visit(LessThan node)
        {
            return ExamineInfix(node);
        }

        public Type Visit(Equals node)
        {
            return ExamineInfix(node);
        }

        public Type Visit(Loop node)
        { 
            if (Visit((dynamic) node.Condition) != Type.Bool)
            {
                Errors.Add(new TypeError(node.Condition, TypeError.ErrorType.IncorrectUsage, "condition is wrongly typed."));
                return Type.Wrong;
            }

            bool allOkay = node.Body.All(statementNode =>
            {
                if (statementNode is Statement s)
                {
                    if (s.Type == Type.Ok) return true;
                }

                return false;
            });
            
            return allOkay ? Type.Ok : Type.Wrong;
        }
        

        private Type ExamineInfix(InfixBool infixBool)
        {
            Type lhsType = Visit((dynamic) infixBool.LeftHandSide);
            Type rhsType = Visit((dynamic) infixBool.RightHandSide);

            if (lhsType != rhsType)
            {
                Errors.Add(new TypeError(infixBool, TypeError.ErrorType.ExpressionInconsistency, lhsType, rhsType));
                return Type.Wrong;
            }

            //Per convention, return left hand even if error occur.
            return lhsType;
        }
        
        private Type ExamineInfix(InfixMath infixBool)
        {
            Type lhsType = Visit((dynamic) infixBool.LeftHandSide);
            Type rhsType = Visit((dynamic) infixBool.RightHandSide);

            if (lhsType != rhsType)
            {
                Errors.Add(new TypeError(infixBool, TypeError.ErrorType.ExpressionInconsistency, lhsType, rhsType));
                return Type.Wrong;
            }
            
            return lhsType;
        }

        private Type SetAndReturn(Ast n, Type t)
        {
            n.Type = t;
            return t;
        }
     

        public Ast Visit(Program node)
        {
            foreach (Ast nodeProgramStatement in node.ProgramStatements)
            {
                Visit((dynamic) nodeProgramStatement);
            }

            //Check if all statements are okay
            //Notice that all nodes must be statement - else caught by parser.
            bool allOkay = node.ProgramStatements.All(statementNode =>
                {
                    if (statementNode is Statement s)
                    {
                        if (s.Type == Type.Ok) return true;
                    }

                    return false;
                });

            return allOkay ? node : null;
            
        }
    }
}