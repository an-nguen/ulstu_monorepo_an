x=linspace(0,1,100)';
pi=pimf(x,[0.1 0.5 0.7 1.0]);
z=zmf(x,[0.2 0.4]);
s=smf(x,[0.6 0.8]);
scf();clf();
plot2d(x,[pi z s],leg="pi@z@s");
xtitle("Shaped Member Functions Examples","x","mu(x)");
