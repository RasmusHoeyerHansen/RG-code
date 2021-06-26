using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Assign : Statement, IAssignVisitable<Ast>
    {
        public string Id { get; private set; }

        public Assign(string id, Ast value, IToken information) : base(information)
        {
            Id = id;
            Value = value;
            Children.Add(value);
            Value.Parent = this;
        }

        public Type Type { get; set; }
        public Ast Value { get; set; }
        public Ast Accept(IAssignmentVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }

        public override string ToString()
        {
            
            return "Assign " + base.ToString();
        }
    }
}