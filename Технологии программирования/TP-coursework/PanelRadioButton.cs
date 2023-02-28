using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_coursework
{
    public partial class PanelRadioButton : UserControl
    {
        public List<RadioButton> radioButtons = new List<RadioButton>();

        public List<Panel> panels = new List<Panel>();

        [Browsable(true)]
        public int pages = 1;

        public PanelRadioButton()
        {
            InitializeComponent();
            addPages(pages);
        }

        public PanelRadioButton(int countPages) : this()
        {
            if (countPages < 0) throw new Exception("Кол-во страниц не может быть меньше чем 0");

            addPages(countPages);
        }

        public int getSize() => (panels.Count == radioButtons.Count) ? panels.Count : -1;

        public RadioButton getRadioButton(int index) => 
            (index >= 0 & index < radioButtons.Count) ? radioButtons[index] : null;
        public Panel getPanel(int index) => 
            (index >= 0 & index < panels.Count) ? panels[index] : null;

        private void addPages(int countPages)
        {
            for (int i = panels.Count; i < countPages+panels.Count; i++) {
                // Создаём RadioButton
                RadioButton newRB = new RadioButton();
                newRB.Name = "radioButton" + i;
                newRB.Size = new Size(85, 17);
                newRB.Location = new Point(94*(i+1), 4);
                newRB.TabStop = true;
                newRB.Text = "radioButton" + i;
                newRB.UseVisualStyleBackColor = true;
                newRB.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
                
                // Создаём Panel
                Panel newP = new Panel();
                newP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                newP.AutoSize = true;
                newP.Location = new Point(4, 27);
                newP.Name = "panel" + i;
                newP.Size = new Size(473, 210);

                // Добавляем в коллекцию новые элементы
                radioButtons.Add(newRB);
                panels.Add(newP);

                // Добавляем в наш UserControl
                Controls.Add(newRB);
                Controls.Add(newP);
            }
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton)) return;

            int index = radioButtons.IndexOf(sender as RadioButton);
            // Делаем все Panel-и - невидимыми
            foreach (Panel each in panels)
                each.Visible = false;
            panels[index].Visible = true;
        }
    }
}
