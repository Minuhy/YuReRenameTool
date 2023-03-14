using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RenameTools
{
    public partial class WorlkFileForm : Form
    {
        int failCount = 0;
        bool isRun = true;

        DirectoryInfo dir; 
        bool isAddDir = false;

        static long backupTime = 0;

        public WorlkFileForm()
        {
            InitializeComponent();
            failCount = 0;
        }

        public void Start(DirectoryInfo dir, bool isAddDir = false)
        {
            this.dir = dir;
            this.isAddDir = isAddDir;
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        public delegate void WorlkFiles(string fileOrDir);
        public event WorlkFiles WorlkFilesEvent;

        private void Run()
        {
            var reslut = GetAllFilesAndDirs(dir, isAddDir);
            if (isRun)
            {
                // Console.WriteLine("完成扫描");
                if (failCount == 0)
                {
                    Show("完成扫描（" + reslut.Length + "个），正在添加......", false, true);
                }
                else
                {
                    Show("完成扫描（" + reslut.Length + "个，"+failCount+"个失败），正在添加......", false, true);
                }
                int count = 0;
                foreach (string f in reslut)
                {
                    if (!isRun)
                    {
                        break;
                    }

                    WorlkFilesEvent?.Invoke(f);
                    count++;
                }

                Show("完成，共添加"+ count+"个，失败"+(reslut.Length+ failCount- count)+"个！", true, true);
            }
            else
            {
                // Console.WriteLine("完成扫描，已关闭");
            }
        }

        private void Show(string text, bool isComplete=false, bool isShow=false)
        {
            long curTime = DateTime.Now.Millisecond;
            if (curTime - backupTime > 100 || isShow) // 200ms 显示一次
            {
                backupTime = curTime;

                if (lbInfo.InvokeRequired)
                {
                    lbInfo.Invoke(
                        new Action<string>(n =>
                        {
                            lbInfo.Text = n.ToString();
                        }
                    ), text);
                }
            }
            

            if (isComplete)
            {
                if (InvokeRequired)
                {
                    Invoke(
                        new Action<string>(n =>
                        {
                            MessageBox.Show(n, "添加结果", MessageBoxButtons.OK);
                            Close();
                        }
                    ), text);
                }
            }
        }

        private void WorlkAllFilesAndDirs(DirectoryInfo dir, List<string> fileList, bool isAddDirs = false)
        {
            if (!isRun)
            {
                return;
            }

            FileSystemInfo[] fsinfos = null;
            DirectoryInfo[] dirinfos = null;
            try
            {
                // 遍历文件
                fsinfos = dir.GetFiles();
                // 遍历目录
                dirinfos = dir.GetDirectories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                failCount++;
            }

            if (fsinfos != null)
            {
                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    var reslut = fsinfo.FullName;
                    // Show(reslut);
                    fileList.Add(reslut);
#if DEBUG
                    if (MainForm.Debug)
                    {

                        Console.WriteLine("文件" + fsinfo.FullName);
                    }
#endif
                }
            }

            if (dirinfos != null)
            {
                foreach (DirectoryInfo dirinfo in dirinfos)
                {
                    if (isAddDirs)
                    {
                        var reslut = dirinfo.FullName;
                        // Show(reslut);
                        fileList.Add(reslut);
                    }
#if DEBUG
                    // fileList.Add(fsinfo.FullName);
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("目录" + dirinfo.FullName);
                    }
#endif
                    WorlkAllFilesAndDirs(dirinfo, fileList, isAddDirs);
                }
            }
        }

        private string[] GetAllFilesAndDirs(DirectoryInfo dir, bool isAddDir = false)
        {
            List<string> fileList = new List<string>();
            WorlkAllFilesAndDirs(dir, fileList, isAddDir);
            return fileList.ToArray();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否停止？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                isRun = false;
                // Close();
            }
        }
    }
}
