
namespace RenameTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbBatRename = new System.Windows.Forms.GroupBox();
            this.rbNewNameRawLeft = new System.Windows.Forms.RadioButton();
            this.tbNewNameRawLeft = new System.Windows.Forms.TextBox();
            this.lbNewNameRawLeft = new System.Windows.Forms.Label();
            this.rbNewNameNumberLeft = new System.Windows.Forms.RadioButton();
            this.tbNewNameNumberLeft = new System.Windows.Forms.TextBox();
            this.lbNewNameNumberLeft = new System.Windows.Forms.Label();
            this.tbNewSuffix = new System.Windows.Forms.TextBox();
            this.lbSuffix = new System.Windows.Forms.Label();
            this.lbSp2 = new System.Windows.Forms.Label();
            this.rbRawName = new System.Windows.Forms.RadioButton();
            this.tbNewNameRaw = new System.Windows.Forms.TextBox();
            this.lbSp1 = new System.Windows.Forms.Label();
            this.tbNumberBegin = new RenameTools.Src.UI.TextBoxHint();
            this.lbBeginNumber = new System.Windows.Forms.Label();
            this.rbNumberName = new System.Windows.Forms.RadioButton();
            this.tbNewNameNumber = new System.Windows.Forms.TextBox();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbRawFile = new System.Windows.Forms.GroupBox();
            this.lbOrderTips = new System.Windows.Forms.Label();
            this.lbClean = new System.Windows.Forms.Label();
            this.lbRawNameList = new System.Windows.Forms.ListBox();
            this.gbNewName = new System.Windows.Forms.GroupBox();
            this.lbSeeChange = new System.Windows.Forms.Label();
            this.lbNewNameList = new System.Windows.Forms.ListBox();
            this.gbReplaceRename = new System.Windows.Forms.GroupBox();
            this.cbRegularTrue = new System.Windows.Forms.CheckBox();
            this.cbCaseFalse = new System.Windows.Forms.CheckBox();
            this.tbNewField = new System.Windows.Forms.TextBox();
            this.lbNewField = new System.Windows.Forms.Label();
            this.tbRawField = new System.Windows.Forms.TextBox();
            this.lbRawField = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lbCleanInput = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbUpHelp = new System.Windows.Forms.Label();
            this.lbReload = new System.Windows.Forms.Label();
            this.gbBatRename.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbRawFile.SuspendLayout();
            this.gbNewName.SuspendLayout();
            this.gbReplaceRename.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBatRename
            // 
            this.gbBatRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBatRename.Controls.Add(this.rbNewNameRawLeft);
            this.gbBatRename.Controls.Add(this.tbNewNameRawLeft);
            this.gbBatRename.Controls.Add(this.lbNewNameRawLeft);
            this.gbBatRename.Controls.Add(this.rbNewNameNumberLeft);
            this.gbBatRename.Controls.Add(this.tbNewNameNumberLeft);
            this.gbBatRename.Controls.Add(this.lbNewNameNumberLeft);
            this.gbBatRename.Controls.Add(this.tbNewSuffix);
            this.gbBatRename.Controls.Add(this.lbSuffix);
            this.gbBatRename.Controls.Add(this.lbSp2);
            this.gbBatRename.Controls.Add(this.rbRawName);
            this.gbBatRename.Controls.Add(this.tbNewNameRaw);
            this.gbBatRename.Controls.Add(this.lbSp1);
            this.gbBatRename.Controls.Add(this.tbNumberBegin);
            this.gbBatRename.Controls.Add(this.lbBeginNumber);
            this.gbBatRename.Controls.Add(this.rbNumberName);
            this.gbBatRename.Controls.Add(this.tbNewNameNumber);
            this.gbBatRename.Location = new System.Drawing.Point(572, 12);
            this.gbBatRename.Name = "gbBatRename";
            this.gbBatRename.Size = new System.Drawing.Size(200, 202);
            this.gbBatRename.TabIndex = 0;
            this.gbBatRename.TabStop = false;
            this.gbBatRename.Text = "批量重命名";
            // 
            // rbNewNameRawLeft
            // 
            this.rbNewNameRawLeft.AutoSize = true;
            this.rbNewNameRawLeft.Location = new System.Drawing.Point(180, 142);
            this.rbNewNameRawLeft.Name = "rbNewNameRawLeft";
            this.rbNewNameRawLeft.Size = new System.Drawing.Size(14, 13);
            this.rbNewNameRawLeft.TabIndex = 15;
            this.rbNewNameRawLeft.TabStop = true;
            this.rbNewNameRawLeft.UseVisualStyleBackColor = true;
            this.rbNewNameRawLeft.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
            // 
            // tbNewNameRawLeft
            // 
            this.tbNewNameRawLeft.Location = new System.Drawing.Point(51, 138);
            this.tbNewNameRawLeft.Name = "tbNewNameRawLeft";
            this.tbNewNameRawLeft.Size = new System.Drawing.Size(123, 21);
            this.tbNewNameRawLeft.TabIndex = 14;
            this.tbNewNameRawLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputFileName_KeyPress);
            this.tbNewNameRawLeft.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbNewNameRawLeft
            // 
            this.lbNewNameRawLeft.AutoSize = true;
            this.lbNewNameRawLeft.Location = new System.Drawing.Point(6, 142);
            this.lbNewNameRawLeft.Name = "lbNewNameRawLeft";
            this.lbNewNameRawLeft.Size = new System.Drawing.Size(41, 12);
            this.lbNewNameRawLeft.TabIndex = 13;
            this.lbNewNameRawLeft.Text = "原名 +";
            // 
            // rbNewNameNumberLeft
            // 
            this.rbNewNameNumberLeft.AutoSize = true;
            this.rbNewNameNumberLeft.Location = new System.Drawing.Point(180, 51);
            this.rbNewNameNumberLeft.Name = "rbNewNameNumberLeft";
            this.rbNewNameNumberLeft.Size = new System.Drawing.Size(14, 13);
            this.rbNewNameNumberLeft.TabIndex = 12;
            this.rbNewNameNumberLeft.TabStop = true;
            this.rbNewNameNumberLeft.UseVisualStyleBackColor = true;
            this.rbNewNameNumberLeft.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
            // 
            // tbNewNameNumberLeft
            // 
            this.tbNewNameNumberLeft.Location = new System.Drawing.Point(51, 47);
            this.tbNewNameNumberLeft.Name = "tbNewNameNumberLeft";
            this.tbNewNameNumberLeft.Size = new System.Drawing.Size(123, 21);
            this.tbNewNameNumberLeft.TabIndex = 11;
            this.tbNewNameNumberLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputFileName_KeyPress);
            this.tbNewNameNumberLeft.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbNewNameNumberLeft
            // 
            this.lbNewNameNumberLeft.AutoSize = true;
            this.lbNewNameNumberLeft.Location = new System.Drawing.Point(6, 51);
            this.lbNewNameNumberLeft.Name = "lbNewNameNumberLeft";
            this.lbNewNameNumberLeft.Size = new System.Drawing.Size(41, 12);
            this.lbNewNameNumberLeft.TabIndex = 10;
            this.lbNewNameNumberLeft.Text = "数字 +";
            // 
            // tbNewSuffix
            // 
            this.tbNewSuffix.Location = new System.Drawing.Point(94, 175);
            this.tbNewSuffix.Name = "tbNewSuffix";
            this.tbNewSuffix.Size = new System.Drawing.Size(100, 21);
            this.tbNewSuffix.TabIndex = 9;
            this.tbNewSuffix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputFileName_KeyPress);
            this.tbNewSuffix.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbSuffix
            // 
            this.lbSuffix.AutoSize = true;
            this.lbSuffix.Location = new System.Drawing.Point(6, 179);
            this.lbSuffix.Name = "lbSuffix";
            this.lbSuffix.Size = new System.Drawing.Size(89, 12);
            this.lbSuffix.TabIndex = 8;
            this.lbSuffix.Text = "修改扩展名为：";
            // 
            // lbSp2
            // 
            this.lbSp2.AutoSize = true;
            this.lbSp2.Location = new System.Drawing.Point(1, 162);
            this.lbSp2.Name = "lbSp2";
            this.lbSp2.Size = new System.Drawing.Size(197, 12);
            this.lbSp2.TabIndex = 7;
            this.lbSp2.Text = "————————————————";
            // 
            // rbRawName
            // 
            this.rbRawName.AutoSize = true;
            this.rbRawName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbRawName.Location = new System.Drawing.Point(129, 113);
            this.rbRawName.Name = "rbRawName";
            this.rbRawName.Size = new System.Drawing.Size(65, 16);
            this.rbRawName.TabIndex = 6;
            this.rbRawName.TabStop = true;
            this.rbRawName.Text = " + 原名";
            this.rbRawName.UseVisualStyleBackColor = true;
            this.rbRawName.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
            // 
            // tbNewNameRaw
            // 
            this.tbNewNameRaw.Location = new System.Drawing.Point(6, 111);
            this.tbNewNameRaw.Name = "tbNewNameRaw";
            this.tbNewNameRaw.Size = new System.Drawing.Size(123, 21);
            this.tbNewNameRaw.TabIndex = 5;
            this.tbNewNameRaw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputFileName_KeyPress);
            this.tbNewNameRaw.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbSp1
            // 
            this.lbSp1.AutoSize = true;
            this.lbSp1.Location = new System.Drawing.Point(1, 98);
            this.lbSp1.Name = "lbSp1";
            this.lbSp1.Size = new System.Drawing.Size(197, 12);
            this.lbSp1.TabIndex = 4;
            this.lbSp1.Text = "————————————————";
            // 
            // tbNumberBegin
            // 
            this.tbNumberBegin.ForeColor = System.Drawing.Color.Gray;
            this.tbNumberBegin.Hint = "0,00,000,...（默认为0）";
            this.tbNumberBegin.Location = new System.Drawing.Point(89, 74);
            this.tbNumberBegin.Name = "tbNumberBegin";
            this.tbNumberBegin.Size = new System.Drawing.Size(105, 21);
            this.tbNumberBegin.TabIndex = 3;
            this.tbNumberBegin.Text = "0,00,000,...（默认为0）";
            this.tbNumberBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputNumber_KeyPress);
            this.tbNumberBegin.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbBeginNumber
            // 
            this.lbBeginNumber.AutoSize = true;
            this.lbBeginNumber.Location = new System.Drawing.Point(6, 79);
            this.lbBeginNumber.Name = "lbBeginNumber";
            this.lbBeginNumber.Size = new System.Drawing.Size(77, 12);
            this.lbBeginNumber.TabIndex = 2;
            this.lbBeginNumber.Text = "数字起始值：";
            // 
            // rbNumberName
            // 
            this.rbNumberName.AutoSize = true;
            this.rbNumberName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbNumberName.Location = new System.Drawing.Point(135, 22);
            this.rbNumberName.Name = "rbNumberName";
            this.rbNumberName.Size = new System.Drawing.Size(59, 16);
            this.rbNumberName.TabIndex = 1;
            this.rbNumberName.TabStop = true;
            this.rbNumberName.Text = "+ 数字";
            this.rbNumberName.UseVisualStyleBackColor = true;
            this.rbNumberName.CheckedChanged += new System.EventHandler(this.Rb_CheckedChanged);
            // 
            // tbNewNameNumber
            // 
            this.tbNewNameNumber.Location = new System.Drawing.Point(6, 20);
            this.tbNewNameNumber.Name = "tbNewNameNumber";
            this.tbNewNameNumber.Size = new System.Drawing.Size(123, 21);
            this.tbNewNameNumber.TabIndex = 0;
            this.tbNewNameNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputFileName_KeyPress);
            this.tbNewNameNumber.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.Location = new System.Drawing.Point(9, 12);
            this.scMain.Margin = new System.Windows.Forms.Padding(0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbRawFile);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbNewName);
            this.scMain.Size = new System.Drawing.Size(554, 384);
            this.scMain.SplitterDistance = 342;
            this.scMain.TabIndex = 1;
            // 
            // gbRawFile
            // 
            this.gbRawFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRawFile.Controls.Add(this.lbOrderTips);
            this.gbRawFile.Controls.Add(this.lbClean);
            this.gbRawFile.Controls.Add(this.lbRawNameList);
            this.gbRawFile.Location = new System.Drawing.Point(0, 0);
            this.gbRawFile.Margin = new System.Windows.Forms.Padding(0);
            this.gbRawFile.Name = "gbRawFile";
            this.gbRawFile.Size = new System.Drawing.Size(340, 384);
            this.gbRawFile.TabIndex = 0;
            this.gbRawFile.TabStop = false;
            this.gbRawFile.Text = "原文件（拖入添加，双击删除）";
            // 
            // lbOrderTips
            // 
            this.lbOrderTips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOrderTips.AutoSize = true;
            this.lbOrderTips.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbOrderTips.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbOrderTips.Location = new System.Drawing.Point(247, 1);
            this.lbOrderTips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOrderTips.Name = "lbOrderTips";
            this.lbOrderTips.Size = new System.Drawing.Size(29, 12);
            this.lbOrderTips.TabIndex = 7;
            this.lbOrderTips.Text = "排序";
            this.lbOrderTips.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lbClean
            // 
            this.lbClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClean.AutoSize = true;
            this.lbClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbClean.Location = new System.Drawing.Point(281, 1);
            this.lbClean.Name = "lbClean";
            this.lbClean.Size = new System.Drawing.Size(53, 12);
            this.lbClean.TabIndex = 1;
            this.lbClean.Text = "清除所有";
            this.lbClean.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lbRawNameList
            // 
            this.lbRawNameList.AllowDrop = true;
            this.lbRawNameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRawNameList.FormattingEnabled = true;
            this.lbRawNameList.IntegralHeight = false;
            this.lbRawNameList.ItemHeight = 12;
            this.lbRawNameList.Location = new System.Drawing.Point(3, 16);
            this.lbRawNameList.Name = "lbRawNameList";
            this.lbRawNameList.Size = new System.Drawing.Size(334, 364);
            this.lbRawNameList.TabIndex = 0;
            this.lbRawNameList.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            this.lbRawNameList.DragDrop += new System.Windows.Forms.DragEventHandler(this.LbRawNameList_DragDrop);
            this.lbRawNameList.DragEnter += new System.Windows.Forms.DragEventHandler(this.LbRawNameList_DragEnter);
            this.lbRawNameList.DoubleClick += new System.EventHandler(this.LbRawNameList_DoubleClick);
            // 
            // gbNewName
            // 
            this.gbNewName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNewName.Controls.Add(this.lbReload);
            this.gbNewName.Controls.Add(this.lbSeeChange);
            this.gbNewName.Controls.Add(this.lbNewNameList);
            this.gbNewName.Location = new System.Drawing.Point(0, 0);
            this.gbNewName.Margin = new System.Windows.Forms.Padding(0);
            this.gbNewName.Name = "gbNewName";
            this.gbNewName.Size = new System.Drawing.Size(206, 384);
            this.gbNewName.TabIndex = 0;
            this.gbNewName.TabStop = false;
            this.gbNewName.Text = "新文件名";
            // 
            // lbSeeChange
            // 
            this.lbSeeChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSeeChange.AutoSize = true;
            this.lbSeeChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbSeeChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbSeeChange.Location = new System.Drawing.Point(147, 1);
            this.lbSeeChange.Name = "lbSeeChange";
            this.lbSeeChange.Size = new System.Drawing.Size(53, 12);
            this.lbSeeChange.TabIndex = 7;
            this.lbSeeChange.Text = "预览更改";
            this.lbSeeChange.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lbNewNameList
            // 
            this.lbNewNameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNewNameList.FormattingEnabled = true;
            this.lbNewNameList.IntegralHeight = false;
            this.lbNewNameList.ItemHeight = 12;
            this.lbNewNameList.Location = new System.Drawing.Point(3, 16);
            this.lbNewNameList.Name = "lbNewNameList";
            this.lbNewNameList.Size = new System.Drawing.Size(200, 364);
            this.lbNewNameList.TabIndex = 0;
            this.lbNewNameList.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // gbReplaceRename
            // 
            this.gbReplaceRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReplaceRename.Controls.Add(this.cbRegularTrue);
            this.gbReplaceRename.Controls.Add(this.cbCaseFalse);
            this.gbReplaceRename.Controls.Add(this.tbNewField);
            this.gbReplaceRename.Controls.Add(this.lbNewField);
            this.gbReplaceRename.Controls.Add(this.tbRawField);
            this.gbReplaceRename.Controls.Add(this.lbRawField);
            this.gbReplaceRename.Location = new System.Drawing.Point(572, 220);
            this.gbReplaceRename.Name = "gbReplaceRename";
            this.gbReplaceRename.Size = new System.Drawing.Size(200, 97);
            this.gbReplaceRename.TabIndex = 1;
            this.gbReplaceRename.TabStop = false;
            this.gbReplaceRename.Text = "替换重命名";
            // 
            // cbRegularTrue
            // 
            this.cbRegularTrue.AutoSize = true;
            this.cbRegularTrue.Location = new System.Drawing.Point(108, 74);
            this.cbRegularTrue.Name = "cbRegularTrue";
            this.cbRegularTrue.Size = new System.Drawing.Size(84, 16);
            this.cbRegularTrue.TabIndex = 5;
            this.cbRegularTrue.Text = "正则表达式";
            this.cbRegularTrue.UseVisualStyleBackColor = true;
            this.cbRegularTrue.CheckedChanged += new System.EventHandler(this.Cb_CheckedChanged);
            // 
            // cbCaseFalse
            // 
            this.cbCaseFalse.AutoSize = true;
            this.cbCaseFalse.Location = new System.Drawing.Point(6, 74);
            this.cbCaseFalse.Name = "cbCaseFalse";
            this.cbCaseFalse.Size = new System.Drawing.Size(96, 16);
            this.cbCaseFalse.TabIndex = 4;
            this.cbCaseFalse.Text = "不区分大小写";
            this.cbCaseFalse.UseVisualStyleBackColor = true;
            this.cbCaseFalse.CheckedChanged += new System.EventHandler(this.Cb_CheckedChanged);
            // 
            // tbNewField
            // 
            this.tbNewField.Location = new System.Drawing.Point(77, 47);
            this.tbNewField.Name = "tbNewField";
            this.tbNewField.Size = new System.Drawing.Size(117, 21);
            this.tbNewField.TabIndex = 3;
            this.tbNewField.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbNewField
            // 
            this.lbNewField.AutoSize = true;
            this.lbNewField.Location = new System.Drawing.Point(6, 51);
            this.lbNewField.Name = "lbNewField";
            this.lbNewField.Size = new System.Drawing.Size(53, 12);
            this.lbNewField.TabIndex = 2;
            this.lbNewField.Text = "替换为：";
            // 
            // tbRawField
            // 
            this.tbRawField.Location = new System.Drawing.Point(77, 20);
            this.tbRawField.Name = "tbRawField";
            this.tbRawField.Size = new System.Drawing.Size(117, 21);
            this.tbRawField.TabIndex = 1;
            this.tbRawField.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lbRawField
            // 
            this.lbRawField.AutoSize = true;
            this.lbRawField.Location = new System.Drawing.Point(6, 24);
            this.lbRawField.Name = "lbRawField";
            this.lbRawField.Size = new System.Drawing.Size(65, 12);
            this.lbRawField.TabIndex = 0;
            this.lbRawField.Text = "查找内容：";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(697, 397);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFiles.Location = new System.Drawing.Point(572, 397);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(119, 23);
            this.btnAddFiles.TabIndex = 3;
            this.btnAddFiles.Text = "添加文件或文件夹";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lbCleanInput
            // 
            this.lbCleanInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCleanInput.AutoSize = true;
            this.lbCleanInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCleanInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbCleanInput.Location = new System.Drawing.Point(719, 320);
            this.lbCleanInput.Name = "lbCleanInput";
            this.lbCleanInput.Size = new System.Drawing.Size(53, 12);
            this.lbCleanInput.TabIndex = 6;
            this.lbCleanInput.Text = "清除输入";
            this.lbCleanInput.Click += new System.EventHandler(this.Btn_Click);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(9, 399);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(554, 21);
            this.tbName.TabIndex = 7;
            // 
            // lbUpHelp
            // 
            this.lbUpHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUpHelp.AutoSize = true;
            this.lbUpHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbUpHelp.ForeColor = System.Drawing.Color.Olive;
            this.lbUpHelp.Location = new System.Drawing.Point(660, 320);
            this.lbUpHelp.Name = "lbUpHelp";
            this.lbUpHelp.Size = new System.Drawing.Size(53, 12);
            this.lbUpHelp.TabIndex = 8;
            this.lbUpHelp.Text = "更改帮助";
            this.lbUpHelp.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lbReload
            // 
            this.lbReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReload.AutoSize = true;
            this.lbReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbReload.Location = new System.Drawing.Point(88, 1);
            this.lbReload.Name = "lbReload";
            this.lbReload.Size = new System.Drawing.Size(53, 12);
            this.lbReload.TabIndex = 8;
            this.lbReload.Text = "重新引入";
            this.lbReload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 432);
            this.Controls.Add(this.lbUpHelp);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbCleanInput);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbReplaceRename);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.gbBatRename);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重命名工具";
            this.gbBatRename.ResumeLayout(false);
            this.gbBatRename.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.gbRawFile.ResumeLayout(false);
            this.gbRawFile.PerformLayout();
            this.gbNewName.ResumeLayout(false);
            this.gbNewName.PerformLayout();
            this.gbReplaceRename.ResumeLayout(false);
            this.gbReplaceRename.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBatRename;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Label lbSp1;
        private Src.UI.TextBoxHint tbNumberBegin;
        private System.Windows.Forms.Label lbBeginNumber;
        private System.Windows.Forms.RadioButton rbNumberName;
        private System.Windows.Forms.TextBox tbNewNameNumber;
        private System.Windows.Forms.GroupBox gbReplaceRename;
        private System.Windows.Forms.TextBox tbNewSuffix;
        private System.Windows.Forms.Label lbSuffix;
        private System.Windows.Forms.Label lbSp2;
        private System.Windows.Forms.RadioButton rbRawName;
        private System.Windows.Forms.TextBox tbNewNameRaw;
        private System.Windows.Forms.CheckBox cbCaseFalse;
        private System.Windows.Forms.TextBox tbNewField;
        private System.Windows.Forms.Label lbNewField;
        private System.Windows.Forms.TextBox tbRawField;
        private System.Windows.Forms.Label lbRawField;
        private System.Windows.Forms.CheckBox cbRegularTrue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbRawFile;
        private System.Windows.Forms.GroupBox gbNewName;
        private System.Windows.Forms.RadioButton rbNewNameRawLeft;
        private System.Windows.Forms.TextBox tbNewNameRawLeft;
        private System.Windows.Forms.Label lbNewNameRawLeft;
        private System.Windows.Forms.RadioButton rbNewNameNumberLeft;
        private System.Windows.Forms.TextBox tbNewNameNumberLeft;
        private System.Windows.Forms.Label lbNewNameNumberLeft;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ListBox lbRawNameList;
        private System.Windows.Forms.ListBox lbNewNameList;
        private System.Windows.Forms.Label lbClean;
        private System.Windows.Forms.Label lbCleanInput;
        private System.Windows.Forms.Label lbSeeChange;
        private System.Windows.Forms.Label lbOrderTips;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbUpHelp;
        private System.Windows.Forms.Label lbReload;
    }
}

