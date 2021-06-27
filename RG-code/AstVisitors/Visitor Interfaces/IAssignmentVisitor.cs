namespace RG_code.AST
{
    public interface IAssignmentVisitor<out T>
    {
        public T Visit(Assign node);
    }
}