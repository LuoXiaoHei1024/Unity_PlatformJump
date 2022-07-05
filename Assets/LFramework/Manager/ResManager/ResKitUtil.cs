/*****************************************************
    文件：ResKitUtil.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:13
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    public class ResKitUtil
    {
        public static string FullPathForAssetBundle(string assetBundleName)
        {
            return Application.streamingAssetsPath + "/AssetBundles/" + GetPlatformName() + "/" + assetBundleName;
        }

        /// <summary>
        /// 获得当前平台名字
        /// </summary>
        /// <returns>平台名字</returns>
        public static string GetPlatformName()
        {

#if UNITY_EDITOR
            return GetPlatformName(UnityEditor.EditorUserBuildSettings.activeBuildTarget);
#else
            return GetPlatformName(Application.platform);
#endif
        }

#if UNITY_EDITOR
        private static string GetPlatformName(UnityEditor.BuildTarget buildTarget)
        {
            switch (buildTarget)
            {
                case UnityEditor.BuildTarget.StandaloneWindows:
                case UnityEditor.BuildTarget.StandaloneWindows64:
                    return "Windows";
                case UnityEditor.BuildTarget.iOS:
                    return "iOS";
                case UnityEditor.BuildTarget.Android:
                    return "Android";
                // case UnityEditor.BuildTarget.StandaloneLinux:
                case UnityEditor.BuildTarget.StandaloneLinux64:
                // case UnityEditor.BuildTarget.StandaloneLinuxUniversal:
                    return "Linux";
                case UnityEditor.BuildTarget.StandaloneOSX:
                    return "OSX";
                case UnityEditor.BuildTarget.WebGL:
                    return "WebGL";
                default:
                    return null;
            }
        }
#endif

        private static string GetPlatformName(RuntimePlatform runtimePlatform)
        {
            switch (runtimePlatform)
            {
                case RuntimePlatform.WebGLPlayer:
                    return "WebgGL";
                case RuntimePlatform.OSXPlayer:
                    return "OSX";
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
                case RuntimePlatform.Android:
                    return "Android";
                default:
                    return null;
            }
        }
    }
}
