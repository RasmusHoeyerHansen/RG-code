using RG_code.AST;

namespace RG_code.AstVisitors
{
    public class DeclarationInformation
    {
        public DeclarationInformation(Scope<string, Declaration> latestUsageScope, Declaration dcl)
        {
            LatestUsageScope = latestUsageScope;
            Dcl = dcl;
        }
        public DeclarationInformation(Scope<string, Declaration> latestUsageScope, Declaration dcl, int firstUsageNumber, Statement firstUsageStatement) 
            : this(latestUsageScope,dcl)
        {
            FirstUsageStatement = firstUsageStatement;
            FirstUsageStatementNumber = firstUsageNumber;
        }

        
        public Statement FirstUsageStatement { get; }

        public int FirstUsageStatementNumber { get; }
        public  int LatestUsageNumber { get; set; }
        public Statement LastStatement { get; set; }
        public Declaration Dcl { get; }

        public Scope<string, Declaration> LatestUsageScope { get;  set; }

    }
}