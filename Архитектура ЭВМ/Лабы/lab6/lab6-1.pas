
var m0, m1, m2, m3: integer;

procedure proc(x: integer; var y, z, h: integer);
begin
  writeln(x);
  writeln(y);
  writeln(z);
  writeln(h);
end;

begin
  asm
    xor %eax, %eax
    xor %ecx, %ecx
    xor %edx, %edx

    movw $0x5, m0
    movw $0xC, m1
    movw $0x14, m2
    movw $0x2A, m3

    push $m3
    mov $m2, %ecx
    mov $m1, %edx
    mov m0, %ax

    call proc

    // ret:
    // pop ip
    // pop cs
    // sp = sp + number

  end;
  readln();
end.
