using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FullNameProject
{
    static class PersonConfig
    {
        public static Window FrmEditFullName { get; set; }
        public static PersonViewModel VueModel { get; set; }
        static PersonConfig()
        {
            VueModel = new PersonViewModel();
            FrmEditFullName = new EditFullNameWindow();
        }
    }
}
