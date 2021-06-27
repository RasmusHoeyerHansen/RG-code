using RG_code.AST;

namespace RG_code.AstVisitors.Visitor_Interfaces
{
    public interface IFullVisitor<out T> : IMovementVisitor<T>, IMathVisitor<T>, ILoopVisitor<T>, IProgramVisitor<T>,
        IDeclarationVisitor<T>,
        IIfVisitor<T>, IBoolVisitor<T>, IExpressionVisitor<T> where T : Ast
    {
    }
}