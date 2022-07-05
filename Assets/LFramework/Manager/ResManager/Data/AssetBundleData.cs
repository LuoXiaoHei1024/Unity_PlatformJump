/*****************************************************
    文件：AssetBundleData.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:14
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    public class AssetBundleData
    {
        public string Name;
		
        public List<AssetData> AssetDataList = new List<AssetData>();

        public string[] DependencyBundleNames;
    }
}
