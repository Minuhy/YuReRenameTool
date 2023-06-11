using Microsoft.WindowsAPICodePack.Dialogs;
using RenameTools.Src;
using RenameTools.Src.Config;
using RenameTools.Src.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RenameTools
{

    public partial class MainForm : Form
    {
#if DEBUG
        public static bool Debug = false;
#endif
        public static bool IsOption = false;
        public static NameConfig Config;

        static bool Enable = true;

        static List<FileFolderInfo> infos;

        List<string> NewPathList;

        public MainForm()
        {
            Enable = true;
            infos = new List<FileFolderInfo>();
            InitializeComponent();
            InitConfig();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitConfig()
        {
            tbNewNameNumber.Text = "";
            tbNewNameNumberLeft.Text = "";
            tbNumberBegin.Text = "";
            tbNewNameRaw.Text = "";
            tbNewNameRawLeft.Text = "";
            tbNewSuffix.Text = "";
            tbRawField.Text = "";
            tbNewField.Text = "";

            cbRegularTrue.Checked = false;
            cbCaseFalse.Checked = false;
            rbRawName.Checked = true;

            ClearAllRawFile();

            Config_Changed(null,null);

            tbNumberBegin.Hint = "0,00,...(默认:0)";
        }

        public void ClearAllRawFile()
        {
            infos.Clear();
            lbRawNameList.Items.Clear();
            lbNewNameList.Items.Clear();
        }

        /// <summary>
        /// 批量重命名面板中点击数字方式或者原名方式切换
        /// </summary>
        /// <param name="sender">被点击的按钮</param>
        /// <param name="e">触发的事件</param>
        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            if(sender == rbNumberName)
            {
                // 数字方式命名
                ChangNamedWay(true,false);
            }
            else if(sender == rbRawName)
            {
                // 原文件名方式命名
                ChangNamedWay(false, false);
            }
            else if (sender == rbNewNameNumberLeft)
            {
                // 数字方式命名（数字在左）
                ChangNamedWay(true, true);
            }
            else if (sender == rbNewNameRawLeft)
            {
                // 原文件名方式命名（原文件名在左）
                ChangNamedWay(false, true);
            }

            Config_Changed(sender,e);
        }

        /// <summary>
        /// 改变命名方式
        /// </summary>
        /// <param name="isNumber">是否是数字</param>
        /// <param name="isLeft">是否是左边</param>
        void ChangNamedWay(bool isNumber,bool isLeft)
        {
            tbNewNameNumberLeft.Enabled = isNumber && isLeft;
            tbNewNameRawLeft.Enabled = !isNumber && isLeft;

            tbNewNameNumber.Enabled = isNumber && !isLeft;
            tbNewNameRaw.Enabled = !isNumber && !isLeft;

            tbNumberBegin.Enabled = isNumber;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if(Enable == false)
            {
                MessageBox.Show("正在执行操作，请稍等！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(lbUpHelp == sender) {
                MessageBox.Show("更改后按Tab键或者点击另外的控件使更改生效。", "帮助");
            }
            else
            if(lbOrderTips == sender)
            {
                MessageBox.Show("在文件管理器中排好序，选好后点击第一个被选中的项然后拖入列表中即是有序的。","如何排序");
            }else if(lbCleanInput == sender)
            {
                // 点击清除输入按钮
                InitConfig();
            }
            else if (sender == lbSeeChange)
            {
                // 预览更改
                RefreshNewName();
            }
            else if(btnAddFiles == sender)
            {
                DialogResult dr = MessageBox.Show("添加文件夹中的所有文件和文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    // 添加文件夹
                    var commonOpenFileDialog = new CommonOpenFileDialog
                    {
                        IsFolderPicker = true, //设置为true为选择文件夹，设置为false为选择文件
                        Title = "选择需要扫描的文件夹",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                    };

                    var result = commonOpenFileDialog.ShowDialog();
                    if (result == CommonFileDialogResult.Ok)
                    {
                        string path = commonOpenFileDialog.FileName;

                        if (string.IsNullOrEmpty(path))
                        {
                            MessageBox.Show("扫描文件路径不能为空");
                        }
                        else
                        {
                            //指定的文件夹目录
                            DirectoryInfo dir = new DirectoryInfo(path);
                            if (dir.Exists == false)
                            {
                                MessageBox.Show("路径不存在！请重新输入");
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("是否添加文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                WorlkFileForm form = new WorlkFileForm();
                                form.WorlkFilesEvent += Form_WorlkFilesEvent;
                                form.Start(dir, dialogResult == DialogResult.Yes);
                                form.ShowDialog();
                            }
                        }

                    }
                }
                else
                {
                    // 点击添加文件按钮
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Multiselect = true;//该值确定是否可以选择多个文件
                    dialog.Title = "请选择文件";
                    dialog.Filter = "所有文件(*.*)|*.*";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string[] files = dialog.FileNames;
                        AddFilesToSourceList(files);
                    }
                }
            }
            else if(btnStart == sender)
            {
                // 开始按钮
                Enable = false;
                ExecuteForm exe = new ExecuteForm(infos);
                exe.RenameOkEvent += Exe_ExecuteOkEvent;
                exe.ShowDialog(this);
            }
            else if (sender == lbClean)
            {
                // 清除所有内容
                DialogResult result = MessageBox.Show("是否清除列表中所有数据？", "清除", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if(result == DialogResult.OK)
                {
                    ClearAllRawFile();
                }
            }
        }

        private void AddListItem(ListBox listBox,object item)
        {
            if (listBox.InvokeRequired)
            {
                listBox.Invoke(
                    new Action<object>(n =>
                    {
                        listBox.Items.Add(n);
                    }
                ), item);
            }
            
        }

        private void Form_WorlkFilesEvent(string fileOrDir)
        {
            string[] filesOrDirs = { fileOrDir };
            AddFilesToSourceList(filesOrDirs,true);
        }

        private void Exe_ExecuteOkEvent(List<string> failure,List<string> NewPath)
        {
            this.NewPathList = NewPath;
            Enable = true;
        }

        void RefreshNewName()
        {
            lbRawNameList.Items.Clear();
            lbNewNameList.Items.Clear();

            for (int i=0;i<infos.Count;i++)
            {
                infos[i].GetNewName(Config);

                lbRawNameList.Items.Add(infos[i]);
                lbNewNameList.Items.Add(infos[i].NewName);
            }
        }


        /// <summary>
        /// 添加文件到列表中
        /// </summary>
        /// <param name="array">文件列表</param>
        /// <param name="isMt">是否是多線程添加</param>
        private void AddFilesToSourceList(Array array, bool isMt = false)
        {
            if(array == null || array.Length == 0)
            {
                return;
            }

            int fail = 0;

            foreach (object ff in array)
            {
                if (File.Exists(ff.ToString())
                    || Directory.Exists(ff.ToString()))
                {
#if DEBUG
                    Console.WriteLine("添加文件：" + ff.ToString());
#endif
                    AddFile(ff.ToString(),isMt);
                }else{
                    fail++;
                    // Console.WriteLine(ff.ToString());
                }
            }

            if (fail != 0)
            {
                MessageBox.Show("导入失败" + fail + "个", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LbRawNameList_DragDrop(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData(DataFormats.FileDrop);
            if (obj is Array array)
            {
                AddFilesToSourceList(array);

#if DEBUG
                Console.WriteLine("文件数组：" + array.Length+"个！");
#endif
            }


        }

        private void LbRawNameList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 如果是文件
                e.Effect = DragDropEffects.All;
            }
            else
            {
                // 如果不是文件
                e.Effect = DragDropEffects.None;
            }
        }

        private void LbRawNameList_DoubleClick(object sender, EventArgs e)
        {
            if(sender!= lbRawNameList)
            {
                return;
            }

            int index = lbRawNameList.SelectedIndex;
            RemoveFile(index);
        }

        // 委托
        public delegate void NameRuleChange(NameConfig config);
        public event NameRuleChange NameRuleChangeEvent;


        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="isMt">是否是多線程添加</param>
        public void AddFile(string file,bool isMt = false)
        {
            if (IsOption)
            {
                return;
            }
            IsOption = true;

            FileFolderInfo info = new FileFolderInfo(this,file, infos.Count);
            infos.Add(info);
            if (isMt)
            {
                AddListItem(lbNewNameList, info.GetNewName(Config));
                AddListItem(lbRawNameList, info);
            }
            else
            {
                lbNewNameList.Items.Add(info.GetNewName(Config));
                lbRawNameList.Items.Add(info);
            }

#if DEBUG
            if (Debug)
            {
                Console.WriteLine("添加文件");
            }
#endif
            IsOption = false;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="index">文件索引</param>
        public void RemoveFile(int index)
        {
            if(IsOption) 
            { 
                return; 
            }
            IsOption = true;

            if (index < infos.Count && index >= 0)
            {
                infos.RemoveAt(index);

                lbNewNameList.Items.RemoveAt(index);
                lbRawNameList.Items.RemoveAt(index);

                for (int i = index;i< infos.Count; i++)
                {
                    infos[i].SetIndex(i);
                    lbNewNameList.Items[i] = infos[i].ToString(true, true);
                    lbRawNameList.Items[i] = infos[i].ToString();
                }

#if DEBUG
                if (Debug)
                {
                    Console.WriteLine("移除文件");
                }
#endif
            }

            IsOption = false;
        }

        /// <summary>
        /// 只允许输入0-9的字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //这是允许输入退格键
            if (e.KeyChar != '\b')
            {
                //这是允许输入0-9数字
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 文件名合法输入校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 文件名不能包含如下字符
            if (
                    e.KeyChar == '\\'||                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                    e.KeyChar == '/' ||
                    e.KeyChar == ':' ||
                    e.KeyChar == '*' ||
                    e.KeyChar == '?' ||
                    e.KeyChar == '"' ||
                    e.KeyChar == '<' ||
                    e.KeyChar == '>' ||
                    e.KeyChar == '|'
                )
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 忽略大小写和正则的改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            if(sender == cbCaseFalse)
            {
                if (cbCaseFalse.Checked)
                {
                    cbRegularTrue.Checked = false;
                }
            }
            else if (sender == cbRegularTrue)
            {
                if (cbRegularTrue.Checked)
                {
                    cbCaseFalse.Checked = false;
                }
            }

            Config_Changed(sender,e);
        }

        private void Config_Changed(object sender, EventArgs e)
        {
            if(Config == null)
            {
                Config = new NameConfig();
            }

            bool isChange = false;

            if (Config.caseTrue != cbCaseFalse.Checked)
            {
                isChange = true;
                Config.caseTrue = cbCaseFalse.Checked;
            }

            if (Config.regularTrue != cbRegularTrue.Checked)
            {
                isChange = true;
                Config.regularTrue = cbRegularTrue.Checked;
            }

            if (Config.findText != tbRawField.Text)
            {
                isChange = true;
                Config.findText = tbRawField.Text;
            }

            if (Config.targetText != tbNewField.Text)
            {
                isChange = true;
                Config.targetText = tbNewField.Text;
            }

            if (Config.extend != tbNewSuffix.Text)
            {
                isChange = true;
                Config.extend = tbNewSuffix.Text;
            }

            RenameMode mode = RenameMode.None;
            string p1 = null, p2 = null;
            if (rbNumberName.Checked)
            {
                // *** + 数字
                mode = RenameMode.TextNumber;
               p1 = tbNewNameNumber.Text;
                if (tbNumberBegin.IsHint)
                {
                    p2 = "0";
                }
                else
                {
                    p2 = tbNumberBegin.Text;
                }
            }
            else if (rbNewNameNumberLeft.Checked)
            {
                // 数字 + ***
                mode = RenameMode.NumberText;
                p1 = tbNewNameNumberLeft.Text;

                if (tbNumberBegin.IsHint)
                {
                    p2 = "0";
                }
                else
                {
                    p2 = tbNumberBegin.Text;
                }
            }
            else if (rbRawName.Checked)
            {
                // *** + 原名
                mode = RenameMode.TextName;
                p1 = tbNewNameRaw.Text;
            }
            else if (rbNewNameRawLeft.Checked)
            {
                // 原名 + ***
                mode = RenameMode.NameText;
               p1 = tbNewNameRawLeft.Text;
            }

            if ((Config.mode != mode) && (mode != RenameMode.None))
            {
                isChange = true;
                Config.mode = mode;
            }
            if (Config.p1 != p1)
            {
                isChange = true;
                Config.p1 = p1;
            }
            if (Config.p2 != p2)
            {
                isChange = true;
                Config.p2 = p2;
            }

            if (isChange)
            {
#if DEBUG
                Console.WriteLine("Mode : " + Config.mode);
#endif
                NameRuleChangeEvent?.Invoke(Config);

                RefreshNewName();
            }
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sender is ListBox lb)
            {
                if(lb.SelectedIndex >=0 && lb.SelectedIndex< lb.Items.Count) { 
                    tbName.Text = lb.Items[lb.SelectedIndex].ToString();
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            Config_Changed(sender,e);
        }

        /// <summary>
        /// 重新引入文件，用于改名后重新添加到待改名位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reload_Click(object sender, EventArgs e)
        {
            if(this.NewPathList == null)
            {
                MessageBox.Show("無需重新引入","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            // 清除所有內容
            ClearAllRawFile();

            AddFilesToSourceList(this.NewPathList.ToArray());

            this.NewPathList = null;
        }
    }
}
