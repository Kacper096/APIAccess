using APIAccess.View;
using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APIAccess.ViewModel
{
    public enum Windows
    {
        MainWindow,
        League
    }
    static class AppViewModel
    {
        public static void ShowWin(Windows toOpen)
        {
            switch(toOpen)
            {
                case Windows.League:
                    var league = new League();
                    league.Show();
                    break;
            }
        }
    }
}
