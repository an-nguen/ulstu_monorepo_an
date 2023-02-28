using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_coursework.utils;

namespace TP_coursework
{
    public partial class FormQuiz : Form
    {
        public FormQuiz()
        {
            InitializeComponent();
        }

        private void FormQuiz_Load(object sender, EventArgs e)
        {

        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            appendQuizInfo();
            DataLayer.saveToFile();
            MessageBox.Show("Спасибо за уделённое вами время на опрос!");
            this.Hide();
            Program.form2.FormClosed += (s, args) => this.Close();
            Program.form2.Show();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.form0.Show();
        }

        private List<RadioButton> collectInfo(IEnumerable<GroupBox> containers)
        {
            if (containers == null) return null;

            List<RadioButton> rBtns = new List<RadioButton>();
            foreach (var item in containers) {
                rBtns.Add(item.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked));
            }
            return rBtns;
        }

        private void appendQuizInfo()
        {
            DataLayer.quizInfoToSave = "";
            foreach(var item in collectInfo(this.Controls.OfType<GroupBox>().Reverse()))
                DataLayer.quizInfoToSave += item.Text + ';';
        }
    }
}
