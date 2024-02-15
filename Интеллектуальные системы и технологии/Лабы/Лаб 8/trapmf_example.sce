x=linspace(0,1,100)';
y1=trapmf(x,[0 0.2 0.4 0.6]);
y2=trapmf(x,[0.2 0.5 0.6 0.9]);
y3=trapmf(x,[0.5 0.6 0.8 0.9 ]);
scf();clf(); 
plot2d(x,[y1 y2 y3],leg="y1@y2@y3");
xtitle("График трапециевидной ФП","x","mu(x)");
