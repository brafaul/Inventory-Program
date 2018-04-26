//Name: BlockWidget.cs
//Purpose: Adds widget for decorator pattern that adds text to textblock on main window
//Author: Brayden Faulkner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Management_Program
{
    public interface BlockWidget
    {
        DataGrid Draw();
    }
}
