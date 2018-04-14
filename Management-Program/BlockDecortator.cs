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
        private TextBlock currBlock;
        private BlockWidget wid;
        public BlockDecortator(BlockWidget W)
        {
            wid = W;
        }
        public TextBlock Draw()
        {
            currBlock = wid.Draw();
            return currBlock;
        }
    }
}
