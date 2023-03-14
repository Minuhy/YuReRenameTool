#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：MINC3480
 * 公司名称：
 * 命名空间：RenameTools.Src.UI
 * 唯一标识：f76a12c1-0890-4e3d-92d4-e1f115716113
 * 文件名：FolderDialog
 * 当前用户域：MINC3480
 * 
 * 创建者：Minuy
 * 电子邮箱：minuy17@163.com
 * 创建时间：2022/11/21 20:43:56
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RenameTools.Src.UI
{
    class FolderDialog : FolderNameEditor
    {
        FolderNameEditor.FolderBrowser fDialog = new
             FolderNameEditor.FolderBrowser();
        //构造函数
        public FolderDialog()
        {

        }

        public DialogResult DisplayDialog()
        {
            return DisplayDialog("请选择一个文件夹");
        }

        public DialogResult DisplayDialog(string description)
        {
            fDialog.Description = description;
            return fDialog.ShowDialog();
        }

        public string Path
        {
            get
            {
                return fDialog.DirectoryPath;
            }
        }

        //析构函数
        ~FolderDialog()
        {
            fDialog.Dispose();
        }
    }
}