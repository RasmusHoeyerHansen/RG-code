using System;
using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Ast : IAst
    {
        public Ast(IAst parent, IToken token):this(token)
        {
            Parent = parent;
        }
        
        public Ast (IToken token)
        {
            
            Information = token;
            Children = new List<IAst>();
        }

        public IToken Information { get; set; }
        public IAst Parent { get; set; }
        public IList<IAst> Children { get; set; }

        public override string ToString()
        {
            return $"position at line {Information.Line}, column {Information.Column}";
        }
    }
}