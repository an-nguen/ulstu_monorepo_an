{$asmmode intel}
var i : longint;

begin
  i := $FC003;
  asm
    mov bx, [i]
    mov ax, [i+2]
    shld ax, bx, 2
    shl bx, 2
    mov [i], bx
    mov [i+2], ax
    mov ecx, i
    nop
    mov edx, $FC003
    shl edx, 2
    nop
  end;
  writeln(i);
  readln();
end.
