using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Text;
using Antlr4.Runtime.Misc;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;
using Type = RG_code.AST.Type;

namespace RG_code.AstVisitors
{
    public class VariableAllocator : ScopeTraveller<string, Declaration>,IFullVisitor<string>
    {
        private int _maxVariables { get; }
        private InformationMapper InformationMapper { get; set; }
        private int AvailableVariables { get; set; }
        private Dictionary<string, Pair<int, int>> PointVarMap { get;  }
        private Dictionary<string, int> NumberVarMap { get;  }

        private StringBuilder Builder = new StringBuilder();
        private IEnumerable<DeclarationInformation> ScopeDeclarationInformation { get; set; }


        public VariableAllocator(Stack<Scope<string, Declaration>> stack, int availableVariables):base(stack)
        {
            _maxVariables = availableVariables;
            AvailableVariables = _maxVariables;
            InformationMapper = new InformationMapper(stack);
            PointVarMap = new Dictionary<string, Pair<int, int>>();
            NumberVarMap = new Dictionary<string, int>();
            InformationMapper.TraverseScope(GetStartScope());

        }

        public void TraverseScope(Scope<string,Declaration> scope)
        {
            ScopeDeclarationInformation = InformationMapper.ScopeDeclarationInfos[scope];
            foreach (Statement statement in scope.ContainedStatements)
            {
                Visit(statement);
            }

            foreach (Scope<string,Declaration> startChildScope in scope.ChildScopes)
            {
                TraverseScope(startChildScope);
            }
        }


        public void Deallocate(Declaration node)
        {
            switch (node.Type)
            {
                case Type.Number:
                    NumberVarMap.Remove(node.Name);
                    AvailableVariables +=1;
                    break;
                case Type.Point:
                    PointVarMap.Remove(node.Name);
                    AvailableVariables += 2;
                    break;
            }
        }

        public void Allocate(Declaration node)
        {
            switch (node.Type)
            {
                case Type.Number:
                    NumberVarMap.Add(node.Name, NextAvailableVariableName());
                    AvailableVariables -=1;
                    break;
                case Type.Point:
                    PointVarMap.Add(node.Name, NextTwoAvailableVariables());
                    AvailableVariables -= 2;
                    break;
            }
        }

        private int NextAvailableVariableName()
        {
            if (AvailableVariables - 1 >= 0)
                return AvailableVariables;
            else 
                throw new NotSupportedException($"Cannot create program using only {_maxVariables} variables.");
        }

        private Pair<int, int>NextTwoAvailableVariables()
        {
            if (AvailableVariables - 2 >= 0)
                return new Pair<int, int>(AvailableVariables, AvailableVariables-1);
            else 
                throw new NotSupportedException($"Cannot create program using only {_maxVariables} variables.");
        }


        public string Visit(Loop node)
        {
            Builder.Append("WHILE [" + Visit((dynamic)node.Condition) + "]\n");
            Builder.Append(Visit((dynamic) node.Body));
            
            return Builder.ToString();
        }

        public string Visit(Line node)
        {
            return node;
        }

        public string Visit(Curve node)
        {
            return node;
        }

        public string Visit(Assign node)
        {
            Pair<int, int> pRes;
            int nRes;
            if (NumberVarMap.TryGetValue(node.Id, out nRes))
            {
                Builder.Append($"#{nRes} = {Visit(node.Value)}\n");
            }
            else if (PointVarMap.TryGetValue(node.Id, out pRes))
            {
                //TODO Create two variable assignments for node.
            }
            else throw new ArgumentException("Node err");

            
            
            
            return Builder.ToString();
        }

        public string Visit(NameReference node)
        {
            Pair<int, int> pRes;
            int nRes;
            if (NumberVarMap.TryGetValue(node.Name, out nRes))
            {
                return nRes.ToString();
            }
            else if (PointVarMap.TryGetValue(node.Name, out pRes))
            {
                //TODO Create To References
            }
            else throw new ArgumentException("Node err");

            return Builder.ToString();
        }

        public string Visit(Declaration node)
        {
            Allocate(node);
            return node;
        }

        public string Visit(If node)
        {
            foreach (Ast ast in node.Body)
            {
                Visit((dynamic) ast);

            }

            return node;
        }

        public string Visit(IfElse node)
        {
            foreach (Ast ast in node.Body)
            {
                Visit((dynamic) ast);

            }

            foreach (Ast ast in node.ElseBody)
            {
                Visit((dynamic) ast);
            }

            return node;
        }

        public string Visit(Statement statement)
        {
            Visit((dynamic) statement);

            foreach (DeclarationInformation info in ScopeDeclarationInformation)
            {
                if (Equals(info.LatestStatement, statement))
                    Deallocate(info.Dcl);
            }

            return statement.;
        }

        public string Visit(Program node)
        {


            foreach (Statement nodeProgramStatement in node.ProgramStatements)
            {
                Visit(nodeProgramStatement);
            }
        }

        public string Visit(GreaterThan node)
        {
            throw new NotImplementedException();
        }

        public string Visit(LessThan node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Equals node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Plus node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Minus node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Multiplication node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Divide node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Power node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Number node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Point node)
        {
            throw new NotImplementedException();
        }

        public string Visit(Expression node)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAllocator
    {
        public void Deallocate(Declaration node);
        public void Allocate(Declaration node);
    }
}