using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Declaration : Statement, IDeclarationVisitable<Ast>
    {
        public string Name { get; private set; }

        public Declaration(Ast assignedValue, IToken information) : base(information)
        {
            AssignedValue = (Assign) assignedValue;
            AssignedValue.Parent = this;
            Children.Add(assignedValue);
            Name = AssignedValue.Id;
        }

        public Assign AssignedValue { get; set; }
        public Ast Accept(IDeclarationVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        
        public override string ToString()
        {
            
            return $"{Name} " + base.ToString();
        }
    }
}