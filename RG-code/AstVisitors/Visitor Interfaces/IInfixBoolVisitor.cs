namespace RG_code.AST
{
    public interface IInfixBoolVisitor<out T>
    {
        public T Visit(GreaterThan node);
        public T Visit(LessThan node);
        public T Visit(Equals node);
    }
}