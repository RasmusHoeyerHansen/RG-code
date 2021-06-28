using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime;
using RG_code.AST;

namespace RG_testing.HelperClasses
{
    public class MovementDependable : AstDependable
    {
        public Line CreateLine(string code)
        {
            return CreateAst<Line, RGCodeParser.LineContext>(code);
        }
        
        public Line CreateLine(string fileName, string dirName)
        {
            return CreateAst<Line, RGCodeParser.LineContext>(fileName, dirName);
        }
        
        public Curve CreateCurve(string fileName, string dirName)
        {
            return CreateAst<Curve, RGCodeParser.CurveContext>(fileName, dirName);
        }
        
        public Curve CreateCurve(string code)
        {
            return CreateAst<Curve, RGCodeParser.CurveContext>(code);
        }

        public Line CreateLine(Point from, IEnumerable<Point> toChain)
        {
            return new Line(from, toChain, new CommonToken(1));
        }

        public Curve CreateCurve(Point from, IEnumerable<Point> toChain, InfixMath angle)
        {
            return new Curve(from, toChain, angle, new CommonToken(1));
        }
    }
}