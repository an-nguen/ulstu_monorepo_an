a = 0;
b = 1;
c = 4;
d = 1;

function y1=f1(x);
    y1 = a * x^3 + b * x^2 + c * x + d;
endfunction

x=-5:0.01:3;
plot(x,f1(x)); xgrid;

x0 = -3.8;
x1 = fsolve(x0, f1);
x0 = -0.2;
x2 = fsolve(x0, f1);
result = 'x1 = ' + string(x1) + ' x2 = ' + string(x2);
gce().children(1).foreground = color(0, 120, 0);
disp(result);

