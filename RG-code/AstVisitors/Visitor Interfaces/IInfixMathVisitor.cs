namespace RG_code.AST
{
    public interface IInfixMathVisitor<out T>
    {
        
        public  T Visit(Plus node);
        public  T Visit(Minus node);
        public  T Visit(Multiplication node);
        public  T Visit(Divide node);
        public  T Visit(Power node);
    }
}