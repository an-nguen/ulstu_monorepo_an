{$asmmode intel}
var x : integer;

begin
  x := 5;
  asm
    xor eax, eax
    xor ebx, ebx
    xor edx, edx
    // x = x * 0111b (7d) = x * (8 - 1) = x * 8 - x = x * 1000b - x
    mov dx, x

    sal dx, 3
    sub dx, x

    nop
  end;
end.