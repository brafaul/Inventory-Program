//Name: ColorDecorator.cs
//Purpose: Decorator that changes the background color of the textblock
//Author: Brayden Faulkner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Management_Program
{
    class ColorDecorator : BlockDecortator
    {
        DataGrid currGrid;
        String Color;
        BlockWidget wid;
        public ColorDecorator(string C, BlockWidget W)
        {
            Color = C;
            wid = W;
        }
        override public DataGrid Draw()
        {
            currGrid = wid.Draw();
            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(Color);
            currGrid.AlternatingRowBackground = brush;
            currGrid.Background = brush;
            return currGrid;
        }
    }
}
