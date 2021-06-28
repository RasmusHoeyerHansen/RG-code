using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Assign : Statement
    {
        public string Id { get;}

        public Assign(string id, Ast value, IToken information) : base(information)
        {
            Id = id;
            Value = value;
            Children.Add(value);
            Value.Parent = this;
        }

        public Type Type { get; set; }
        public Ast Value { get; }

        public override string ToString()
        {
            return "Assign " + base.ToString();
        }
    }
}