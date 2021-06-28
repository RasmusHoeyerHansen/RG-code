using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Declaration : Statement
    {
        public string Name { get;  }

        public Declaration(Expression assignedValue, string name, IToken information) : base(information)
        {
            Value = assignedValue;
            assignedValue.Parent = this;
            Children.Add(assignedValue);
            Name = name;
        }

        public Declaration(Assign ass,  IToken info):this(ass.Value, ass.Id, info)
        {
            
        }
        public Expression Value { get; }

        public override string ToString()
        {
            return $"{Name} " + base.ToString();
        }
    }
}