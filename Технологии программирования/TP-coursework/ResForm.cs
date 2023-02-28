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
    public partial class ResForm : Form
    {
        public ResForm()
        {
            InitializeComponent();
        }

        private void ResForm_Load(object sender, EventArgs e)
        {
            List<float> res = new List<float>()
            {
                0, 0, 0, 0, 0, 0, 0, 0
            };
            string data = DataLayer.studentInfoToSave.Split(';')[5];

            var list = DataLayer.loadFromFileQuiz(data);
            foreach(var item in list)
            {
                for (int j = 0; j < item.Count; j++) {
                    res[j] += int.Parse(item[j]);
                }
            }
            for (int i = 0; i < res.Count; i++)
            {
                res[i] /= list.Count;
            }
            this.r1.Text = res[0].ToString();
            this.r2.Text = res[1].ToString();
            this.r3.Text = res[2].ToString();
            this.r4.Text = res[3].ToString();
            this.r5.Text = res[4].ToString();
            this.r6.Text = res[5].ToString();
            this.r7.Text = res[6].ToString();
            this.r8.Text = res[7].ToString();
        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
