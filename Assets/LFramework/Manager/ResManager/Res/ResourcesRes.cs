/*****************************************************
    文件：ResourcesRes.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:16
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    public class ResourcesRes : Res
    {
        private string mAssetPath;

        public ResourcesRes(string assetPath)
        {
            mAssetPath = assetPath.Substring("resources://".Length);

            Name = assetPath;

            State = ResState.Waiting;
        }

        public override bool LoadSync()
        {
            State = ResState.Loading;

            Asset = Resources.Load(mAssetPath);

            State = ResState.Loaded;

            return Asset;
        }

        public override void LoadAsync()
        {
            State = ResState.Loading;

            var resRequest = Resources.LoadAsync(mAssetPath);

            resRequest.completed += operation =>
            {
                Asset = resRequest.asset;

                State = ResState.Loaded;
            };
        }

        protected override void OnReleaseRes()
        {
            if (Asset is GameObject)
            {
                Asset = null;

                Resources.UnloadUnusedAssets();
            }
            else
            {
                Resources.UnloadAsset(Asset);
            }

            ResMgr.Instance.SharedLoadedReses.Remove(this);

            Asset = null;
        }
    }
}
