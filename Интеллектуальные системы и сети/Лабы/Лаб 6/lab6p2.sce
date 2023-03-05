a = 0;
b = 9;
c = -8;
d = -70;

function y1=f1(x);
    y1 = a * x^3 + b * x^2 + c * x + d;
endfunction

function y2=f2(x);
    y2 = 100 * abs(sin(x));
endfunction

function y3=f3(x);
    y3 = f1(x) - f2(x);
endfunction

x=-3.9:0.001:4.9;
plot(x,f3(x)); xgrid;

x0 = -3.85;
x1 = fsolve(x0, f3);
x0 = 4.75;
x2 = fsolve(x0, f3);
result = 'x1 = ' + string(x1) + ' x2 = ' + string(x2);
title(result)
