using System;
using System.Reflection;
using System.Text;
using Antlr4.Runtime;

namespace RG_testing.HelperClasses
{
    public class ContextCreator : ParserCreator
    {
        protected ParserRuleContext CreateContext<Context>(string codeExpression)
            where Context : ParserRuleContext
        {
            Type contextType = typeof(Context);

            string methodName = GetMethodName(contextType);
            MethodInfo? method = typeof(RGCodeParser).GetMethod(methodName);

            //Corresponds to for instance RGCodeParser.ProgramContext cst = parser.ifElse();
            RGCodeParser parser = CreateParser(codeExpression);
            return (Context) method.Invoke(parser, new object?[] { });
        }

        protected ParserRuleContext CreateContext<Context>(string fileName, string dirName)
            where Context : ParserRuleContext
        {
            Type contextType = typeof(Context);
            string methodName = GetMethodName(contextType);

            MethodInfo? method = typeof(RGCodeParser).GetMethod(methodName);

            RGCodeParser parser = CreateParser(fileName, dirName);
            return (Context) method.Invoke(parser, new object?[] { });
        }

        private string GetMethodName(Type contextType)
        {
            //Get the method corresponding to the context name.
            //For instance, ifElse() is a method for the IfElseContext class.
            string methodName = string.Empty;
            if (contextType.Name != null)
            {
                methodName = contextType.Name.Replace("Context", "");
                StringBuilder strB = new(methodName);
                char q = char.ToLower(strB[0]);
                strB[0] = q;
                methodName = strB.ToString();
            }

            return methodName;
        }
    }
}