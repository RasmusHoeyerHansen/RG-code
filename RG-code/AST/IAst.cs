using System.Collections.Generic;
using Antlr4.Runtime;

namespace RG_code.AST
{
    public interface IAst
    {
        public IToken Information { get; set; }
        public IAst Parent { get; set; }
        public IList<IAst> Children { get; set; }
        public Type Type { get; set; }
    }
}