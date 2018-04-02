//Name: BlockField.cs
//Purpose: Implements BlockField for Decorator Pattern
//Author: Brayden Faulkner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Management_Program
{
    public class BlockField : BlockWidget
    {
        TextBlock CurrBlock;
        public BlockField(TextBlock T)
        {
            CurrBlock = T;
        }
        public TextBlock Draw()
        {
            return CurrBlock;
        }
    }
}
