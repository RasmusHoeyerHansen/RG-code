﻿using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class GCodeGenerator : IMovementEmitter
    {
        public Ast Visit(Program node)
        {
            throw new System.NotImplementedException();
        }


        public Ast Visit(Plus node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Minus node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Multiplication node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Divide node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Power node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Number node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Point node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Line node)
        {
            throw new System.NotImplementedException();
        }

        public Ast Visit(Curve node)
        {
            throw new System.NotImplementedException();
        }

        public string Emit()
        {
            throw new System.NotImplementedException();
        }

        public IList<Pair<Ast, string>> AstGCodePairs { get; set; }

        public Pair<Ast, string> CreatePair(Ast node, string gCode)
        {
            return new Pair<Ast, string>(node, gCode);
        }

        public IList<Warning> Warnings { get; }
    }

    public interface IEmitter
    {
        public string Emit();
        public IList<Pair<Ast, string>> AstGCodePairs { get; set; }
        public Pair<Ast, string> CreatePair(Ast node, string gCode);

        public IList<Warning> Warnings { get; }
    }

    public class Warning
    {
        public Warning(string warningMessage)
        {
            WarningMessage = warningMessage;
        }

        private string WarningMessage { get; set; }
    }

    public interface IArcEmitter : IEmitter, ICurveVisitor<Ast>
    {
        
    }
    
    public interface ILineEmitter : IEmitter, ILineVisitor<Ast>
    {}

    public interface IMovementEmitter :ILineEmitter, IArcEmitter,  IMovementVisitor<Ast>
    {
        
    }
    

    
    
}