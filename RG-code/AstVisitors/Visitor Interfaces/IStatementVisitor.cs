using RG_code.AST;

namespace RG_code.AstVisitors.Visitor_Interfaces
{
    public interface IStatementVisitor<out T> : IMovementVisitor<T>, IDeclarationVisitor<T>, ILoopVisitor<T>,
        IIfVisitor<T>
    {
        public T Visit(Statement statement);
    }
}