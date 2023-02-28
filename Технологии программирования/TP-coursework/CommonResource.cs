using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_coursework
{
    static class CommonResource
    {
        // Это поле нужна для дальнейшего сохранения в файл
        public static string studentInfoToSave { get; set; }
        public static string quizInfoToSave { get; set; }

        public static string pathfile = "data.txt";

        public static void saveToFile()
        {
            var file = File.Exists(pathfile) ? File.Open(pathfile, FileMode.Append) : File.Open(pathfile, FileMode.CreateNew);
            file.Close();
            StreamWriter writer = File.AppendText(pathfile);
            writer.WriteLine(studentInfoToSave + quizInfoToSave);
            writer.Close();
        }
    }
}
