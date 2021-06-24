using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Net.Sockets;
using System.Xml.Schema;
using Antlr4.Runtime.Tree;
using RG_code.AST;
using Type = RG_code.AST.Type;

namespace RG_code.AstVisitors
{
    public class AstBuilderVisitor<T> : RGCodeBaseVisitor<Ast>
    {
        public override Ast VisitProgram(RGCodeParser.ProgramContext context)
        {
            RGCodeParser.StatementContext[] q = context.statement();
            List<Ast> programBody = new List<Ast>();
            foreach (RGCodeParser.StatementContext statementContext in q)
            {
                programBody.Add(Visit(statementContext));
            }

            return new Program(programBody, context.Start);

        }

        public override Ast VisitAssignment(RGCodeParser.AssignmentContext context)
        {
            Ast expr = Visit(context.expr());
            Assign result = new Assign(context.ID().GetText(), expr, context.Start);

            return result;
        }

        public override Ast VisitVardec(RGCodeParser.VardecContext context)
        {
            Ast assignment = Visit(context.assignment());
            Declaration result = new Declaration(assignment, context.Start);


            switch (context.typeWord.Text)
            {
                case "number":
                    result.Type = Type.Number;
                    break;
                case "point":
                    result.Type = Type.Point;
                    break;
                case "int":
                    result.Type = Type.Integer;
                    break;
            }

            return result;
        }

        public override Ast VisitMove(RGCodeParser.MoveContext context)
        {
            if (context.curve() != null)
            {
                return Visit(context.curve());
            }

            return Visit(context.line());
        }

        public override Ast VisitLineCommand(RGCodeParser.LineCommandContext context)
        {
            Ast from = Visit(context.@from);
            List<Ast> toChain = new List<Ast>();
            Line result = new Line(from, toChain, context.Start);


            Ast temp;
            foreach (RGCodeParser.ToCommandsContext toCommandsContext in context.toCommands())
            {
                toChain.Add(Visit(toCommandsContext));
            }

            return result;
        }

        public override Ast VisitCurveCommand(RGCodeParser.CurveCommandContext context)
        {
            Ast from = Visit(context.@from);
            List<Ast> toChain = new List<Ast>();
            Ast angle = Visit(context.angle);

            foreach (RGCodeParser.ToCommandsContext toCommandsContext in context.toCommands())
            {
                toChain.Add(Visit(toCommandsContext));
            }

            Curve result = new Curve(from, toChain, angle, context.Start);
            return base.VisitCurveCommand(context);
        }

        public override Ast VisitTo(RGCodeParser.ToContext context)
        {
            return Visit(context.p);
        }


        public override Ast VisitPointExpression(RGCodeParser.PointExpressionContext context)
        {
            Ast lhs = Visit(context.lhs);
            Ast rhs = Visit(context.lhs);

            return new Point(lhs, rhs, context.Start);
        }

        public override Ast VisitBoolExpression(RGCodeParser.BoolExpressionContext context)
        {
            Ast lhs = Visit(context.lhs);
            var rhs = Visit(context.lhs);

            switch (context.@operator.Text)
            {
                case ">":

                    return new GreaterThan(lhs, rhs, context.Start);

                case "<":
                    return new LessThan(lhs, rhs, context.Start);
                case "==":
                    return new Equals(lhs, rhs, context.Start);
                default:
                    throw new NotSupportedException(context.@operator.Text + " is not supported");
            }
        }

        public override Ast VisitPlusminus(RGCodeParser.PlusminusContext context)
        {
            Ast lhs = Visit(context.lhs);
            Ast rhs = Visit(context.rhs);

            switch (context.op.Text)
            {
                case "+":
                    return new Plus(lhs, rhs, context.Start);
                case "-":
                    return new Minus(lhs, rhs, context.Start);

                default:
                    throw new NotSupportedException(context.op.Text + " is not supported");

            }
        }

        public override Ast VisitMultiplication(RGCodeParser.MultiplicationContext context)
        {

            Ast lhs = Visit(context.lhs);
            Ast rhs = Visit(context.rhs);

            switch (context.op.Text)
            {
                case "*":
                    return new Multiplication(lhs, rhs, context.Start);
                case "/":
                    return new Divide(lhs, rhs, context.Start);

                default:
                    throw new NotSupportedException(context.op.Text + " is not supported");

            }
        }

        public override Ast VisitSingleTerm(RGCodeParser.SingleTermContext context)
        {
            return Visit(context.term());
        }

        public override Ast VisitSingleFactor(RGCodeParser.SingleFactorContext context)
        {
            return Visit(context.child);
        }

        public override Ast VisitPower(RGCodeParser.PowerContext context)
        {
            var expr = Visit(context.atom());
            var factor = Visit(context.factor());
            return new Power(expr, factor, context.Start);
        }

        public override Ast VisitSingeAtom(RGCodeParser.SingeAtomContext context)
        {
            return Visit(context.atom());
        }

        public override Ast VisitValue(RGCodeParser.ValueContext context)
        {
            string stringVal = context.value.Text;
            double q = double.Parse(stringVal);
                return new Number(q, context.Start);
        }

        public override Ast VisitIf(RGCodeParser.IfContext context)
        {
            Ast condition = Visit(context.cond);
            List<Ast> body = new List<Ast>();

            RGCodeParser.StatementContext[] statements = context.statement();
            foreach (var statementContext in statements)
            {
                var q = Visit(statementContext);
                body.Add(q);
            }

            return new If(condition, body, context.Start);

        }

        public override Ast VisitStatement(RGCodeParser.StatementContext context)
        {
            if (context.assignment() != null)
            {
                return VisitAssignment(context.assignment());
            } 
            else if (context.@if() != null)
            {
                return VisitIf(context.@if());
            } 
            else if (context.repeat() != null)
            {
                var q = VisitRepeat(context.repeat());
                return q;
            }
            else if (context.vardec() != null)
            {
                return VisitVardec(context.vardec());
            }
            else if (context.ifElse() != null)
            {
                return VisitIfElse(context.ifElse());
            } 
            else if (context.move() != null)
            {
                return VisitMove(context.move());
            }

            return null;
        }
        
        

        public override Ast VisitRepeat(RGCodeParser.RepeatContext context)
        {
            Ast condition = Visit(context.cond);
            List<Ast> body = new List<Ast>();
            foreach (var statement in context.statement())
            {
                body.Add(Visit(statement));
            }

            return new Loop(condition, body, context.Start);
        }

        public override Ast VisitIfElse(RGCodeParser.IfElseContext context)
        {

            If ifCommand = (If) Visit(context.@if());
            List<Ast> falseBody = new List<Ast>();

            foreach (RGCodeParser.StatementContext statementContext in context.statement())
            {
                falseBody.Add(Visit(statementContext));
            }

            return new IfElse(ifCommand, falseBody, context.Start);
        }
        
        

        public override Ast VisitIdMath(RGCodeParser.IdMathContext context)
        {
            return new NameReference(context.value.Text, context.Start);
        }

        public override Ast VisitIdPoint(RGCodeParser.IdPointContext context)
        {
            return new NameReference(context.value.Text, context.Start);
        }
    }
    
    
}