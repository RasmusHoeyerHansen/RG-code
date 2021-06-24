using System;
using RG_code.AST;
using RG_code.AstVisitors.Visitor_Interfaces;

namespace RG_code
{
    public class PrettyPrinter : IFullVisitor<Ast>
    {
        public Ast Visit(Plus node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Minus node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Multiplication node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Divide node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Power node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Number node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Assign node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Declaration node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Program node)
        {
            Console.WriteLine("PRETTY PRINT");

            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic)nodeChild);
            }

            return node;
        }

        public Ast Visit(GreaterThan node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(LessThan node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Equals node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(NameReference node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Point node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Line node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Curve node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Loop node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(If node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(IfElse node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }

        public Ast Visit(Expression node)
        {
            Console.WriteLine(node.ToString());
            foreach (IAst nodeChild in node.Children)
            {
                Visit((dynamic) nodeChild);
            }
            return node;
        }
    }
}