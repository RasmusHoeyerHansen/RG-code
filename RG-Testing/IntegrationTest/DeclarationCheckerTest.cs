using System.Linq;
using NUnit.Framework;
using RG_code.AST;
using RG_code.AstVisitors;
using RG_testing.HelperClasses;
using static RG_code.AST.Type;

namespace RG_testing
{
    [TestFixture]
    public partial class DeclarationCheckerTest : AstDependable
    {
        private DeclarationChecker _declarationChecker;

        [SetUp]
        public void SetUp()
        {
            _declarationChecker = new DeclarationChecker();
        }

        public void TearDown()
        {
            _declarationChecker = null;
        }
        
        [TestCase("point b = (2,2); point b = (2,2);")]
        [TestCase("number b = 2; number b = 2;")]
        public void Error_ReportsDoubleDeclarations(string declarationText)
        {
            Ast ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            _declarationChecker.Visit((dynamic)ast);
            Assert.IsTrue(_declarationChecker.Errors.Count() != 0);
        }
        
        
        
        [TestCase("point b = (2,2); number b = 2;",1)]
        [TestCase("point b = (2,2); number b = 2;number b = 2;",2)]
        [TestCase("point b = (2,2); number b = 2;number b = 2;number b = 2;",3)]
        [TestCase("point b = (2,2); number b = 2;number b = 2;number b = 2;number b = 2;",4)]
        public void Error_ReportsNumberOfExpectedDoubleDeclarationErrors(string declarationText, int expectedErrors)
        {
            var ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            _declarationChecker.Visit((dynamic)ast);

            bool allAreDoubleDeclError = _declarationChecker.Errors.All(err =>
            {
                return err.TypeOfError == TypeError.ErrorType.DoubleDeclared;
            });
            
            Assert.IsTrue(_declarationChecker.Errors.Count() == expectedErrors);
            Assert.IsTrue(allAreDoubleDeclError);
            
        }
        
        [TestCase("point b = (2,2); number b = 2;")]
        [TestCase("number b = 2; point b = (2,0);")]
        public void Error_ReportsSameNameDeclarations(string declarationText)
        {
            Program ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            _declarationChecker.Visit((dynamic)ast);
            Assert.IsTrue(_declarationChecker.Errors.Count() != 0);
            
            bool allAreDoubleDeclError = _declarationChecker.Errors.All(err =>
            {
                return err.TypeOfError == TypeError.ErrorType.DoubleDeclared;
            });
            Assert.IsTrue(allAreDoubleDeclError);
        }
        
        [TestCase("point b = (2,2); number b = 2;")]
        [TestCase("number b = 2; point b = (2,0);")]
        public void Error_ReportsExpectedNumberOfSameNameDeclarations(string declarationText)
        {
            Program ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            _declarationChecker.Visit((dynamic)ast);
            Assert.IsTrue(_declarationChecker.Errors.Count() != 0);
            bool allAreDoubleDeclError = _declarationChecker.Errors.All(err =>
            {
                return err.TypeOfError == TypeError.ErrorType.DoubleDeclared;
            });
            Assert.IsTrue(allAreDoubleDeclError);
        }
        
        [TestCase("point b = (2,a);", 1)]
        [TestCase("point b = (a,2);", 1)]
        [TestCase("point b = b;", 1)]
        [TestCase("number b = a;",1)]
        [TestCase("number b = b;",1)]
        [TestCase("number b = a; number a = 2;",1)]
        [TestCase("point p = (a,a); number a = 2;",2)]
        [TestCase("repeat until b < 2 begin end loop;",1)]
        [TestCase("repeat until b < 2 begin number b = a; end loop;",2)]
        [TestCase("repeat until b < 2 begin number b = a; end loop; number b = b;",3)]
        [TestCase("iff b<2 begin end if;",1)]
        [TestCase("iff b<2 begin end if; number b = a;",2)]
        [TestCase("iff b<2 begin number b = a; end if;",2)]
        [TestCase("iff b<2 begin number b = a; end if; number b=a;",3)]
        [TestCase("iff b<2 begin end if else begin end else;",1)]
        [TestCase("iff b<2 begin number b = a; end if else begin end else;",2)]
        [TestCase("iff b<2 begin  end if else begin number b = a; end else;",2)]
        [TestCase("iff b<2 begin number b = a; end if else begin number q = h; end else; number a = b;",4)]
        public void Error_ReportsNotDeclaredOnUsageInExpression(string declarationText, int expectedErrors)
        {
            //Arrange
            var ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            //Act
            _declarationChecker.Visit((dynamic)ast);
            
            //Assert
            bool allAreNotDeclError = _declarationChecker.Errors.All(err =>
            {
                return err.TypeOfError == TypeError.ErrorType.NotDeclared;
            });
            
            Assert.AreEqual(_declarationChecker.Errors.Count(), expectedErrors);
            Assert.IsTrue(allAreNotDeclError);
        }


        [TestCase("number b = 1;")]
        [TestCase("number b = (1,1);")]
        [TestCase("number b = 2<3;")]
        public void Type_NumberDeclarationIsTypeNumber(string code)
        {
            //Arrange
            Ast ast = CreateAst<Declaration, RGCodeParser.VardecContext>(code);
            //Act
            _declarationChecker.Visit((dynamic)ast);

            Assert.IsTrue(ast.Type == Type.Number);
        }
        

        [TestCase("point b = (1,1);")]
        [TestCase("point b = 1;")]
        [TestCase("point b = 2<3;")]
        public void Type_NumberDeclarationIsTypePoint(string code)
        {
            //Arrange
            var ast = CreateAst<Declaration, RGCodeParser.VardecContext>(code);
            //Act
            _declarationChecker.Visit((dynamic)ast);
            Assert.IsTrue(ast.Type == Type.Point);
        }

        [TestCase("line from (0,0) to (0,1);", 0)]
        [TestCase("line from (a,0) to (0,1);", 1)]
        [TestCase("line from (2,2) to p2;", 1)]
        [TestCase("line from p1 to p2 to p3;", 3)]
        [TestCase("line from p1 to p2 to p3 to p4;", 4)]
        [TestCase("line from p1 to p2 to p3 to p4 to p5;", 5)]
        public void Line_ReportsTypeErrors(string code, int amountOfErrors)
        {
            Line ast = CreateAst<Line, RGCodeParser.LineContext>(code);
            //Act
            _declarationChecker.Visit(ast);
            
            var allErrorCorrect = _declarationChecker.Errors.All(err =>
            {
                return err.TypeOfError == TypeError.ErrorType.NotDeclared;
            });
            
            Assert.AreEqual(amountOfErrors, _declarationChecker.Errors.Count());
            Assert.IsTrue(allErrorCorrect);
        }
        
        [TestCase("curve from p1 to p2 with angle 10;", 2)]
        [TestCase("curve from p1 to p2 to p3 with angle 10;", 3)]
        [TestCase("curve from p1 to p2 to p3 to p4 with angle 10;", 4)]
        [TestCase("curve from p1 to p2 to p3 to p4 to p5 with angle 10;", 5)]
        
        [TestCase("curve from p1 to p2 with angle b;", 3)]
        [TestCase("curve from p1 to p2 to p3 with angle b;", 4)]
        [TestCase("curve from p1 to p2 to p3 to p4 with angle b;", 5)]
        [TestCase("curve from p1 to p2 to p3 to p4 to p5 with angle b;", 6)]
        public void Curve_GivesCurveNodeWithChainLength(string code, int amountOfErrors)
        {
            Curve ast = CreateAst<Curve, RGCodeParser.CurveContext>(code);
            //Act
            _declarationChecker.Visit((dynamic) ast);
            
            var allErrorCorrect = _declarationChecker.Errors.All(err =>
            {
                return err.TypeOfError == TypeError.ErrorType.NotDeclared;
            });
            
            Assert.AreEqual(amountOfErrors, _declarationChecker.Errors.Count());
            Assert.IsTrue(allErrorCorrect);
        }
        
       
    }

    public partial class DeclarationCheckerTest

    {

        [TestCase("Lines.txt", "Correct programs")]
        [TestCase("Assignments.txt", "Correct programs")]
        [TestCase("Curve.txt", "Correct programs")]
        [TestCase("Declarations.txt", "Correct programs")]
        [TestCase("Lines.txt", "Correct programs")]
        [TestCase("Empty loop.txt", "Correct programs/Loop")]
        [TestCase("Loop with statements.txt", "Correct programs/Loop")]
        [TestCase("Empty if.txt", "Correct programs/If")]
        [TestCase("Empty ifelse.txt", "Correct programs/If")]
        [TestCase("If with statements.txt", "Correct programs/If")]
        [TestCase("Ifelse with statements.txt", "Correct programs/If")]
        [TestCase("Compound arithmetics.txt", "Correct programs/Expressions")]
        [TestCase("Basic arithmetics.txt", "Correct programs/Expressions")]
        [TestCase("Points.txt", "Correct programs/Expressions")]
        public void Fixture_GivesProgramNode(string file, string fixtureSubDir)
        {
            Ast ast = CreateAst<Program, RGCodeParser.ProgramContext>(file, fixtureSubDir);
            _declarationChecker.Visit((dynamic) ast);
            Assert.IsTrue(ast is Program);

            Assert.AreEqual(0, _declarationChecker.Errors.Count);


        }


    }
}