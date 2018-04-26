using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Management_Program
{
    public class ModifyFac
    {
        TDatabase database;
        string log;
        SolidColorBrush Color;
        public ModifyFac(TDatabase D, string L,SolidColorBrush C)
        {
            database = D;
            log = L;
            Color = C;
        }
        public ModifyWindow BuildWindow()
        {
            ModifyWindow Mod = new ModifyWindow(database,log);
            Mod.Background = Color;
            return Mod;
        }
    }
}
