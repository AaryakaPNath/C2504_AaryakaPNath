using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonProject
{
    static class PersonConfig
    {
        public static Window2 FrmEditPerson { get; set; }
        public static PersonViewModel VueModel { get; set; }
        static PersonConfig()
        {
            VueModel = new PersonViewModel();
            FrmEditPerson = new Window2();
        }
    }
}
