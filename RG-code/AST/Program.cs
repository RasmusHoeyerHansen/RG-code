using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Program : Ast
    {
        public IEnumerable<Ast> ProgramStatements { get; private set; }


        public Program(IEnumerable<Ast> statements, IToken token) : base(null, token)
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