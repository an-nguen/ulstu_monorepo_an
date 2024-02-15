x=[0:0.1:10]';
y1=gaussmf(x,[3 1.2]);
y2=complement(y1,"one");
scf();clf();
plot2d(x,[y1 y2],leg='mf1@Not_mf1',rect=[0 -0.1 10 1.1]);
xtitle('Операция дополнения','x','mu(x)');
