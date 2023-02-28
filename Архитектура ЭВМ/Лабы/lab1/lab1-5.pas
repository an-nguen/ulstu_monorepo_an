var x, y : integer;

begin
  x := 0; y := 0;
  asm
    cmc
    pushf
    pop dx
    mov x, dx
    cmc
    pushf
    pop cx
    mov y, cx
  end;
  writeln(x);
  writeln(y);
  readln();
end.