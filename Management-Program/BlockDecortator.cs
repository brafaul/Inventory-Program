//Name: BlockDecorator.cs
//Purpose: Abstract blockdecorator that is overwritten by other decoratos
//Author: Brayden Faulkner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Management_Program
{
    public abstract class BlockDecortator: BlockWidget
    {
        public abstract DataGrid Draw();
    }
}
