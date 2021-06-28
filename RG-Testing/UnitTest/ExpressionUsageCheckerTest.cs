using System.Linq;
using NUnit.Framework;
using RG_code.AST;
using RG_code.AstVisitors;
using RG_testing.HelperClasses;

namespace RG_testing
{
    [TestFixture]
    public class ExpressionUsageCheckerTest : DeclarationDependable
    {
        

        
        
        [TestCase("number b = 2<3;",1)]
        [TestCase("number b = 2>3;",1)]
        [TestCase("number b = 2==3;",1)]
        [TestCase("number b = (2,3);",1)]
        [TestCase("point b = 2",1)]
        [TestCase("point b = 2<3;",1)]
        [TestCase("point b = 2>3;",1)]
        [TestCase("point b = 2==3;",1)]
        public void Error_ReportsTypeMismatchInDeclarations(string declarationText, int expectedNumberOfErrors)
        {
            Ast ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit((dynamic) ast);

            var allWrong = ast.Children.All(n =>
            {
                return n.Type == Type.Wrong;
            });
            
            Assert.IsTrue(allWrong);
        }
        
        [TestCase("number b = 2<3;")]
        [TestCase("number b = 2>3;")]
        [TestCase("number b = 2==3;")]
        [TestCase("point b = 2<3;")]
        [TestCase("point b = 2>3;")]
        [TestCase("point b = 2==3;")]
        public void Bool_SetsBoolTypeForRHS(string declarationText)
        {
            Declaration ast = CreateAst<Declaration, RGCodeParser.VardecContext>(declarationText);
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit(ast);
            Assert.IsTrue(ast.Assignment.Value.Type == Type.Bool);
        }
        
        [TestCase("number b = 3;")]
        [TestCase("number b = 3;")]
        [TestCase("number b = 3;")]
        [TestCase("point b = 3;")]
        [TestCase("point b = 3;")]
        [TestCase("point b = 3;")]
        public void Number_SetsNumberTypeForRHS(string declarationText)
        {
            Declaration ast = CreateAst<Declaration, RGCodeParser.VardecContext>(declarationText);
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit(ast);
            Assert.IsTrue(ast.Assignment.Value.Type == Type.Number);
        }

        
        [TestCase("number b = (3,3);")]
        [TestCase("number b = (3+3+3+3+3,3);")]
        [TestCase("number b = (3,3+3+3+3+3);")]

        [TestCase("number b = (3,3);")]
        [TestCase("point b = (3,3);")]
        [TestCase("point b = (3,3);")]
        [TestCase("point b = (3,3);")]
        public void Point_SetsPointTypeForRHS(string declarationText)
        {
            Declaration ast = CreateAst<Declaration, RGCodeParser.VardecContext>(declarationText);
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit(ast);
            Assert.IsTrue(ast.Assignment.Value.Type == Type.Point);
        }
        
        [TestCase("number b = (3,3);")]
        [TestCase("number b = (3,3);")]
        [TestCase("number b = (3,3);")]
        [TestCase("point b = (3,3);")]
        [TestCase("point b = (3,3);")]
        [TestCase("point b = (3,3);")]
        public void Error_SetsPointTypeForRHS(string declarationText)
        {
            Declaration ast = CreateAst<Declaration, RGCodeParser.VardecContext>(declarationText);
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit(ast);
            Assert.IsTrue(ast.Assignment.Value.Type == Type.Point);
        }

        
        [TestCase("number b = 2; b = 2<2;", 1)]
        [TestCase("number b = 2; b = (2,2);", 1)]
        [TestCase("point b = (3,3); b = 2<2;",1)]
        [TestCase("point b = (3,3); b = 2;",1)]
        public void Error_wrongAssignment(string declarationText, int expectedErrs)
        {
            Program ast = CreateAst<Program, RGCodeParser.ProgramContext>(declarationText);
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit(ast);
            Assert.AreEqual(expectedErrs, checker.Errors.Count());
        }
        
        [TestCase("line from (b,2) to (2,2);", 1)]
        [TestCase("line from (2,2) to b;", 1)]
        [TestCase("line from (2,2) to (b,2) to (2,2);", 1)]
        public void Line_ReportsTypeErrors(string code, int amountOfErrors)
        {
            Line ast = CreateAst<Line, RGCodeParser.LineContext>(code);

            //Act
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit(ast);
            
            Assert.IsTrue(ast.Type == Type.Wrong);
            Assert.AreEqual(amountOfErrors, checker.Errors.Count());
        }

        [TestCase("2<2")]
        [TestCase("2<2+2+2+2+2")]
        [TestCase("2<-1")]
        [TestCase("2==-2.111")]
        [TestCase("2>2")]
        public void Bool_GivesBoolTypeWhenCorrect(string code)
        {
            Expression ast = CreateAst<Expression, RGCodeParser.BoolContext>(code);

            //Act
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit((dynamic)ast);

            Assert.AreEqual(0, checker.Errors.Count());
            Assert.IsTrue(ast.Type == Type.Bool);
        }
        
        [TestCase("(1^(1 - 1.0000000),1^(1 - 1.0000000))")]
        [TestCase("((1)-(1),(1)-(1))")]
        [TestCase("((1)*1,(1)*1)")]
        [TestCase("(1/(1),1/(1))")]
        [TestCase("((1+1),(1+1) ) ")]
        [TestCase("((1),(1))")]
        [TestCase("((1)*1,(1)*1) ")]
        [TestCase("(1/(1), 1/(1))")]
        [TestCase("((1^1)^2,(1^1)^2)")]
        [TestCase("((2^2),(2^2)")]
        [TestCase("((22), (22))")]
        [TestCase("(1+1+1, 1-1-1)")]
        [TestCase("(1^1^2, 1^1^2)")]
        public void Point_GivesPointTypeWhenCorrect(string code)
        {
            Expression ast = CreateAst<Expression, RGCodeParser.PointContext>(code);

            //Act
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit((dynamic)ast);

            Assert.AreEqual(0, checker.Errors.Count());
            Assert.IsTrue(ast.Type == Type.Point);
        }
        
        [TestCase("1^(1 - 1.0000000)")]
        [TestCase("(1)-(1)")]
        [TestCase("(1)*1")]
        [TestCase("1/(1)")]
        [TestCase("(1+1)")]
        [TestCase("(1)-(1)")]
        [TestCase("(1)*1")]
        [TestCase("1/(1)")]
        [TestCase("(1^1)^2")]
        [TestCase("(2^2)")]
        [TestCase("(22)")]
        [TestCase("1+1+1")]
        [TestCase("1^1^2")]
        [TestCase("2/2")]
        [TestCase("2-2")]
        [TestCase("22^9999999")]
        public void Number_GivesNumberTypeWhenCorrect(string code)
        {
            Expression ast = CreateAst<Expression, RGCodeParser.MathContext>(code);

            //Act
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit((dynamic)ast);

            Assert.AreEqual(0, checker.Errors.Count());
            Assert.IsTrue(ast.Type == Type.Number);
        }
        
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
            Program ast = CreateAst<Program, RGCodeParser.ProgramContext>(file, fixtureSubDir);

            //Act
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit((dynamic)ast);

            Assert.IsTrue(ast.Type == Type.Ok);
            var allStatementOkay = ast.ProgramStatements.All(n => n.Type != Type.Wrong);
            Assert.IsTrue(allStatementOkay);
            
        }

        [TestCase("number q = 0; number x = q;")]
        [TestCase("number q = 0; number x = q; q = 0;")]
        [TestCase("number q = 0; number x = q; q = x; q = - 11;")]
        

        [TestCase("number q = 0; number x = q; point = (q,x);")]
        [TestCase("number q = 0; number x = q; point a = (q,x); point b = a;")]
        [TestCase("number q = 0; number x = q; point a = (q,x); point b = a; b = a;")]
        [TestCase("number q = 0; number x = q; point a = (q,x); a = (q,x);")]

        public void UseVariables_GivesNotWrong(string code)
        {
            Program ast = CreateAst<Program, RGCodeParser.ProgramContext>(code);

            //Act
            ExpressionUsageChecker checker = new ExpressionUsageChecker(Scopes);
            checker.Visit((dynamic)ast);

            foreach (Ast astProgramStatement in ast.ProgramStatements)
            {
                Assert.IsTrue(astProgramStatement.Type != Type.Wrong);
            }
            
            
            
        }


        /*
         *         [TestCase("point b = 2",1)]
         *         [TestCase("number b = (2,3);",1)]
         */
    }
    
    
}