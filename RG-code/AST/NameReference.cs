﻿using Antlr4.Runtime;

namespace RG_code.AST
{
    public class NameReference : Expression, IIdVisitable<Ast>
    {
        public string Name {get; set; }
        public NameReference(string Id, IToken information) : base(information)
        {
        }


        public Ast Accept(IIdVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            
            return "Id node " + base.ToString();
        }
    }
}