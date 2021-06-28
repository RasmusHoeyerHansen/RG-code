using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class TypeError
    {
        public enum ErrorType
        {
            NotDeclared,
            DoubleDeclared,
            IncorrectUsage,
            ExpressionInconsistency,
            BadDeclaration
        }

        public TypeError(Ast node, ErrorType typeOfError)
        {
            Node = node;
            TypeOfError = typeOfError;
            NodeInformation = node.ToString();
        }

        public TypeError(Ast node, ErrorType typeOfError, Type t1, Type t2) : this(node, typeOfError, t1)
        {
            SecondType = t2;
        }

        /*public TypeError(Ast node, ErrorType typeOfError, Type t1, Type t2, Type expected) : this(node, typeOfError, t1,
            t2)
        {
            Expected = expected;
        }*/

        public TypeError(Ast node, ErrorType typeOfError, Type t1) : this(node, typeOfError)
        {
            FirstType = t1;
        }


        public TypeError(Ast node, ErrorType typeOfError, string optionalText) : this(node, typeOfError)
        {
            OptionalText += optionalText;
        }

        public ErrorType TypeOfError { get;}

        private string _nodeInfo = " ";

        private string NodeInformation
        {
            get => _nodeInfo;
            set => _nodeInfo = value;
        }

        private Type FirstType { get;}

        private Type SecondType { get; }
        private Type Expected { get; }

        private string OptionalText { get; } = ", ";
        private Ast Node { get; }

        public override string ToString()
        {
            switch (TypeOfError)
            {
                case ErrorType.NotDeclared:
                    return "Variable is used, but not declared: " + NodeInformation + OptionalText;

                case ErrorType.DoubleDeclared:
                    return "Variable is declared more than once: " + NodeInformation + OptionalText;
                case ErrorType.IncorrectUsage:
                    return "Expression is used in wrong context: " + NodeInformation + OptionalText;
                case ErrorType.ExpressionInconsistency:
                    return $"An expression was inconsistent.  Got type {FirstType} and {SecondType} in " +
                           NodeInformation + OptionalText;
                case ErrorType.BadDeclaration:
                    return
                        $"BadDeclaration: Expected {FirstType}, but got {SecondType} as expression, {NodeInformation}";

                default: return "OTHER ERROR";
            }
        }
    }
}