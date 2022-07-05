/*****************************************************
    文件：MonoSingleton.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/2 22:50
    功能：MonoBehaviour 单例模板
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Util
{
    /// <summary>
    /// MonoBehaviour 单例模板 Awake里赋值
    /// </summary>
    /// <typeparam name="T">单例名称</typeparam>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T mInstance = null;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarning("More than 1");
                        return mInstance;
                    }

                    if (mInstance == null)
                    {
                        var instanceName = typeof(T).Name;
                        Debug.LogFormat("Instance Name: {0}", instanceName);
                        var instanceObj = GameObject.Find(instanceName);

                        if (!instanceObj)
                            instanceObj = new GameObject(instanceName);

                        mInstance = instanceObj.AddComponent<T>();
                        DontDestroyOnLoad(instanceObj); //保证实例不会被释放

                        Debug.LogFormat("Add New Singleton {0} in Game!", instanceName);
                    }
                    else
                    {
                        Debug.LogFormat("Already exist: {0}", mInstance.name);
                    }
                }

                return mInstance;
            }
        }

        protected virtual void OnDestroy()
        {
            mInstance = null;
        }
    }
}
