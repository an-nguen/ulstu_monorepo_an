//задаем множество х
x=linspace(0,1,100)';
// Треугольные функции принадлежности f(x, a, b, c)
y1=trimf(x,[0 0.2 0.4]); 
y2=trimf(x,[0.2 0.5 0.9]);
y3=trimf(x,[0.5 0.6 0.9]);
scf();clf()
// График функции принадлежности
plot2d(x,[y1 y2 y3],leg="y1@y2@y3");
// Название графика
xtitle("Triangular Member Function Example","x","mu(x)");
