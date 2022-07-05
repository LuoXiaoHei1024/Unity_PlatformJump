/*****************************************************
    文件：Res.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:16
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using Object = UnityEngine.Object;

namespace LFramework.Manager
{
    public enum ResState
    {
        Waiting,
        Loading,
        Loaded,
    }
    
    public abstract class Res : SimpleRc
    {
        public ResState State
        {
            get { return mState;}
            protected set
            {
                mState = value;

                if (mState == ResState.Loaded)
                {
                    if (mOnLoadedEvent != null)
                    {
                        mOnLoadedEvent.Invoke(this);
                    }
                }
            } 
        }

        private ResState mState;
        
        public Object Asset { get; protected set; }

        public string Name { get; protected set; }

        private string mAssetPath;

        public abstract bool LoadSync();

        public abstract void LoadAsync();

        protected abstract void OnReleaseRes();

        protected override void OnZeroRef()
        {
            OnReleaseRes();
        }


        private event Action<Res> mOnLoadedEvent;

        public void RegisterOnLoadedEvent(Action<Res> onLoaded)
        {
            mOnLoadedEvent += onLoaded;
        }

        public void UnRegisterOnLoadedEvent(Action<Res> onLoaded)
        {
            mOnLoadedEvent -= onLoaded;
        }
    }
}
