grammar RGCode;
program: statement+ EOF;
statement: (assignment | vardec | move  | repeat |if|ifElse) ';';
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
                ;

atom            : value=Number                     #value
               | value=ID                     #idMath
               | '('math')'                     #compund;

bool: lhs=math operator=BoolOperator rhs=math;

point: '(' lhs=math ',' rhs=math')'   #pointExpression
     | value=ID #idPoint;


move: (line | curve );

line: 'line from' from=point toCommands+ ;
curve: 'curve from' from=point toCommands+ 'with angle' angle=math;
toCommands: ('to ' p=point) #to;

repeat: 'repeat' 'until' cond=bool ScopeStart statement* ScopeEnd 'loop';

 


if: 'iff' cond=bool ScopeStart statement* ScopeEnd 'if';

ifElse: if 'else'  ScopeStart statement* ScopeEnd 'else';

 
 
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
