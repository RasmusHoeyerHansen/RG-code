
number b = 2;

repeat until b > 3 begin
 
 iff b > 3 then begin
 b = (2,b);
 end
  else do
   begin
    b = (a,b);
   end else;
 end loop;