using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Program : Ast
    {
        public IEnumerable<Statement> ProgramStatements { get; private set; }


        public Program(IEnumerable<Statement> statements, IToken token) : base(null, token)
        {
            ProgramStatements = statements;
            foreach (Ast statement in statements)
            {
                statement.Parent = this;
                Children.Add(statement);
            }
        }

        public override string ToString()
        {
            return "Start node";
        }
    }
}