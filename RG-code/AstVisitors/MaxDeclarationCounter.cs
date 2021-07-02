using System.Collections.Generic;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;

namespace RG_code.AstVisitors
{
    public abstract class MaxDeclarationCounter<TKey, TValue> : StackDeclarationTracker<TKey, TValue>, IVariableCounter<TKey, TValue>
    where TValue : Ast
    {
        private int _maxNeededVariables = 0;
        public int MaxNeededVariables
        {
            get => _maxNeededVariables;
            set
            {
                if (value > _maxNeededVariables)
                {
                    _maxNeededVariables = value;
                }
            }
        }

        public MaxDeclarationCounter(Stack<Scope<TKey, TValue>> stack) : base(stack)
        {
        }

        public virtual int DeclarationCount { get; protected set; }
        
    }
}