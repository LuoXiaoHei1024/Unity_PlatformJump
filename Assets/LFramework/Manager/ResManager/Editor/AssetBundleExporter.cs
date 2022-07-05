/*****************************************************
    文件：AssetBundleExporter.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:15
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LFramework.Manager
{
    public class AssetBundleExpoter 
    {
        [MenuItem("LFramework/ResManager/Build AssetBundles", false)]
        static void BuildAssetBundles()
        {
            var outputPath = Application.streamingAssetsPath + "/AssetBundles/" + ResKitUtil.GetPlatformName();

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression,
                EditorUserBuildSettings.activeBuildTarget);

            AssetDatabase.Refresh();
        }
    }
}
