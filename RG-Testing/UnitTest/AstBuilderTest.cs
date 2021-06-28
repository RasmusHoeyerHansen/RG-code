using System.Linq;
using Antlr4.Runtime;
using NUnit.Framework;
using RG_code.AST;
using RG_code.AstVisitors;
using RG_testing.HelperClasses;

namespace RG_testing.UnitTest
{
    [TestFixture]
    public partial class AstBuilderTest : ContextDependable
    {
        [SetUp]
        public void SetUp()
        {
            _astBuilder = new AstBuilderVisitor<Ast>();
        }

        [TearDown]
        public void TearDown()
        {
            _astBuilder = null;
        }

        private AstBuilderVisitor<Ast> _astBuilder;


        [TestCase("q = x;")]
        [TestCase("q = 1;")]
        [TestCase("x = 2;")]
        [TestCase("x = 2;")]
        [TestCase("p = (x,q);")]
        [TestCase("p = (q,x);")]
        [TestCase("p = (q,q);")]
        [TestCase("p = (1,x);")]
        [TestCase("p = (x,1);")]
        [TestCase("p = (1,1);")]
        [TestCase("p = (x+1,q+1);")]
        [TestCase("p = (q+1,x+1);")]
        [TestCase("p = (q+(1+1),q*(2));")]
        [TestCase("p = (1^q,x^x);")]
        [TestCase("p = ((x) ^ q,1);")]
        [TestCase("p = (((1+1)) ^q,1);")]
        [TestCase("b = 2;")]
        public void Assignment_GivesAssignmentNode(string assignment)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.AssignmentContext>(assignment);
            Assert.IsTrue(_astBuilder.Visit((dynamic) context) is Assign);
        }


        [TestCase("(x,q)")]
        [TestCase("(q,x)")]
        [TestCase("(q,q)")]
        [TestCase("(1,x)")]
        [TestCase("(x,1)")]
        [TestCase("(1,1)")]
        [TestCase("(x+1,q+1)")]
        [TestCase("(q+1,x+1)")]
        [TestCase("(q+(1+1),q*(2))")]
        [TestCase("(1^q,x^x)")]
        [TestCase("((x) ^ q,1)")]
        [TestCase("(((1+1)) ^q,1)")]
        public void PointExpression_GivesPointNodeWithMathXYValues(string expression)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.PointContext>(expression);
            Assert.IsTrue(_astBuilder.Visit(context) is Point p);
        }


        [TestCase("1+1")]
        [TestCase("1 - 1")]
        [TestCase("1*1")]
        [TestCase("1/1")]
        [TestCase("1^1")]
        [TestCase("1+a")]
        [TestCase("1 - a")]
        [TestCase("1*a")]
        [TestCase("1/a")]
        [TestCase("1^a")]
        [TestCase("a+b")]
        [TestCase("a - b")]
        [TestCase("a*b")]
        [TestCase("a/b")]
        [TestCase("a^b")]
        public void MathExpression_GivesInfixMath(string expression)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.MathContext>(expression);
            Ast result = _astBuilder.Visit(context);
            Assert.IsTrue(result is Infix);
        }

        [TestCase("(1+1)")]
        [TestCase("(1)-(1)")]
        [TestCase("(1)*1")]
        [TestCase("1/(1)")]
        [TestCase("(1^1)^2")]
        [TestCase("(2^2)")]
        public void MathExpression_ParenthesisGivesInfix(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.MathContext>(code);
            Ast result = _astBuilder.Visit(context);
            Assert.IsTrue(result is Infix);
        }


        [TestCase("q = x;")]
        public void IdAssignment_gives_NameRefereenceAsAssignedValue(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.AssignmentContext>(code);
            Assign visitResult = (Assign) _astBuilder.Visit(context);
            Assert.IsTrue(visitResult.Value is NameReference);
        }


        [TestCase("number q = 1;")]
        [TestCase("number x = q;")]
        [TestCase("number y = x;")]
        [TestCase("point p1 = (2,2);")]
        [TestCase("point p2 = (x,2);")]
        [TestCase("point p3 = (2,y);")]
        [TestCase("point p4 = (x,y);")]
        public void Declaration_GivesDeclarationNodes(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.VardecContext>(code);
            Assert.IsTrue(_astBuilder.Visit(context) is Declaration);
        }

        [TestCase("line from p1 to p2;")]
        [TestCase("line from p1 to p2 to p3;")]
        [TestCase("line from p1 to p2 to p3 to p4;")]
        [TestCase("line from p1 to p2 to p3 to p4 to p5;")]
        public void Line_GivesLineNode(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.LineContext>(code);
            Line result = (Line) _astBuilder.Visit(context);
            Assert.IsTrue(result is Line);
        }

        [TestCase("line from p1 to p2;")]
        [TestCase("line from p1 to p2 to p3;")]
        [TestCase("line from p1 to p2 to p3 to p4;")]
        [TestCase("line from p1 to p2 to p3 to p4 to p5;")]
        public void LineAsMovement_GivesLineNode(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.MoveContext>(code);
            Line result = (Line) _astBuilder.Visit(context);
            Assert.IsTrue(result is Line);
        }

        [TestCase("line from p1 to p2;", 1)]
        [TestCase("line from p1 to p2 to p3;", 2)]
        [TestCase("line from p1 to p2 to p3 to p4;", 3)]
        [TestCase("line from p1 to p2 to p3 to p4 to p5;", 4)]
        public void Line_GivesLineNodeWithToChainLength(string code, int numberOfToPoints)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.LineContext>(code);
            Line line = (Line) _astBuilder.Visit(context);

            Assert.IsTrue(line.ToChain.Count() == numberOfToPoints);
        }

        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10+10;")]
        [TestCase("curve from p1 to p2 with angle 10*10;")]
        [TestCase("curve from p1 to p2 with angle 10/10;")]
        [TestCase("curve from p1 to p2 with angle 10*q;")]
        [TestCase("curve from p1 to p2 with angle 10^2;")]
        [TestCase("curve from p1 to p2 with angle 10+((5) + (5));")]
        [TestCase("curve from p1 to p2 with angle 10*(10);")]
        [TestCase("curve from p1 to p2 with angle 10/((((10))));")]
        [TestCase("curve from p1 to p2 with angle 10*(q+(q)+(q+q));")]
        public void Curve_GivesCurveNode(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.CurveContext>(code);
            Ast res = _astBuilder.Visit(context);
            Assert.IsTrue(res is Curve);
        }

        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10+10;")]
        [TestCase("curve from p1 to p2 with angle 10*10;")]
        [TestCase("curve from p1 to p2 with angle 10/10;")]
        [TestCase("curve from p1 to p2 with angle 10*q;")]
        [TestCase("curve from p1 to p2 with angle 10^2;")]
        [TestCase("curve from p1 to p2 with angle 10+((5) + (5));")]
        [TestCase("curve from p1 to p2 with angle 10*(10);")]
        [TestCase("curve from p1 to p2 with angle 10/((((10))));")]
        [TestCase("curve from p1 to p2 with angle 10*(q+(q)+(q+q));")]
        public void CurveAsMove_GivesCurveNode(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.MoveContext>(code);
            Ast res = _astBuilder.Visit(context);
            Assert.IsTrue(res is Curve);
        }

        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10;")]
        [TestCase("curve from p1 to p2 with angle 10+10;")]
        [TestCase("curve from p1 to p2 with angle 10*10;")]
        [TestCase("curve from p1 to p2 with angle 10/10;")]
        [TestCase("curve from p1 to p2 with angle 10*q;")]
        [TestCase("curve from p1 to p2 with angle 10^2;")]
        [TestCase("curve from p1 to p2 with angle 10+((5) + (5));")]
        [TestCase("curve from p1 to p2 with angle 10*(10);")]
        [TestCase("curve from p1 to p2 with angle 10/((((10))));")]
        [TestCase("curve from p1 to p2 with angle 10*(q+(q)+(q+q));")]
        public void CurveStatement_GivesCurveNode(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.MoveContext>(code);
            Ast res = _astBuilder.Visit(context);
            Assert.IsTrue(res is Curve);
        }

        [TestCase("curve from p1 to p2 with angle 10;", 1)]
        [TestCase("curve from p1 to p2 to p3 with angle 10;", 2)]
        [TestCase("curve from p1 to p2 to p3 to p4 with angle 10;", 3)]
        [TestCase("curve from p1 to p2 to p3 to p4 to p5 with angle 10;", 4)]
        public void Curve_GivesCurveNodeWithChainLength(string code, int expectedLength)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.CurveContext>(code);
            Curve res = (Curve) _astBuilder.Visit(context);
            Assert.IsTrue(res.ToChain.Count() == expectedLength);
        }


        [TestCase("repeat until 3 < 3 begin end loop;")]
        [TestCase("repeat until 3 > 3 begin end loop;")]
        [TestCase("repeat until 3 == 3 begin end loop;")]
        [TestCase("repeat until 3 < 3+3 begin end loop;")]
        [TestCase("repeat until 3 > 3*3 begin end loop;")]
        [TestCase("repeat until 3 == 3/3 begin end loop;")]
        [TestCase("repeat until 3 == 3^3 begin end loop;")]
        [TestCase("repeat until n < 3 begin end loop;")]
        [TestCase("repeat until n > 3 begin end loop;")]
        [TestCase("repeat until n == 3 begin end loop;")]
        [TestCase("repeat until n < q begin end loop;")]
        [TestCase("repeat until n > q begin end loop;")]
        [TestCase("repeat until n == q begin end loop;")]
        public void Until_GivesLoopNode(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.RepeatContext>(code);
            Loop res = (Loop) _astBuilder.Visit(context);
            Assert.IsTrue(res is Loop);
        }

        [TestCase("repeat until 3 < 3 begin end loop;", 0)]
        [TestCase("repeat until 3 < 3 begin a = 1; end loop;", 1)]
        [TestCase("repeat until 3 > 3 begin a = 1;a = 1; end loop;", 2)]
        [TestCase("repeat until 3 == 3 begin a = 1;a = 1;a = 1; end loop;", 3)]
        [TestCase("repeat until 3 < 3+3 begin a = 1;a = 1;a = 1;a = 1; end loop;", 4)]
        public void Until_GivesLoopNodeWithBodyLength(string code, int expected)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.RepeatContext>(code);
            Loop res = (Loop) _astBuilder.Visit(context);
            Assert.IsTrue(res.Body.Count() == expected);
        }

        [TestCase("iff 3 < 3 begin end if;")]
        [TestCase("iff 3 > 3 begin end if;")]
        [TestCase("iff 3 == 3 begin end if;")]
        [TestCase("iff 3 < 3+3 begin end if;")]
        [TestCase("iff 3 > 3*3 begin end if;")]
        [TestCase("iff 3 == 3/3 begin end if;")]
        [TestCase("iff 3 == 3^3 begin end if;")]
        [TestCase("iff n < 3 begin end if;")]
        [TestCase("iff n > 3 begin end if;")]
        [TestCase("iff n == 3 begin end if;")]
        [TestCase("iff n < q begin end if;")]
        [TestCase("iff n > q begin end if;")]
        [TestCase("iff n == q begin end if;")]
        public void If_GivesIf(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.IfContext>(code);
            Assert.IsTrue(_astBuilder.Visit(context) is If);
        }

        [TestCase("iff 3 < 3 begin end if;", 0)]
        [TestCase("iff 3 > 3 begin a = 1; end if;", 1)]
        [TestCase("iff 3 == 3 begin a = 1; a = 1; end if;", 2)]
        [TestCase("iff 3 < 3+3 begin a = 1; a = 1;a = 1; end if;", 3)]
        [TestCase("iff 3 > 3*3 begin a = 1; a = 1; a = 1;a = 1;end if;", 4)]
        public void If_GivesIfNodeWithBodyLength(string code, int expected)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.IfContext>(code);
            If res = (If) _astBuilder.Visit(context);
            Assert.IsTrue(res.Body.Count() == expected);
        }

        [TestCase("iff 3 < 3 begin end if else begin end else;")]
        [TestCase("iff 3 > 3 begin end if else begin end else;")]
        [TestCase("iff 3 == 3 begin end if else begin end else;")]
        [TestCase("iff 3 < 3+3 begin end if else begin end else;")]
        [TestCase("iff 3 > 3*3 begin end if else begin end else;")]
        [TestCase("iff 3 == 3/3 begin end if else begin end else;")]
        [TestCase("iff 3 == 3^3 begin end if else begin end else;")]
        [TestCase("iff n < 3 begin end if else begin end else;")]
        [TestCase("iff n > 3 begin end if else begin end else;")]
        [TestCase("iff n == 3 begin end if else begin end else;")]
        [TestCase("iff n < q begin end if else begin end else;")]
        [TestCase("iff n > q begin end if else begin end else;")]
        [TestCase("iff n == q begin end if else begin end else;")]
        public void IfElse_GivesIfElse(string code)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.IfElseContext>(code);
            Ast result = _astBuilder.Visit(context);
            Assert.IsTrue(result is IfElse);
        }

        [TestCase("iff 3 < 3 begin  end if else begin end else;", 0)]
        [TestCase("iff 3 > 3 begin a = 1;end if else begin end else;", 1)]
        [TestCase("iff 3 == 3 begin a = 1;a = 1;end if else begin end else;", 2)]
        [TestCase("iff 3 < 3+3 begin a = 1;a = 1;a = 1;end if else begin end else;", 3)]
        [TestCase("iff 3 > 3*3 begin a = 1;a = 1;a = 1;a = 1;end if else begin end else;", 4)]
        public void IfElse_GivesTrueBodyWithLength(string code, int expected)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.IfElseContext>(code);
            IfElse res = (IfElse) _astBuilder.Visit(context);
            Assert.IsTrue(res.Body.Count() == expected);
        }

        [TestCase("iff 3 < 3 begin end if else begin end else;", 0)]
        [TestCase("iff 3 > 3 begin end if else begin a = 1;end else;", 1)]
        [TestCase("iff 3 == 3 begin end if else begin a = 1;a = 1;end else;", 2)]
        [TestCase("iff 3 < 3+3 begin end if else begin a = 1;a = 1;a = 1;end else;", 3)]
        [TestCase("iff 3 > 3*3 begin end if else begin a = 1;a = 1;a = 1;a = 1;end else;", 4)]
        public void IfElse_GivesElseBodyWithLength(string code, int expected)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.IfElseContext>(code);
            IfElse res = (IfElse) _astBuilder.Visit(context);
            Assert.IsTrue(res.ElseBody.Count() == expected);
        }

        [TestCase("b>2")]
        [TestCase("b<2")]
        [TestCase("b==2")]
        [TestCase("b>2+2")]
        [TestCase("b<2+2")]
        [TestCase("b==2+2")]
        [TestCase("2+2>b")]
        [TestCase("2+2<b")]
        [TestCase("2+2==b")]
        [TestCase("2>b")]
        [TestCase("2<b")]
        [TestCase("2==b")]
        public void InfixBoolNode_GiveCorrectLhsAndRhs(string code)
        {
            var cont = CreateContext<RGCodeParser.BoolContext>(code);
            var result =(InfixBool) _astBuilder.Visit(cont);
            Assert.AreNotEqual(result.LeftHandSide, result.RightHandSide);
            
        }

    }

    //Fixture tests
    public partial class AstBuilderTest
    {

        [TestCase("Lines.txt","Correct programs")]
        [TestCase("Assignments.txt","Correct programs")]
        [TestCase("Curve.txt","Correct programs")]
        [TestCase("Declarations.txt","Correct programs")]
        [TestCase("Lines.txt","Correct programs")]
        [TestCase("Empty loop.txt","Correct programs/Loop")]
        [TestCase("Loop with statements.txt","Correct programs/Loop")]
        [TestCase("Empty if.txt","Correct programs/If")]
        [TestCase("Empty ifelse.txt","Correct programs/If")]
        [TestCase("If with statements.txt","Correct programs/If")]
        [TestCase("Ifelse with statements.txt","Correct programs/If")]
        [TestCase("Compound arithmetics.txt","Correct programs/Expressions")]
        [TestCase("Basic arithmetics.txt","Correct programs/Expressions")]
        [TestCase("Points.txt","Correct programs/Expressions")]
        public void Fixture_GivesProgramNode(string file,string fixtureSubDir)
        {
            ParserRuleContext context = CreateContext<RGCodeParser.ProgramContext>(file, fixtureSubDir);
            Ast result = _astBuilder.Visit(context);
            Assert.IsTrue(result is Program);

        }
    }
}