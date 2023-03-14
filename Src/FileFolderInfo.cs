using RenameTools.Src.Config;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RenameTools.Src
{
    public class FileFolderInfo
    {
        /// <summary>
        /// 是否已经重命名
        /// </summary>
        public bool IsRename;
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// 是否为文件
        /// </summary>
        public bool IsFile { get; private set; }
        /// <summary>
        /// 是否为文件夹
        /// </summary>
        public bool IsDir { get; private set; }
        /// <summary>
        /// 原始路径
        /// </summary>
        public string RawPath { get; private set; }
        /// <summary>
        /// 新路径
        /// </summary>
         public string NewPath { get; private set; }
        /// <summary>
        /// 原始名字
        /// </summary>
        public string RawName { get; private set; }
        /// <summary>
        /// 新名字
        /// </summary>
        public string NewName { get; private set; }
        /// <summary>
        /// 原始路径+名字
        /// </summary>
        public string RawPathName { get; private set; }
        /// <summary>
        /// 新路径+名字
        /// </summary>
        public string NewPathName { get; private set; }
        /// <summary>
        /// 报错信息
        /// </summary>
        public string Info { get; private set; }
        /// <summary>
        /// 配置
        /// </summary>
        public NameConfig Config { get; private set; }

        public FileFolderInfo(MainForm form, string rawPathName, int index)
        {
            IsRename = false;
            RawPathName = rawPathName;
            Index = index;
            form.NameRuleChangeEvent += Form_NameRuleChangeEvent;

            if (File.Exists(rawPathName))
            {
                IsFile = true;
                IsDir = false;
            }
            else if (Directory.Exists(rawPathName))
            {
                IsFile = false;
                IsDir = true;
            }
        }

        private void Form_NameRuleChangeEvent(NameConfig config)
        {
            //Console.WriteLine("Mode : " + config.mode);
            //GetNewName(config);
        }

        public void SetIndex(int index)
        {
            Index = index;
            GetNewName(Config);
        }

        public string GetNewName(NameConfig config)
        {
            Config = config;
            Info = null;

            string oldPrefix;
            string oldSuffix;
            {
                // 找文件名
                // int lastBackslashIndex = oldPath.LastIndexOf('\\');
                int lastBackslashIndex = RawPathName.LastIndexOf('\\');
                if (lastBackslashIndex != -1)
                {
                    RawName = RawPathName.Substring(lastBackslashIndex + 1, RawPathName.Length - lastBackslashIndex - 1);
#if DEBUG
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("RawName:" + RawName);
                    }
#endif
                }

                // 找出前缀、后缀
                int lastPrefixIndex = RawName.LastIndexOf('.');
                if (lastPrefixIndex != -1)
                {
                    oldSuffix = RawName.Substring(lastPrefixIndex + 1, RawName.Length - lastPrefixIndex - 1);
                    oldPrefix = RawName.Substring(0, lastPrefixIndex);
                }
                else
                {
                    oldPrefix = RawName;
                    oldSuffix = "";
                }
#if DEUBG
                if (MainForm.Debug)
                {
                    Console.WriteLine("oldSuffix:" + oldSuffix);
                    Console.WriteLine("oldPrefix:" + oldPrefix);
                }
#endif

            }

            if (RawName == null || oldPrefix == null || oldSuffix == null)
            {
                Info = "出错：无法解析路径";
                return Info;
            }

            string newName = RawName;

            // 批量命名
            // if (rbNumberName.Checked)
#if DEBUG
            Console.WriteLine(config.mode);
#endif
            if (config.mode == RenameMode.TextNumber)
            {
                // *** + 数字
                string customString = config.p1;
                string startNumber = config.p2;
                int sn;

                if (int.TryParse(startNumber, out sn))
                {
                    int n = sn + Index;
                    string nStr = n.ToString();
                    if (startNumber.Length > nStr.Length)
                    {
                        string temp = "";
                        for (int i = 0; i < startNumber.Length - nStr.Length; i++)
                        {
                            temp += "0";
                        }
                        nStr = temp + nStr;
                    }
                    newName = customString + nStr;
                }
                else
                {
                    Info = "出错：起始值格式不对";
                    return Info;
                }
            }
            // else if (rbNewNameNumberLeft.Checked)
            else if (config.mode == RenameMode.NumberText)
            {
                // 数字 + ***
                string customString = config.p1;
                string startNumber = config.p2;

                int sn;

                if (int.TryParse(startNumber, out sn))
                {
                    int n = sn + Index;
                    string nStr = n.ToString();
                    if (startNumber.Length > nStr.Length)
                    {
                        string temp = "";
                        for (int i = 0; i < startNumber.Length - nStr.Length; i++)
                        {
                            temp += "0";
                        }
                        nStr = temp + nStr;
                    }
                    newName = nStr + customString;
                }
                else
                {
                    Info = "出错：起始值格式不对";
                    return Info;
                }
            }
            // else if (rbRawName.Checked)
            else if (config.mode == RenameMode.TextName)
            {
                // *** + 原名
                string customString = config.p1;
                newName = customString + oldPrefix;
            }
            // else if (rbNewNameRawLeft.Checked)
            else if (config.mode == RenameMode.NameText)
            {
                // 原名 + ***
                string customString = config.p1;
                newName = oldPrefix + customString;
            }

            // 后缀名
            string suffixInput = config.extend;
            if (suffixInput != null && !suffixInput.Equals(""))
            {
                if (!suffixInput.Equals(""))
                {
                    newName += "." + suffixInput;
                }
            }
            else
            {
                if (!oldSuffix.Equals(""))
                {
                    newName += "." + oldSuffix;
                }
            }


            // 替换
            string fixInput = config.findText;
            if (fixInput != null && !fixInput.Equals(""))
            {
#if DEUBG
                if (MainForm.Debug)
                {
                    Console.WriteLine("替换名字：" + newName);
                }
#endif
                string fixNewString = config.targetText;
                if (fixNewString == null)
                {
#if DEUBG
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("替换为为空");
                    }
#endif
                    fixNewString = "";
                }


                // if (cbCaseFalse.Checked)
                if (config.caseTrue)
                {
                    // 不区分大小写，不使用正则
                    string lowKey = fixInput.ToLower();
#if DEUBG
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("lowKey:" + lowKey);
                    }
#endif

                    while (true)
                    {
                        string lowName = newName.ToLower();
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("lowName:" + lowName);
                        }
#endif
                        int indexLowKey = lowName.IndexOf(lowKey);
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("indexLowKey:" + indexLowKey);
                        }
#endif
                        if (indexLowKey < 0)
                        {
                            break;
                        }

                        int ps = 0;
                        int pl = indexLowKey;
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("newName.Substring(" + ps + ", " + pl + ")");
                        }
#endif
                        string preStr = newName.Substring(ps, pl);
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("preStr: " + preStr);
                        }
#endif

                        int ls = indexLowKey + fixInput.Length;
                        int ll = newName.Length - fixInput.Length - indexLowKey;
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("newName.Substring(" + ls + ", " + ll + ")");
                        }
#endif
                        string lastStr = newName.Substring(ls, ll);
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("lastStr: " + lastStr);
                        }
#endif

                        newName = preStr + fixNewString + lastStr;
#if DEUBG
                        if (MainForm.Debug)
                        {
                            Console.WriteLine("preStr + fixInput + lastStr -> " + preStr + "+" + fixInput + "+" + lastStr);

                            Console.WriteLine(newName);
                        }
#endif
                    }
#if DEUBG
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("不区分大小写替换：" + newName);
                    }
#endif
                }
                // else if (cbRegularTrue.Checked)
                else if (config.regularTrue)
                {
                    // 使用正则，区分大小写
                    try
                    {
                        newName = Regex.Replace(newName, fixInput, fixNewString);
                    }catch(Exception e)
                    {
                        Console.WriteLine("正则有误：" + e.Message);
                        newName = "正则有误";
                    }
#if DEUBG
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("正则替换：" + newName);
                    }
#endif
                }
                else
                {
                    // 区分大小写，不使用正则
                    newName = newName.Replace(fixInput, fixNewString);
#if DEUBG
                    if (MainForm.Debug)
                    {
                        Console.WriteLine("普通替换：" + newName);
                    }
#endif
                }

            }

            // string oldFilePath = oldPath.Replace(oldName, "");
            RawPath = RawPathName.Replace(RawName, "");
            NewName = newName;
            NewPath = RawPath;
            NewPathName = RawPath + newName;
            if (NewName != null)
            {
                return NewName;
            }
            else
            {
                return Info;
            }
        }

        public override string ToString()
        {
            return ToString(false, false);
        }

        public string ToString(bool isNew = false, bool isName = false)
        {
            if (isName == true)
            {
                if (isNew)
                {
                    return NewName;
                }
                else
                {
                    return RawName;
                }
            }
            else
            {
                if (isNew)
                {
                    return NewPathName;
                }
                else
                {
                    return RawPathName;
                }
            }
        }
    }
}
