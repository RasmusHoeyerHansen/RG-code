﻿using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Divide : InfixMath
    {
        public Divide(Ast lhs, Ast rhs, IToken token) : base(lhs, rhs, token)
        {
        }

        public override Ast Accept(IInfixMathVisitor<Ast> visitor)
        {
            return visitor.Visit(this);
        }

        public override string ToString()
        {
            return "Divide " + base.ToString();
        }
    }
}