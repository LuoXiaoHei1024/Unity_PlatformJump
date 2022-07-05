/*****************************************************
    文件：PoolManager.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/15 11:28
    功能：对象池管理
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// 对象池管理
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        public int hide_Time = 1 * 60;

        /// <summary>
        /// 对象池
        /// </summary>
        private Dictionary<string, PoolItem> _poolItemDict;

        private PoolManager()
        {
            Debug.Log("singleton example ctor");
        }
        
        /// <summary>
        /// 添加一个对象组
        /// </summary>
        /// <param name="name">对象组名称</param>
        public void AddPoolItem(string name)
        {
            if (_poolItemDict == null)
            {
                _poolItemDict = new Dictionary<string, PoolItem>();
            }

            if (!_poolItemDict.ContainsKey(name))
            {
                _poolItemDict.Add(name, new PoolItem(name));
            }
        }

        /// <summary>
        /// 添加一个对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="gameObject">要添加的对象</param>
        public void AddObject(string name, GameObject gameObject)
        {
            if (_poolItemDict == null || !_poolItemDict.ContainsKey(name))
            {
                AddPoolItem(name);
            }
            _poolItemDict[name].AddObject(gameObject);
        }

        /// <summary>
        /// 销毁单个对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="gameObject">要销毁的对象</param>
        public void DestroyObject(string name, GameObject gameObject)
        {
            if (_poolItemDict == null || !_poolItemDict.ContainsKey(name))
            {
                return;
            }
            _poolItemDict[name].DestroyObject(gameObject);
        }

        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <returns>获取的对象</returns>
        public GameObject GetObject(string name)
        {
            if (_poolItemDict == null || !_poolItemDict.ContainsKey(name))
            {
                return null;
            }

            return _poolItemDict[name].GetObject();
        }

        /// <summary>
        /// 隐藏单个对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="gameObject">要隐藏的对象</param>
        public void HideObject(string name, GameObject gameObject)
        {
            if (_poolItemDict == null || !_poolItemDict.ContainsKey(name))
            {
                return;
            }
            _poolItemDict[name].HideObject(gameObject);
        }

        /// <summary>
        /// 销毁对象池中的所有超时对象
        /// </summary>
        public void DestroyBeyondTimeObject()
        {
            if (_poolItemDict == null)
            {
                return;
            }

            foreach (var poolItem in _poolItemDict.Values)
            {
                poolItem.DestroyBeyondHideTimeObject();
            }
        }

        /// <summary>
        /// 销毁一个对象池组
        /// </summary>
        /// <param name="name">对象池组名称</param>
        public void DestroyPoolItem(string name)
        {
            if (_poolItemDict == null || !_poolItemDict.ContainsKey(name))
            {
                return;
            }
            _poolItemDict[name].Destroy();
        }

        /// <summary>
        /// 销毁整个对象池
        /// </summary>
        public void Destroy()
        {
            if (_poolItemDict == null)
            {
                return;
            }

            foreach (var poolItem in _poolItemDict.Values)
            {
                poolItem.Destroy();
            }

            _poolItemDict = null;
        }
    }
}
