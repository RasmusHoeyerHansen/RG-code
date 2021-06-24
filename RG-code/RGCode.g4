grammar RGCode;
program: statement+ EOF;
statement: (assignment | vardec | move  | repeat |if |ifElse) ';';
vardec: typeWord=Typeword assignment ;
assignment: ID '=' expr ;



expr: (math |point| ID |bool );
math            : lhs=term op=('+'|'-') rhs=math #plusminus
                | term                     #singleTerm
                ;
                
term            : lhs=factor op=('*'|'/') rhs=term #multiplication     
                | child=factor                     #singleFactor
                ;      
factor          : atom pow='^' factor              #power
                | atom                             #singeAtom
                |'(' mathExpr=math ')'             #parentheseis
                ;

atom            : value=Number                     #value
               | value=ID                     #idMath;

bool: lhs=math operator=BoolOperator rhs=math #boolExpression;
point: '(' lhs=math ',' rhs=math')'   #pointExpression
     | value=ID #idPoint;


move: (line | curve );

line: 'line from' from=point toCommands+  #lineCommand;
curve: 'curve from' from=point toCommands+ 'with angle' angle=math #curveCommand;
toCommands: ('to ' p=point) #to;

repeat: 'repeat' 'until' cond=bool ScopeStart statement* ScopeEnd;

 


if: 'iff' cond=bool 'then' ScopeStart statement* ScopeEnd;

ifElse: if 'else do' ScopeStart statement* ScopeEnd;

 
 
BoolOperator     :  '>'  | '<' | '==';
Typeword: 'number' | 'int' | 'point'; 
//Tokens and help variables:
BooleanValue    : 'true'| 'false';
ScopeStart: 'begin';
ScopeEnd: 'end';

Mul_Div  : '*' | '/';
Plus_Minus: '+' | '-';
WS     : [ \t\r\n]+ -> skip ; // skip spaces, tabs, newlines
Number: ([0-9]+ | '-'[0-9]+)|([0-9]+'.'[0-9]+ | '-'[0-9]+ | '-'[0-9]+'.'[0-9]+);
ID: [a-zA-Z]+[0-9a-zA-Z]*;
COMMENT: '/*' .*? '*/' -> skip;
