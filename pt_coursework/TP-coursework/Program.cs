using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_coursework
{
    static class Program
    {
        public static MainForm form0;
        public static FormQuiz form1;
        public static ResForm form2;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form0 = new MainForm();
            form1 = new FormQuiz();
            form2 = new ResForm();
            Application.Run(form0);
        }
    }
}
