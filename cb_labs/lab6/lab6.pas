{$asmmode intel}
var x, y, z, res1: integer;

procedure my_procedure(a: integer; var b, c, sum: integer);
begin
  sum := a + b + c
end;

function factorial(value: integer) : integer;
begin
  if value > 0 then
    factorial := value * factorial(value - 1)
  else
    factorial := 1;
end;

begin
  x := 13;
  y := 16;
  z := 20;
  my_procedure(x, y, z, res1);
  //res2 := factorial(5);
  writeln('res1 = ', res1);
  //writeln('res2 = ', res2);
  readln();
end.
