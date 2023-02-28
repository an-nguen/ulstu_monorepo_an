using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_coursework
{
    class MyEventArgs : EventArgs
    {
        public MyEventArgs() { }
        public MyEventArgs(bool isValid)
        {
            this.isValid = isValid;
        }

        public bool isValid;
    }
}
