using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class InfixMath : Infix, IInfixMathVisitable<Ast>
    {
        public InfixMath(Ast lhs, Ast rhs, IToken token) : base(token)
        {
            LeftHandSide = lhs;
            RightHandSide = rhs;
            Children.Add(lhs);
            Children.Add(rhs);

            foreach (IAst child in Children) child.Parent = this;
        }

        public InfixMath(Ast lhs, Ast rhs, IToken token, IAst parent) : base(parent, token)
        {
            LeftHandSide = lhs;
            RightHandSide = rhs;
            Children.Add(lhs);
            Children.Add(rhs);

            foreach (IAst child in Children) child.Parent = this;
        }

        public Ast LeftHandSide { get; set; }
        public Ast RightHandSide { get; set; }
        public abstract Ast Accept(IInfixMathVisitor<Ast> visitor);
    }
}