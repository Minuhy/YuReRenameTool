using RenameTools.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RenameTools
{
    public partial class ExecuteForm : Form
    {

        #region <常量>
        /// <summary>
        /// 输出信息面板的最大数据条数
        /// </summary>
        int MAX_SHOW_ITEM = 5000;
        #endregion <常量>

        #region <变量>
        /// <summary>
        /// MainForm中的改名任务列表
        /// </summary>
        private List<FileFolderInfo> infos;
        /// <summary>
        /// 是否正在处理任务
        /// </summary>
        private bool isOpen;
        /// <summary>
        /// 输出面板的信息
        /// </summary>
        private List<string> queueInfos = new List<string>();

        /// <summary>
        /// 改名后的文件路徑
        /// </summary>
        private List<string> NewFilePath;
        #endregion <变量>

        #region <属性>
        bool isComplete = false;
        #endregion <属性>

        #region <构造方法和析构方法>
        public ExecuteForm(List<FileFolderInfo> infos)
        {
            this.infos = infos;
            InitializeComponent();
        }
        #endregion <构造方法和析构方法>

        #region <方法>

        internal void Run()
        {
            isOpen = true;
            Thread thread = new Thread(new ThreadStart(Rename))
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void Rename()
        {
            var count = 0;
            var countIndex = 0;
            var countRaw = 0;

            // 清空改名後的列表
            NewFilePath = new List<string>();
#if DEBUG
            Console.WriteLine("开始重命名");
#endif
            List<string> failure = new List<string>();

            // 先重命名文件
            int i;
            for (i = 0; i < infos.Count; i++)
            {
                if (!isOpen)
                {
                    break;
                }

                FileFolderInfo ffi = infos[i];
                if (ffi.IsRename)
                {
                    NewFilePath.Add(ffi.NewPathName); // 添加到新列表中
                    continue;
                }

                if (ffi.IsDir)
                {
                    continue;
                }

                try
                {
                    FileInfo fi = new FileInfo(ffi.RawPathName);
                    if (!ffi.NewPathName.Equals(ffi.RawPathName))
                    {
                        fi.MoveTo(ffi.NewPathName);
                        count++;
                        Show(countIndex++, infos.Count, (i + 1) + ". 将 " + ffi.RawPathName + " 重命名为： " + ffi.NewPathName + " ;\n");
                        ffi.IsRename = true;
                    }
                    else
                    {
                        countRaw++;
                    }

                    NewFilePath.Add(ffi.NewPathName); // 添加到新列表中

#if DEBUG
                    Console.WriteLine("将" + ffi.RawPathName + "重命名为：" + ffi.NewPathName);
#endif

                }
                catch (Exception e)
                {
                    ffi.IsRename = false;
                    failure.Add(ffi.RawPathName);
                    NewFilePath.Add(ffi.RawPathName); // 添加到新列表中
                    Console.WriteLine(e);
                }
            }

            // 沒有完成的也添加進入
            for (; i < infos.Count; i++)
            {
                FileFolderInfo ffi = infos[i];

                if (ffi.IsDir)
                {
                    continue;
                }

                if (ffi.IsRename)
                {
                    NewFilePath.Add(ffi.NewPathName); // 添加到新列表中
                }
                else
                {
                    NewFilePath.Add(ffi.RawPathName); 
                }
            }


            // 再重命名文件夹
            for (i = 0; i < infos.Count; i++)
            {
                if (!isOpen)
                {
                    break;
                }

                FileFolderInfo ffi = infos[i];
                if (ffi.IsRename)
                {
                    NewFilePath.Add(ffi.NewPathName); // 添加到新列表中
                    continue;
                }

                if (ffi.IsFile)
                {
                    continue;
                }

                try
                {
                    FileInfo fi = new FileInfo(ffi.RawPathName);
                    if (!ffi.NewPathName.Equals(ffi.RawPathName))
                    {
                        fi.MoveTo(ffi.NewPathName);
                        count++;
                        Show(countIndex++, infos.Count, (i + 1) + ". 将 " + ffi.RawPathName + " 重命名为： " + ffi.NewPathName + " ;\n");
                        ffi.IsRename = true;
                    }
                    else
                    {
                        countRaw++;
                    }

                    NewFilePath.Add(ffi.NewPathName); // 添加到新列表中

#if DEBUG
                    Console.WriteLine("将" + ffi.RawPathName + "重命名为：" + ffi.NewPathName);
#endif
                }
                catch (Exception e)
                {
                    ffi.IsRename = false;
                    failure.Add(ffi.RawPathName);
                    NewFilePath.Add(ffi.RawPathName); // 添加到新列表中
                    Console.WriteLine(e);
                }
            }

            // 沒有完成的也添加進入
            for (; i < infos.Count; i++)
            {
                FileFolderInfo ffi = infos[i];

                if (ffi.IsFile)
                {
                    continue;
                }

                if (ffi.IsRename)
                {
                    NewFilePath.Add(ffi.NewPathName); // 添加到新列表中
                }
                else
                {
                    NewFilePath.Add(ffi.RawPathName);
                }
            }


            string str = "已完成";
            if (failure.Count > 0)
            {
                str += "，下面的失败了：\n";
                foreach (string s in failure)
                {
                    str = s + "\n";
                }
            }
            else
            {
                str += "，全部成功！\n";
            }
            Show(count, infos.Count, str);
            Finsh("完成，其中" + count + "个成功，" + (infos.Count - count) + "个失败，" + countRaw + "个不需要修改！");
            RenameOkEvent(failure,NewFilePath);
        }

        private void Finsh(string tips)
        {
            isComplete = true;
            if (btnStop.InvokeRequired)
            {
                lbPg.Invoke(
                    new Action<string>(n =>
                    {
                        btnStop.Text = "关闭";
                        MessageBox.Show(n, "提示", MessageBoxButtons.OK);
                    }
                ), tips);
            }
            isOpen = false;
        }

        private void Show(int index, int count, string info)
        {
            if (queueInfos.Count >= MAX_SHOW_ITEM)
            {
                queueInfos.RemoveAt(0);
            }

            queueInfos.Add(info);

            StringBuilder infos = new StringBuilder();
            for (int i = queueInfos.Count - 1; i >= 0; i--)
            {
                infos.Append(queueInfos[i]);
            }

            string pgStr = (index + 1) + "/" + (count + 1);
            int percent = (int)(index * 100.0 / count);
            if (lbPg.InvokeRequired && pgbMain.InvokeRequired && rtbInfo.InvokeRequired)
            {
                lbPg.Invoke(
                    new Action<string>(n =>
                    {
                        lbPg.Text = n.ToString();
                    }
                ), pgStr);

                pgbMain.Invoke(
                    new Action<int>(n =>
                    {
                        pgbMain.Value = n;
                    }
                ), percent);

                rtbInfo.Invoke(
                    new Action<StringBuilder>(n =>
                    {
                        rtbInfo.Text = n.ToString();
                    }
                ), infos);
            }
        }


        #endregion <方法>

        #region <事件>
        public delegate void RenameOk(List<string> failure,List<string> newPath);
        public event RenameOk RenameOkEvent;

        private void ExecuteForm_Load(object sender, EventArgs e)
        {

        }

        private void ExecuteForm_Shown(object sender, EventArgs e)
        {
            Run();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (isComplete)
            {
                isOpen = false;
                Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("是否停止？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    isOpen = false;
                    Close();
                }
            }
        }

        private void ExecuteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isOpen)
            {
                DialogResult dr = MessageBox.Show("是否停止？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    isOpen = false;
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion <事件>


    }
}
