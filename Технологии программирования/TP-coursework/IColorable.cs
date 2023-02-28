using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_coursework
{
    interface IColorable
    {
        void setBackColor(Color BackColor);
        Color getBackColor();

        void setForeColor(Color ForeColor);
        Color getForeColor();

        void setFont(Font font);
        Font getFont();
    }
}
