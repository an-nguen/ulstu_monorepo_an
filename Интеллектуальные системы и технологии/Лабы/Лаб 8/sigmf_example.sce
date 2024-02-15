x=linspace(0,1,100)';
sig1=sigmf(x,[12 0.3]);
sig2=sigmf(x,[-12 0.7]);
psig=psigmf(x,[15 0.5 -15 0.7]);
dsig=dsigmf(x,[15 0.1 15 0.3]);
scf();clf();
plot2d(x,[sig1 sig2 psig dsig],leg="sig1@sig2@psig@dsig");
xtitle("График сигмодной ФП", "x", "mu(x)");
