/*****************************************************
    文件：ResFactory.cs
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
    public class ResFactory
    {
        public static Res Create(string assetName, string assetBundleName)
        {
            Res res = null;

            // 有AssetBundle名字，则创建 AssetRes
            // 名字和地址不一样，则创建 AssetRes
            if (assetBundleName != null)
            {
                res = new AssetRes(assetName, assetBundleName);
            }
            else if (assetName.StartsWith("resources://"))
            {
                res = new ResourcesRes(assetName);
            }
            else
            {
                res = new AssetBundleRes(assetName);
            }

            return res;
        }
    }
}
