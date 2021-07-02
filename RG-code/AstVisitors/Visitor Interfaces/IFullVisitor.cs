using RG_code.AST;

namespace RG_code.AstVisitors.Visitor_Interfaces
{
    public interface IFullVisitor<out T> :  IProgramVisitor<T>, IStatementVisitor<T>, IIfVisitor<T>, IBoolVisitor<T>, IExpressionVisitor<T>, IPointVisitor<T>, IMathVisitor<T>
    {
    }
}