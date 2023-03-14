using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RenameTools.Src.Event
{
    class ListChangeEventArgs : EventArgs
    {
        public int Index { get; private set; }
        public bool IsAdd { get; private set; }
        public object Item { get; private set; }
        public ListChangeEventArgs(int index, object file = null)
        {
            Index = index;
            if (file != null)
            {
                IsAdd = true;
            }
            Item = file;
        }
    }
}
