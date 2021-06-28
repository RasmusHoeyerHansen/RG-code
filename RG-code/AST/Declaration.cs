using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Declaration : Statement
    {
        public string Name { get;  }

        public Declaration(Ast assignedValue, IToken information) : base(information)
        {
            Assignment = (Assign) assignedValue;
            Assignment.Parent = this;
            Children.Add(assignedValue);
            Name = Assignment.Id;
        }

        public Assign Assignment { get; }
        public override string ToString()
        {
            return $"{Name} " + base.ToString();
        }
    }
}