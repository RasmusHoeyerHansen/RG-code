using RG_code.AST;

namespace RG_code.AstVisitors
{
    internal class TypeError
    {
        public enum ErrorType
        {
            NotDeclared,
            DoubleDeclared,
            IncorrectUsage
        }

        public ErrorType TypeOfError { get; set; }
        private string NodeInformation { get; set; }

        public TypeError(Ast node, ErrorType typeOfError)
        {
            TypeOfError = typeOfError;
            NodeInformation = node.ToString();
        }

        public override string ToString()
        {
            string errorMessage = string.Empty;
            switch (TypeOfError)
            {
                case ErrorType.NotDeclared:
                    return "Variable is used, but not declared: " + NodeInformation;
                    
                case ErrorType.DoubleDeclared:
                    return "Variable is declared more than once: " + NodeInformation;
                case ErrorType.IncorrectUsage:
                    return "Variable is used in wrong context: " + NodeInformation;
                default: return "OTHER ERROR";
            }
        }
    }
}