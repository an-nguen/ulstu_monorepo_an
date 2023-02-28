var variable, i, x, y : integer;
    reg_ah : byte;
    c, tmp, xlat_data : char;
    arr0 : array [0..10] of char;
    p : ^integer;

// на 80386 компиляторе
// integer - 2 байта = 16 бит
// char - 1 байт = 8 битов
begin
  x := 3; y := 7;
  variable := 13;
  c := 'A';
  for i := 0 to 10 do begin
    arr0[i] := c;
    inc(c);
  end;

  asm
    mov bx, 9           // ист. - непосред., приемник - регистровая
    mov dx, variable    // ист. - прямой, приемник - регистровая
    lea ebp, arr0       // косвенно-регистровая адресация
    mov ch, [ebp + 5]   // ..со смещением
    mov edi, 1
    mov dh, [ebp + edi + 3] // по базе со смещением
    // нужно для вывода данных
    mov c, dh
    mov tmp, ch
    // обмен значениями через стэк
    push x
    push y
    pop x
    pop y
    // получение значения из массива через xlat (al = (bx+al))
    mov al, 9
    lea ebx, arr0
    xlat
    mov xlat_data, al // al -> xlat_data = arr0[9]
    // xchg - обмен значениями в регистрах
    mov ax, 4
    xchg ax, dx
    mov variable, dx
    // пересылка данных (флаги)
    pushf
    add ax, 32767
    lahf
    mov reg_ah, ah
    sahf
    popf

  end;

  writeln('x = ', x, '; y = ', y, '; c = ', c);
  writeln('xlat_data = ', xlat_data);
  writeln('tmp = ', tmp);
  writeln('reg_ah = ', reg_ah);
  writeln('variable = ', variable);
  readln();
end.
