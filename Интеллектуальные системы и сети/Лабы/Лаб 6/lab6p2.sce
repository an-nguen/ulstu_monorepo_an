a = 0;
b = 1;
c = 4;
d = 1;

function y1=f1(x);
    y1 = a * x^3 + b * x^2 + c * x + d;
endfunction

function y2=f2(x);
    y2 = 10 * log(x + 5.5);
endfunction

function y3=f3(x);
    y3 = f1(x) - f2(x);
endfunction

x=-5:0.001:3;
plot(x,f3(x)); xgrid;

x0 = -4.27;
x1 = fsolve(x0, f3);
x0 = 3;
x2 = fsolve(x0, f3);
result = 'x1 = ' + string(x1) + ' x2 = ' + string(x2);
title(result)
