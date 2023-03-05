a = 0;
b = 9;
c = -8;
d = -70;

function y1=f1(x);
    y1 = a * x^3 + b * x^2 + c * x + d;
endfunction

x=-3.5:0.01:3.5;
plot(x,f1(x)); xgrid;

x0 = -3.4;
x1 = fsolve(x0, f1);
x0 = 2.3;
x2 = fsolve(x0, f1);
result = 'x1 = ' + string(x1) + ' x2 = ' + string(x2);
gce().children(1).foreground = color(0, 120, 0);
disp(result);

