using System.Text.RegularExpressions;
using NUnit.Framework;
using RG_code.AST;
using RG_code.AstVisitors;
using RG_testing.HelperClasses;

namespace RG_testing.UnitTest
{
    [TestFixture]
    public partial class GCodeGeneratorSyntaxTest : MovementDependable
    {
        private static Regex G00Regex { get; } = new Regex(@"^G00 X-?\d*\.{0,1}\d+ Y-?\d*\.{0,1}\d+$");
        private static Regex G01Regex { get; } = new Regex(@"^G01 X-?\d*\.{0,1}\d+ Y-?\d*\.{0,1}\d+$");

        private IMovementEmitter _emitter;
        private Movement _command { get; set; }

        [SetUp]
        public void SetUp()
        {
            
            _emitter = new GCodeGenerator();
        }

        [TestCase("line from (2,2) to (1,1);")]
        [TestCase("line from (2,2) to (1,1) to (1,1);")]
        [TestCase("line from (-2,2 + 2) to (1,1);")]
        public void Line_MatchesG00OrG01Syntax(string line)
        {
            _command = CreateLine(line);
            _emitter.Visit((Line)_command);

            string str = _emitter.Emit();
            Assert.IsTrue(G01Regex.IsMatch(str) || G00Regex.IsMatch(str));
        }

    }
}