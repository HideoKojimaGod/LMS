using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    interface IStyler
    {
       Button SetDefaultButtonStyle(string text);
       Label SetDefaultLabelStyle(string text);
    }
}
