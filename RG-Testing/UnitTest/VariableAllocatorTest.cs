using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Antlr4.Runtime;
using NUnit.Framework;
using RG_code.AST;
using RG_code.AstVisitors;
using RG_code.AstVisitors.Visitor_Interfaces;
using RG_testing.HelperClasses;

namespace RG_testing.UnitTest
{
    [TestFixture]
    public class VariableAllocatorVisitorTest : TypeDependable
    {
        [TestCase("number p  = 1;",1)]
        [TestCase("number p  = 0;",1)]
        [TestCase("number p  = -1;",1)]
        [TestCase("number p  = 2;",1)]
        [TestCase("number p  = 2;",1)]
        [TestCase("number p  = 10;",1)]
        [TestCase("number p  = -10;",1)]
        [TestCase("number p  = 100;",1)]
        [TestCase("number p  = -100;",1)]
        [TestCase("number p  = 100000;",1)]
        [TestCase("number p  = -100000;",1)]
        [TestCase("number p  = 1; number q = 2;",2)]
        [TestCase("number p  = 1; number q = 2; number w = 2;",3)]
        [TestCase("number p  = 1; number q = 2; number t  = 2; number w = 2;",4)]
        [TestCase("number p  = 1; number q = 2; number g = 2; number j = 2; number h = 2;",5)]
        public void NumberDeclarations_AddsOneToVariableCounter(string code, int expectedNumberOfVars)
        {
            var result = CountNeededVariables<Program, RGCodeParser.ProgramContext>(code);
            Assert.AreEqual(expectedNumberOfVars, result.MaxNeededVariables);
        }
        
        [TestCase("point p1= (1,1);",2)]
        [TestCase("point p1= (1,1);point p2  = (1,1);",4)]
        [TestCase("point p1= (1,1);point p2  = (1,1);point p3  = (1,1);",6)]
        [TestCase("point p1 = (1,1);point p2  = (1,1);point p3  = (1,1);point p4  = (1,1);",8)]
        [TestCase("point p1  = (1,1);point p2  = (1,1);point p3  = (1,1);point p4  = (1,1);point p5  = (1,1);",10)]
        public void PointDeclarations_AddsTwoToVariableCounter(string code, int expectedNumberOfVars)
        {
            var result = CountNeededVariables<Program, RGCodeParser.ProgramContext>(code);
            Assert.IsTrue(result.DeclarationCount % 2 == 0);
            Assert.AreEqual(expectedNumberOfVars, result.MaxNeededVariables);
        }

        [TestCase("number b = 1; repeat until b < 2 begin end loop;",1)]
        [TestCase("point q = 1; line from q to (2,1);",1)]
        [TestCase("number b = 2; number a = 1; point q = (a,b);",3)]
        [TestCase("point q = (1,1); number b = 1; number a = 2; repeat until a < 1 begin point p = (2,a); point p2 = q;" +
                  " end loop; line from q to (b,1);",8)]
        public void Usage_GivesCorrectMaxNeededVariables(string code, int expected)
        {
            var result = CountNeededVariables<Program, RGCodeParser.ProgramContext>(code);
            Assert.AreEqual(expected,result.MaxNeededVariables);
        }

        private IVariableCounterVisitor<Ast> CountNeededVariables<TAst, TContext>(string code) 
            where TAst : Ast
            where TContext : ParserRuleContext
        {
            TAst ast = CreateAst<TAst, TContext>(code);
            IVariableCounterVisitor<Ast> counter = new VariableAllocatorVisitor<Ast>(TypeChecker.ScopeStack);
            counter.Visit((dynamic)ast);
            return counter;
        }
        
    }
}