var s, res : string;
    i, len, rem : byte;

begin
  i := 5;
  s := 'My string';
  res := '';
  len := length(s) - 1;
  rem := len - i;
  asm
    lea esi, s
    lea edi, res

    xor eax, eax
    xor ecx, ecx

    mov al, len
    mov cl, i

    inc esi

    mov [edi], al
    inc edi

    cld
    rep movsb
    inc esi

    cld
    mov cl, rem
    rep movsb
    nop
  end;
  writeln(res);
  readln();
end.