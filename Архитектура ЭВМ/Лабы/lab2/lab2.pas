var i : integer;


// AF - дпп. флаг переноса
// PF - флаг чётности (чётное число едениц)
// OF - флаг переполнения
// SF - старший бит (показатель знака числа) S=1 - отриц. S=0 - полож.

begin
  asm
   //  cmc           // invert CF 1->0 or 0-> 1
    // Сложение
    mov dl, 11111111b // 127 -> dl
    add dl, 00000001b // dl = dl + src
    adc dl, 00000000b // dl = dl + src + CF
    nop
    // Вычитание
    mov dl, 00000111b
    sub dl, 00000011b
    nop
    // Вычитание с заёмом
    cmc
    sbb dl, 00000000b // dl = dl - 00000000b - CF
    nop
    // Сравнение
    mov cl, dl    // mov 10000b -> bx
    cmp dl, cl    // сравниваем dl и cl
    nop
    // Инкремент и декремент
    mov dl, 11111111b
    inc dl
    dec dl
    nop
    // Получение доп. кода
    mov dl, 00000011b
    neg dl  // 00000011b -> 11111101b
    nop
    // Умножение
    mov al, 127   // ax = al * src
    mov dl, 8     // mul src
    mul dl
    nop
    // Деление
    mov al, 15    // al = ax / src , ah - остаток
    cbw // al BYTE превращает в ax WORD замещая ah
    div dl
    nop
    // Умножение с учётом знака и переноса
    mov al, 18
    imul dl
    nop
    // Деление с учётом знака
    mov ax, 33
    idiv dl
    nop
    // ax WORD (16bit) превращает ax:dx DWORD (32bit)
    mov ax, 33    // ax <- 00000021h
    mov dx, 16    // dx <- 00000010h
    cwd           // ax:dx <- 0000000000000021h
    nop
  end;
end.
