x=linspace(0,1,100)';
disp(type(x));
y1=gaussmf(x,[0.3 0.1]);
y2=gauss2mf(x,[0.2 0.1 0.5 0.2]);
scf();clf(); 
plot2d(x,[y1 y2],leg="y1@y2");
xtitle("График ФП Гаусса","x","mu(x)");
