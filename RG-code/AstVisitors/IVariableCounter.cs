using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors.Visitor_Interfaces
{
    public interface IVariableCounter<Key, Value> : IStackTraveller<Key, Value>
    {
        public int MaxNeededVariables { get; }
        public int DeclarationCount { get; }
    }

    public interface IVariableCounterVisitor<TReturn> : IVariableCounter<string, Declaration>, IStatementVisitor<TReturn>, IProgramVisitor<TReturn>
    where TReturn : Ast
    {
        
    }
}