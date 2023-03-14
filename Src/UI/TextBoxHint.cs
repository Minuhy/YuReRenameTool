#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：MINC3480
 * 公司名称：
 * 命名空间：RenameTools.Src.UI
 * 唯一标识：148e9807-459d-4468-83a3-2387400b9043
 * 文件名：TextBoxHint
 * 当前用户域：MINC3480
 * 
 * 创建者：Minuy
 * 电子邮箱：minuy17@163.com
 * 创建时间：2022/11/18 15:58:06
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace RenameTools.Src.UI
{
    /// <summary>
    /// TextBoxHint 的摘要说明
    /// </summary>
    public class TextBoxHint: System.Windows.Forms.TextBox
    {
        #region <常量>
        #endregion <常量>

        #region <变量>
        public bool IsHint { get; private set; }
        private string hint = "";
        private bool isMeSet = false;
        private int foreColorBackup;
        public Color HintColor = Color.Gray;
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        public string Hint
        {
            get
            {
                return hint;
            }
            set
            {
                hint = value;
#if DEBUG
                Console.WriteLine("正在设置暗示：" + value);
#endif
                TextBoxHint_Leave(this, new HintEventArgs(value));
            }
        }
#endregion <变量>

#region <属性>
#endregion <属性>

#region <构造方法和析构方法>
        public TextBoxHint()
        {
            IsHint = true;
            Enter += TextBoxHint_Enter;
            Leave += TextBoxHint_Leave;
            ForeColorChanged += TextBoxHint_ForeColorChanged;
            TextChanged += TextBoxHint_TextChanged;
            Click += TextBoxHint_Enter;
            MouseCaptureChanged += TextBoxHint_Enter;
            foreColorBackup = ForeColor.ToArgb();
        }

        private void TextBoxHint_TextChanged(object sender, EventArgs e)
        {
            if (isMeSet)
            {
#if DEBUG
                Console.WriteLine("Me");
#endif
                isMeSet = false;
                return;
            }

            if(Text!=null && !Text.Equals("") && !Text.Equals(hint))
            {
                // 如果文本不为空，则显示文本
                IsHint = false;
            }
            else
            {
                // 如果文本为空，则显示暗示
                IsHint = true;
            }
        }

        private void TextBoxHint_ForeColorChanged(object sender, EventArgs e)
        {
            // 备份前景色
            if (!ForeColor.Equals(HintColor))
            {
                foreColorBackup = ForeColor.ToArgb();
            }
        }

        private void TextBoxHint_Leave(object sender, EventArgs e)
        {
#if DEBUG
            Console.WriteLine("失去焦距");
#endif
            // 不再是活动窗体的时候
            if (IsHint && Focused==false)
            {
                isMeSet = true;
                if (e is HintEventArgs hea)
                {
                    Text = hea.Hint;
#if DEBUG
                    Console.WriteLine("已设置暗示:" + hea.Hint);
#endif
                }
                else
                {
                    Text = hint;
#if DEBUG
                    Console.WriteLine("已设置暗示" + hint);
#endif
                }
                ForeColor = HintColor;
            }
            else
            {
#if DEBUG
                Console.WriteLine("活跃窗口，没必要设置");
#endif
            }
        }

        private void TextBoxHint_Enter(object sender, EventArgs e)
        {
            // 是活动窗体的时候
            if (IsHint)
            {
#if DEBUG
                Console.WriteLine("盗我了");
#endif
                Text = "";
                ForeColor = Color.FromArgb(foreColorBackup);
            }
        }
#endregion <构造方法和析构方法>

#region <方法>
#endregion <方法>

#region <事件>
#endregion <事件>
    }

    class HintEventArgs: EventArgs
    {
        public string Hint { get; private set; }
        public HintEventArgs(string hint)
        {
            Hint = hint;
        }
    }
}