using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Number : Expression
    {
        public double Value { get;}

        public Number(double value, IToken information) : base(information)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "Number " + base.ToString();
        }
    }
}