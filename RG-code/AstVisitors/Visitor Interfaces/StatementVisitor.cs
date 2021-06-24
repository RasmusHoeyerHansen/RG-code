using RG_code.AST;

namespace RG_code.AstVisitors.Visitor_Interfaces
{
    public interface StatementVisitor<out T> : IMovementVisitor<T>, IDeclarationVisitor<T>, ILoopVisitor<T> where T : Ast
    {
        
    }
}