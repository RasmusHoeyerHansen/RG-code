using Antlr4.Runtime;

namespace RG_code.AST
{
    public abstract class InfixMath : Infix
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

        public Ast LeftHandSide { get;}
        public Ast RightHandSide { get;}
    }
}