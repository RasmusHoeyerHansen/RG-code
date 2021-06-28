using Antlr4.Runtime;

namespace RG_code.AST
{
    public class NameReference : Expression
    {
        public string Name { get; }

        public NameReference(string Id, IToken information) : base(information)
        {
            Name = Id;
        }


        public override string ToString()
        {
            return "Id " + base.ToString();
        }
    }
}