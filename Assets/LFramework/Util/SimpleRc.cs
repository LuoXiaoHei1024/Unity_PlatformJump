/*****************************************************
    文件：SimpleRC.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/16 16:41
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Util
{
    public interface IRefCounter
    {
        int RefCount { get; }

        void Retain(object refOwner = null);

        void Release(object refOwner = null);
    }

    public class SimpleRc : IRefCounter
    {
        public int RefCount { get; private set; }

        public void Retain(object refOwner = null)
        {
            RefCount++;
        }

        public void Release(object refOwner = null)
        {
            RefCount--;

            if (RefCount == 0)
            {
                OnZeroRef();
            }
        }

        protected virtual void OnZeroRef()
        {

        }
    }
    
}
