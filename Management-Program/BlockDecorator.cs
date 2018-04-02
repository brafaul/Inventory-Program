using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Management_Program
{
    public class BlockDecorator : BlockWidget
    {
        string CurLine = null;
        TextBlock CurrBlock;
        TDatabase database;
        BlockWidget wid;
        public BlockDecorator(BlockWidget W, TDatabase D)
        {
            wid = W;
            database = D;
        }
        public TextBlock Draw()
        {
            CurrBlock = wid.Draw();
            CurrBlock.Text = String.Empty;
            for(int i = 0; i < database.Size(); i++)
            {
                CurLine = null;
                CurLine = database.GetElement(i).GetName() + ' ';
                CurLine = CurLine + database.GetElement(i).GetAmount() + ' ';
                CurLine = CurLine + database.GetElement(i).GetID() + '\n';
                CurrBlock.Inlines.Add(CurLine);
            }
            return CurrBlock;
        }
    }
}
