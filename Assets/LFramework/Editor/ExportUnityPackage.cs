/*****************************************************
    文件：ExportUnityPackage.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/7/30 14:10
    功能：导出 LFramework 包
*****************************************************/

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LFramework.Editor
{
    /// <summary>
    /// 导出 LFramework 包
    /// </summary>
    public class ExportUnityPackage
    {
        [MenuItem("LFramework/ExportUnityPackage %e", false, 1)]
        public static void MenuClick()
        {
            ExportPackage("Assets/LFramework");
        }
        
        private static void ExportPackage(string menuPath)
        {
            var assetPathName = menuPath;
            // 自动生成文件名
            var fileName = "LFramework_" + DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";
            // 导出 UnityPackage
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
            // 打开示例文件夹
            Application.OpenURL("file:///" + Path.Combine(Application.dataPath, "../"));
        }
    }
}