using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ItenaryProject
{
    public static class ItenaryConfig
    {
        //forms 
        public static Window FrmNewIternary { get; set; }

        public static Window FrmEditIternary { get; set; }
        //view model
        public static IternaryViewModel VueModel { get; set; }

        static ItenaryConfig()
        {
            VueModel = new IternaryViewModel();
            FrmNewIternary = new NewIternaryWindow();
            FrmEditIternary = new EditItenaryWindow();

        }
    }
}
