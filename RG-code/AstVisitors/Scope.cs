﻿using System.Collections.Generic;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    sealed internal class Scope
    {
        public Dictionary<string, Declaration> ContainedVariables { get; private set; } =
            new Dictionary<string, Declaration>();
        public Scope ParentScope { get; private set; }
        

        public Scope (Scope parentScope)
        {
            ParentScope = parentScope;
        }
        

    }
}