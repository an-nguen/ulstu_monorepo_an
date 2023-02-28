{$asmmode intel}

Label l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l23, l24, l25, j1;
begin
  asm
    // None of the commands of conditional transition J* change flags.
    // commands J* - param: LABEL_TYPE
    // JA - jump if above - CF = 0 and ZF = 0, JNBE = JA (if not below or equal)
    xor edx, edx
    mov dx, 29 // dx = 29
    // if (dx > 30) goto l1
    cmp dx, 30
    ja l1
    // else
    mov dx, 32 // dx = 32
l1: nop
    // if (!(dx < 31)) goto l2
    cmp dx, 31
    jnbe l2
    // else
    mov dx, 32 // dx = 32
l2: nop
    // JAE - jump if above or equal - CF = 0
l3: dec dx
    // if (dx >= 31) goto l3
    cmp dx, 31
    jae l3
    // else
    nop
    // JNB - jump if not below - CF = 0
    // if (!(dx <= 29)) goto l3
    cmp dx, 29
    jnb l3
    nop
    xor dx, dx
    mov dl, 11111111b
    // JNC - jump if not carry
l4: add dl, 1
    jnc l5 // goto l5 - CF = 0
    // JC - jump if carry
    jc l4 // goto l4 - CF = 1
    inc dl
l5: nop
    // JB - jump if below - CF = 1.
    // if (dl < 0xFF) goto l6
    cmp dl, 0FFh
    jb l6
    inc dl
l6: nop
    // JNAE - jump if not above and equal - CF = 1
    cmp dl, 0FFh
    jb l7
    inc dl
l7: nop
    // JBE - jump if below and equal - CF = 1 or ZF = 1
    // JNA - jump if not above
    mov dl, 013h
    cmp dl, 013h
    jbe l8
    dec dl
l8: nop
    cmp dl, 014h
    jna l9
    dec dl
l9: nop
    // JCXZ - jump if cx = 0, doesn't work CF = 1 or ZF = 1
    xor cx, cx
    // jcxz l10
    inc cx
//l10: nop
    // JE - jump if equal (Z = 1)
    cmp dl, dl
    je l10
    inc dl
l10: nop
    // JZ - jump if zero (Z = 1)
    xor dl, dl
    cmp dl, dl
    jz l11
    inc dl
l11: nop
    // JG - jump if more than - (Z = 0) and (S = 0) (signed)
    mov dl, 079h
l12: inc dl
    cmp dl, 081h
    jg l12
    nop
    // JNLE - jump if not less AND not equal - (Z = 0) and (S = 0) (signed)
l13: inc dl
    cmp dl, 10h
    jnle l13
    inc dl
    nop
    // JGE - jump if value more than OR equal cmp_value (S = 0) (signed)
    mov dl, 011h
l14: dec dl
    cmp dl, 010h
    jge l14
    inc dl
    nop
    // JNL - jump if val not less than cmp_val (S = 0) (signed)
    mov dl, 012h
l15: dec dl
    cmp dl, 010h
    jnl l15
    nop
    // JL - jump if value less than cmp_value (S != 0) (signed)
    mov dl, 0h
    sub dl, 1
    jl l16
    nop
    // JNGE - jump if value no more than cmp_val AND no equal cmp_val (S != 0) (signed)
l16: inc dl
    cmp dl, 04h
    jnge l16
    nop
    nop
    // JLE - jump if less OR equal (S != 0) or (Z = 1) (signed)
    cmp dl, 05h
    jle l16
    nop
    // JNG - jump if not more (S != 0) or (Z = 1) (signed)
    cmp dl, 09h
    jng l16
    nop
    // JNE - jump if not equal (Z = 0)
j1: cmp dl, 0FFh
    jne l17
    nop
l17: mov dl, 0FFh
    // JNZ - jump if not zero (not equal) (Z = 0)
    cmp dl, 0h
    jnz l18
    nop
l18: nop
    // JNO - jump if not overflow (O = 0)
    mov dl, 07Eh     // in signed 7Eh = 126
l19: add dl, 1       // after reach 80h -> Overflow
    jno l19
    nop
    // JNP - jump if not parity (P = 0)
    mov dl, 00001111b // 4 - nums 1 -> parity
l20: inc dl           // 1. 1 - nums 1 -> not parity; 2. 2 - nums 1 -> parity
    jnp l20
    nop
    // JNS - jump if positive sign (S = 0)
l21: add dl, 10h
    jns l21
    nop
    // JO - jump if overflow (O = 1)
    mov dl, 70h
l22: add dl, 12h
    jo l22
    nop
    // JP - jump if parity (P = 1)
    mov dl, 00001011b // 2 - nums 1 -> not parity
l23: inc dl // 1. parity, 2. not parity
    jp l23
    nop
    // JS - jump if negative sign (S = 1)
    mov dl, 082h
l24: dec dl
    js l24
    nop
  end;
end.
