/*****************************************************
    文件：ScriptHeaderInfoTest.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/2 22:14
    功能：添加脚本头部信息，配合 81-C# Script-NewBehaviourScript.cs.txt 使用
*****************************************************/

using System;
using System.IO;

namespace LFramework.Editor
{
    public class ScriptHeaderInfo : UnityEditor.AssetModificationProcessor
    {
        private static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");
            if (path.EndsWith(".cs"))
            {
                string str = File.ReadAllText(path);

                str = str.Replace("#UserName#", "LuoXiaoHei")
                    .Replace("#Email#", "2906809995@qq.com")
                    .Replace(
                        "#CreateTime#", string.Concat(DateTime.Now.Year, "/", DateTime.Now.Month, "/",
                            DateTime.Now.Day, " ", DateTime.Now.Hour, ":", DateTime.Now.Minute));
                File.WriteAllText(path, str);
            }
        }
    }
}
