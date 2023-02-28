var arr0, arr1: array [1..10] of char;
    c : char;
    i : integer;

begin
  c := 'A';
  for i:=0 to 10 do begin
    arr0[i] := c;
    inc(c);
  end;

  c := 'J';
  for i:=0 to 10 do begin
    arr1[i] := c;
    inc(c);
  end;

  asm
    lea ebx, arr0
    mov bl, [arr0 + 4]

    lea ebp, arr1 + 2
    mov dl, [arr1 + 2]
    mov [ebp], bl
  end;

  writeln(c)
  readln();
end.