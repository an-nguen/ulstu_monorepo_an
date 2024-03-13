function f=deb_1(x)
  f1_x1 = x(1);
  g_x2 = 1 + 9 * sum((x(2:$)-x(1)).^2) / (length(x) - 1);
  h = 1 - sqrt(f1_x1 / g_x2);
  f(1,1) = f1_x1;
  f(1,2) = g_x2 * h;
endfunction

// Параметры для функции ГА
pop_size = 100;
Log = %T;
// По варианту
p_cross = 0.5;
p_mut = 0.25;
n_gen = 6;
press = 0.1;
// Параметры для создания начальной популяции
ga_params = init_param();
ga_params = add_param(ga_params, 'dimension', 2);
ga_params = add_param(ga_params, 'minbound', zeros(2,1));
ga_params = add_param(ga_params, 'maxbound', ones(2,1));
ga_params = add_param(ga_params, 'pressure', press);

[pop_opt, fobj_pop_opt, pop_init, fobj_pop_init] = optim_moga(deb_1, pop_size, n_gen, p_mut, p_cross, Log, ga_params);

// График начальной популяции
scf(1); clf(1);
xtitle("График начальной популяции");
plot(fobj_pop_init(:, 1), fobj_pop_init(:, 2), '.');

// График популяции оптимальных индивидуумов
scf(2); clf(2);
xtitle("График популяции оптимальных индивидуумов");
plot(fobj_pop_opt(:, 1), fobj_pop_opt(:, 2), 'g+');

// Совместный график начальной и оптимальной популяций
scf(3); clf(3);
xtitle("Совместный график начальной и оптимальной популяций");
scatter(fobj_pop_init(:, 1), fobj_pop_init(:, 2), 4, '.');
scatter(fobj_pop_opt(:, 1), fobj_pop_opt(:, 2), 64, 'scilabgreen4', '+');
