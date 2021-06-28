using System;
using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public class Ast : IAst
    {
        public Type Type { get; set; } = Type.NotDeclared;

        public Ast(IAst parent, IToken token) : this(token)
        {
            Parent = parent;
        }

        public Ast(IToken token)
        {
            Information = token;
            Children = new List<IAst>();
        }

        public IToken Information { get; set; }
        public IAst Parent { get; set; }
        public IList<IAst> Children { get; set; }

        public override string ToString()
        {
            return $"position at line {Information.Line}, column {Information.Column}";
        }

        public override bool Equals(object? obj)
        {
            //If they cannot be compared, since they are different objects.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            { 
                return false;
            }
            else
            {
                Ast other = (Ast) obj;
                return (this.Information.ToString() == other.Information.ToString()) && (this.Parent == other.Parent);
            }
        }
        
    }
}