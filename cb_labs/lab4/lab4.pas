{$asmmode intel}
var i : byte;
    s, s2, s3 : string;
    c : char;

Label L1,L2;
begin
  i := 3;
  s := 'F';
  c := 'A';
  s2 := 'BBB';
  s3 := 'CCC';
  asm
    lea esi, s2
    lea edi, s    // edi = s[0]
    xor cx, cx    // clean CX

    mov cl, i     // mov counter to CL
    mov al, c     // symbol for filling string

    mov [esi], cl
    mov [edi], cl // fill s[0] - symbols count in string
    inc esi
    inc edi       // begin fill string from s[1]
    // flag D = 0. Increment in handle string
    cld
    // STOSB Write string from bytes(words)
    // (EDI) = AL (AX)
    // REP - repeat while cx != 0 and cx -= 1
    // REPE - REP and while Z=1
    // REPNE (REPNZ) - REP and while Z=0
    rep stosb
    nop
    // MOVSB - (EDI) = (ESI)
    sub edi, 3
    mov cl, i
    cld
    rep movsb
    nop
    // CMPSB - compare (EDI) and (ESI) -> flags O S Z A P C
    mov cl, 3
    lea esi, s3
    mov [esi], cl
    inc esi
    sub edi, 3
    cld
    cmpsb
    nop
    // SCASB - compare AL and (EDI) -> flags of CMPSB
    sub edi, 1
    sub esi, 1
    mov cl, 3
    cld
    rep scasb
    nop
    dec edi
    // LODSB - AL = (ESI) or AX = (ESI)
    cld
    lodsb
    nop
    // LOOP - use CX counter
    xor cx, cx
    xor dx, dx
    mov dx, 00000001b
    mov cx, 2
L1: push cx     // save CX to stack
    mov cx, 3
L2: sal dx, 2
    loop L2
    pop cx
    loop L1
    nop
  end;
  writeln(s);
  readln();
end.
