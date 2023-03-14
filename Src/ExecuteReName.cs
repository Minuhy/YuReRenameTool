using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RenameTools.Src
{
    class ExecuteReName
    {
        public delegate void ExecuteOk(bool isOk);
        public event ExecuteOk ExecuteOkEvent;
        public ExecuteReName(List<FileFolderInfo> infos)
        {

        }

        internal void Run()
        {
            throw new NotImplementedException();
        }
    }
}
