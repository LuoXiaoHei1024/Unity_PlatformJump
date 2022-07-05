/*****************************************************
    文件：Singleton.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/2 22:42
    功能：普通单例模板
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LFramework.Util
{
    /// <summary>
    /// 普通单例模板
    /// </summary>
    /// <typeparam name="T">单例名称</typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);

                    if (ctor == null)
                        throw new Exception("Non-public ctor() not found!");

                    mInstance = ctor.Invoke(null) as T;
                }

                return mInstance;
            }
        }

        protected Singleton()
        {

        }
    }
}
