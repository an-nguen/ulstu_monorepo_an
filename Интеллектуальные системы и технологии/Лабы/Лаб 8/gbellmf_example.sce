x=linspace(0,1,100)';
y1=gbellmf(x,[0.5 10 0.5]);
y2=gbellmf(x,[0.2 10 0.2]);
y3=gbellmf(x,[0.7 10 0.8]);
scf();clf();
plot2d(x,[y1 y2 y3],leg="y1@y2@y3");
xtitle("Generalized Bell Member Function Example","x","mu(x)");
