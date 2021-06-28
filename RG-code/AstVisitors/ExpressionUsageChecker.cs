using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;
using Type = RG_code.AST.Type;

namespace RG_code.AstVisitors
{
    public class ExpressionUsageChecker : StackTraveller, IStatementVisitor<Type>, IProgramVisitor<Ast>
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
            Type xType = Visit((dynamic) node.XValue);
            Type yType = Visit((dynamic) node.YValue);

            if (xType != Type.Number || yType != Type.Number)
            {
                Errors.Add(new TypeError(node, TypeError.ErrorType.ExpressionInconsistency, xType, yType));
                return SetAndReturn(node, Type.Wrong);
            }

            return SetAndReturn(node, Type.Point);
        }

        public Type Visit(Line node)
        {
            Visit((dynamic) node.FromPoint);
            
            bool isWrong = node.FromPoint.Type != Type.Point;

            foreach (Ast ast in node.ToChain)
            {
                Visit((dynamic) ast);
                if (ast.Type == Type.Point) continue;
                if (ast is NameReference n)
                {
                    Errors.Add(new TypeError(n, TypeError.ErrorType.IncorrectUsage, n.Type));
                }
                
                isWrong = true;
            }
            
            return isWrong ? SetAndReturn(node, Type.Wrong) : SetAndReturn(node, Type.Ok);
        }

        public Type Visit(Curve node)
        {
            if (Visit((dynamic) node.Angle) != Type.Number)
            {
                Errors.Add(new TypeError(node.Angle, TypeError.ErrorType.IncorrectUsage, "angle is wrongly typed."));
                return Type.Wrong;
            }

            if (Visit((dynamic) node.FromPoint) != Type.Point)
                Errors.Add(new TypeError(node.FromPoint, TypeError.ErrorType.IncorrectUsage,
                    "start point is wrongly typed."));

            bool containsWrongType = false;
            foreach (Ast ast in node.ToChain)
            {
                Visit((dynamic) ast);
                if (ast.Type == Type.Point) continue;
                Errors.Add(
                    new TypeError(ast, TypeError.ErrorType.IncorrectUsage, "point in to chain is wrongly typed."));
                containsWrongType = true;
            }

            if (containsWrongType) return SetAndReturn(node, Type.Wrong);

            return Type.Ok;
        }

        public Type Visit(Assign node)
        {
            Type declaredType;
            declaredType = GetDeclaration(node.Id).Type;
                Visit((dynamic) node.Value);

                if (node.Type != declaredType)
            {
                Errors.Add(new TypeError(node, TypeError.ErrorType.IncorrectUsage,
                    $"declared type is {declaredType} but got {node.Type} as assigned value"));
                return Type.Wrong;
            }

            if (declaredType != node.Value.Type)
            {
                Errors.Add(new TypeError(node, TypeError.ErrorType.ExpressionInconsistency, declaredType, node.Type));
                return Type.Wrong;
            }

            return SetAndReturn(node, declaredType);
        }

        public Type Visit(NameReference node)
        {
            Declaration foundNode = GetDeclaration(node);
            if (foundNode == null)
            {
                return SetAndReturn(node,Type.NotDeclared);
            }

            return SetAndReturn(node, foundNode.Type);
        }

        public Type Visit(Declaration node)
        {
            Visit((dynamic)node.Assignment.Value);

            if (node.Assignment.Value.Type != node.Type) return SetAndReturn(node, Type.Wrong);

            //Nodes are already typed when created
            return node.Type;
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
            dynamic conditionType = Visit((dynamic) node.Condition);
            if (conditionType != Type.Bool)
            {
                Errors.Add(new TypeError(node.Condition, TypeError.ErrorType.IncorrectUsage,
                    "condition is wrongly typed."));
            }

            foreach (Ast ast in node.Body) 
                Visit((dynamic) ast);

            bool allOkay = node.Body.All(statement => { return statement.Type == Type.Ok ? true : false; });
            
            return allOkay ? Type.Ok : Type.Wrong;
        }


        private Type ExamineInfix(InfixBool infixBool)
        {
            Type lhsType = Visit((dynamic) infixBool.LeftHandSide);
            Type rhsType = Visit((dynamic) infixBool.RightHandSide);

            if (lhsType != rhsType)
            {
                return SetAndReturn(infixBool, Type.Wrong);
            }

            return SetAndReturn(infixBool, Type.Bool);
        }

        private Type ExamineInfix(InfixMath infixMath)
        {
            Type lhsType = Visit((dynamic) infixMath.LeftHandSide);
            Type rhsType = Visit((dynamic) infixMath.RightHandSide);

            if (lhsType != rhsType)
            {
                return SetAndReturn(infixMath, Type.Wrong);
            }

            return SetAndReturn(infixMath, Type.Number);
        }

        private Type SetAndReturn(Ast n, Type t)
        {
            n.Type = t;
            return t;
        }

            
        public Ast Visit(Program node)
        {
            foreach (Ast nodeProgramStatement in node.ProgramStatements) Visit((dynamic) nodeProgramStatement);

            //Check if all statements are okay
            //Notice that all nodes must be statement - else caught by parser.
            bool allOkay = node.ProgramStatements.All(statement =>
            {
                if (statement.Type == Type.Wrong)
                {
                    return false;
                }

                return true;

            });

            node.Type = allOkay ? Type.Ok : Type.Wrong;
            return node;
        }

        public Type Visit(If node)
        {
            dynamic condExprType = Visit((dynamic) node.Condition);

            foreach (Ast ast in node.Body) Visit((dynamic) ast);

            bool allOkay = node.Body.All(statement => { return statement.Type == Type.Ok ? true : false; });


            return allOkay && condExprType == Type.Bool ? Type.Ok : Type.Wrong;
        }

        public Type Visit(IfElse node)
        {
            dynamic condExprType = Visit((dynamic) node.Condition);
            foreach (Ast ast in node.Body) Visit((dynamic) ast);

            foreach (Ast ast in node.ElseBody) Visit((dynamic) ast);

            bool okayBody = node.Body.All(statement => { return statement.Type == Type.Ok ? true : false; });


            bool okayElseBody = node.Body.All(statement => { return statement.Type == Type.Ok ? true : false; });


            return okayBody && okayElseBody && condExprType == Type.Bool ? Type.Ok : Type.Wrong;
        }
    }
}