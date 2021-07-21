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
        private Dictionary<string, PointStringPair> PointVarMap { get;  }
        private Dictionary<string, int> NumberVarMap { get;  }

        private StringBuilder Builder = new StringBuilder();
        private IEnumerable<DeclarationInformation> ScopeDeclarationInformation { get; set; }


        public VariableAllocator(Stack<Scope<string, Declaration>> stack, int availableVariables):base(stack)
        {
            _maxVariables = availableVariables;
            AvailableVariables = _maxVariables;
            InformationMapper = new InformationMapper(stack);
            PointVarMap = new Dictionary<string, PointStringPair>();
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

        private PointStringPair NextTwoAvailableVariables()
        {
            if (AvailableVariables - 2 >= 0)
                return new PointStringPair(AvailableVariables, AvailableVariables-1);
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
            if (NumberVarMap.TryGetValue(node.Id, out int nRes))
            {
                return $"#{nRes} = {Visit(node.Value)}\n";
            }
            else if (PointVarMap.TryGetValue(node.Id, out PointStringPair pair))
            {
                switch (node.Value)
                {
                    case Point p:
                        return 
                            $"#{pair.XVariable} = {Visit((dynamic) p.XValue)} \n #{pair.YVariable} = {Visit((dynamic) p.YValue)}\n";

                    case NameReference n:
                        return $"#{pair.XVariable} = {PointVarMap[n.Name].XVariable} \n #{pair.YVariable} = {PointVarMap[n.Name].YVariable}";
                }
            }
            
            return Builder.ToString();
        }

        public string Visit(NameReference node)
        {
            if (NumberVarMap.TryGetValue(node.Name, out int nRes))
            {
                return nRes.ToString();
            }
            else if (PointVarMap.TryGetValue(node.Name, out PointStringPair pRes))
            {
                return pRes.XVariable.ToString() + ',' + pRes.YVariable.ToString();
            }
            throw new ArgumentException("Node err");

        }

        public string Visit(Declaration node)
        {
            Allocate(node);

            if (NumberVarMap.TryGetValue(node.Name, out int nRes))
            {
                return $"#{nRes} = {Visit(node.Value)}\n";
            }
            else if (PointVarMap.TryGetValue(node.Name, out PointStringPair pair))
            {
                switch (node.Value)
                {
                    case Point p:
                        return 
                            $"#{pair.XVariable} = {Visit((dynamic) p.XValue)} \n #{pair.YVariable} = {Visit((dynamic) p.YValue)}\n";

                    case NameReference n:
                        return $"#{pair.XVariable} = {PointVarMap[n.Name].XVariable} \n #{pair.YVariable} = {PointVarMap[n.Name].YVariable}";
                }
            } 
            throw new ArgumentException("Node err");

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
            string result = Visit((dynamic) statement);

            foreach (DeclarationInformation info in ScopeDeclarationInformation)
            {
                if (Equals(info.LatestStatement, statement))
                    Deallocate(info.Dcl);
            }

            return result;
        }

        public string Visit(Program node)
        {
            var result = "";
            foreach (Statement nodeProgramStatement in node.ProgramStatements)
            {
                result+= Visit(nodeProgramStatement);
            }

            return result;
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

        internal class PointStringPair
        {
            public int XVariable{get;}
            public int YVariable { get; }

            public PointStringPair(Pair<int,int> pair)
            {
                XVariable = pair.a;
                YVariable = pair.b;
            }

            public PointStringPair(int x, int y)
            {
                XVariable = x;
                YVariable = y;
            }
        }
    }

    public interface IAllocator
    {
        public void Deallocate(Declaration node);
        public void Allocate(Declaration node);
    }
}