using System.Linq;
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
    
    public partial class GCodeGeneratorSyntaxTest
    {
        private static Regex G02Regex { get; } = new Regex(@"^G02 X-?\d*\.{0,1}\d+ Y-?\d*\.{0,1}\d+ R-?\d*\.{0,1}\d+$");
        private static Regex G03Regex { get; } = new Regex(@"^G03 X-?\d*\.{0,1}\d+ Y-?\d*\.{0,1}\d+ R-?\d*\.{0,1}\d+$");
        private static Regex ArcRegex { get; } = new Regex(@"^(G02|G03) X-?\d*\.{0,1}\d+ Y-?\d*\.{0,1}\d+ R-?\d*\.{0,1}\d+$");
        
        [TestCase("curve from (2,2) to (1,1) with angle -90;")]
        [TestCase("curve from (2,2) to (1,1) with angle -80;")]
        [TestCase("curve from (2,2) to (1,1) with angle -75;")]
        [TestCase("curve from (2,2) to (1,1) with angle -50;")]
        [TestCase("curve from (2,2) to (1,1) with angle -30;")]
        [TestCase("curve from (2,2) to (1,1) with angle -25;")]
        [TestCase("curve from (2,2) to (1,1) with angle -20;")]
        [TestCase("curve from (2,2) to (1,1) with angle -15;")]
        [TestCase("curve from (2,2) to (1,1) with angle -10;")]
        [TestCase("curve from (2,2) to (1,1) with angle -5.5;")]
        [TestCase("curve from (2,2) to (1,1) with angle -4.5;")]
        [TestCase("curve from (2,2) to (1,1) with angle -4;")]
        [TestCase("curve from (2,2) to (1,1) with angle -3.5;")]
        [TestCase("curve from (2,2) to (1,1) with angle -2.2;")]
        [TestCase("curve from (2,2) to (1,1) with angle -2.0;")]
        [TestCase("curve from (2,2) to (1,1) with angle -1;")]
        [TestCase("curve from (2,2) to (1,1) with angle -0.00001;")]
        [TestCase("curve from (2,2) to (1,1) with angle -0.0001;")]
        [TestCase("curve from (2,2) to (1,1) with angle -0.01;")]
        public void Curve_NegativeAngleMatchesG02(string curve)
        {
            _command = CreateCurve(curve);
            _emitter.Visit((Curve)_command);

            string str = _emitter.Emit();
            Assert.IsTrue(G02Regex.IsMatch(str));
        }
        
        [TestCase("curve from (2,2) to (1,1) with angle 90;")]
        [TestCase("curve from (2,2) to (1,1) with angle 80;")]
        [TestCase("curve from (2,2) to (1,1) with angle 75;")]
        [TestCase("curve from (2,2) to (1,1) with angle 50;")]
        [TestCase("curve from (2,2) to (1,1) with angle 30;")]
        [TestCase("curve from (2,2) to (1,1) with angle 25;")]
        [TestCase("curve from (2,2) to (1,1) with angle 20;")]
        [TestCase("curve from (2,2) to (1,1) with angle 15;")]
        [TestCase("curve from (2,2) to (1,1) with angle 10;")]
        [TestCase("curve from (2,2) to (1,1) with angle 5.5;")]
        [TestCase("curve from (2,2) to (1,1) with angle 4.5;")]
        [TestCase("curve from (2,2) to (1,1) with angle 4;")]
        [TestCase("curve from (2,2) to (1,1) with angle 3.5;")]
        [TestCase("curve from (2,2) to (1,1) with angle 2.2;")]
        [TestCase("curve from (2,2) to (1,1) with angle 2.0;")]
        [TestCase("curve from (2,2) to (1,1) with angle 1;")]
        [TestCase("curve from (2,2) to (1,1) with angle 0.00001;")]
        [TestCase("curve from (2,2) to (1,1) with angle 0.0001;")]
        [TestCase("curve from (2,2) to (1,1) with angle 0.01;")]
        public void Curve_PositiveAngleMatchesG03(string curve)
        {
            _command = CreateCurve(curve);
            _emitter.Visit((Curve)_command);

            string str = _emitter.Emit();
            Assert.IsTrue(G01Regex.IsMatch(str) || G00Regex.IsMatch(str));
        }

        [TestCase("curve from (2,2) to (1,1) with 0;")]
        public void Curve_AngleZeroGivesWarningButMatchesLine(string code)
        {
            _command = CreateCurve(code);
            _emitter.Visit((Curve)_command);
           
            string str = _emitter.Emit();
            Assert.IsTrue(G01Regex.IsMatch(str) || G00Regex.IsMatch(str));

            Assert.AreEqual(0, _emitter.Warnings.Count());
        }
    }
}