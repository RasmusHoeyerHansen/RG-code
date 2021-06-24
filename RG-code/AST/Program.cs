
using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Program : Ast, IProgramVisitable<Ast>
    {
        public IEnumerable<Ast> ProgramStatements { get; private set; }
        

        public Program(IEnumerable<Ast> statements, IToken token) : base(null,token)
        {
            ProgramStatements = statements;
            foreach (Ast statement in statements)
            {
                statement.Parent = this;
                Children.Add(statement);
            }

        }

        public Ast Accept(IProgramVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {

            return "Start node";
        }
    }
}