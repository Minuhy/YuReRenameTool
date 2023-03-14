
namespace RenameTools
{
    partial class ExecuteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteForm));
            this.pgbMain = new System.Windows.Forms.ProgressBar();
            this.lbPg = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pgbMain
            // 
            this.pgbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbMain.Location = new System.Drawing.Point(12, 24);
            this.pgbMain.Name = "pgbMain";
            this.pgbMain.Size = new System.Drawing.Size(460, 23);
            this.pgbMain.TabIndex = 0;
            // 
            // lbPg
            // 
            this.lbPg.AutoSize = true;
            this.lbPg.Location = new System.Drawing.Point(12, 9);
            this.lbPg.Name = "lbPg";
            this.lbPg.Size = new System.Drawing.Size(23, 12);
            this.lbPg.TabIndex = 1;
            this.lbPg.Text = "0/0";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(397, 164);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInfo.Location = new System.Drawing.Point(12, 53);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(460, 105);
            this.rtbInfo.TabIndex = 4;
            this.rtbInfo.Text = "";
            // 
            // ExecuteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 199);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbPg);
            this.Controls.Add(this.pgbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 238);
            this.Name = "ExecuteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "处理中";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExecuteForm_FormClosing);
            this.Load += new System.EventHandler(this.ExecuteForm_Load);
            this.Shown += new System.EventHandler(this.ExecuteForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbMain;
        private System.Windows.Forms.Label lbPg;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox rtbInfo;
    }
}