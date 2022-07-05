/*****************************************************
    文件：PoolItem.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/15 11:28
    功能：对象池 组
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// 对象池 组
    /// </summary>
    public class PoolItem
    {
        /// <summary>
        /// 对象名称，作为标识
        /// </summary>
        private string _name;

        /// <summary>
        /// 对象字典，存储同一名称的所有对象
        /// </summary>
        private readonly Dictionary<int, PoolItemObject> _itemObjectDict;

        public PoolItem(string name)
        {
            this._name = name;
            this._itemObjectDict = new Dictionary<int, PoolItemObject>();
        }

        /// <summary>
        /// 添加对象，往同一对象池组里添加对象
        /// </summary>
        /// <param name="gameObject">要添加的对象</param>
        public void AddObject(GameObject gameObject)
        {
            var hashKey = gameObject.GetHashCode();
            if (!_itemObjectDict.ContainsKey(hashKey))
            {
                _itemObjectDict.Add(hashKey,new PoolItemObject(gameObject));
            }
            else
            {
                _itemObjectDict[hashKey].Active();
            }
        }

        /// <summary>
        /// 隐藏对象，不是销毁
        /// </summary>
        /// <param name="gameObject">要隐藏的对象</param>
        public void HideObject(GameObject gameObject)
        {
            var hashKey = gameObject.GetHashCode();
            if (_itemObjectDict.ContainsKey(hashKey))
            {
                _itemObjectDict[hashKey].Hide();
            }
        }

        /// <summary>
        /// 获取字典里第一个没有激活的对象
        /// </summary>
        /// <returns>对象</returns>
        public GameObject GetObject()
        {
            if (_itemObjectDict == null || _itemObjectDict.Count == 0)
            {
                return null;
            }

            foreach (var poolItemObject in _itemObjectDict.Values)
            {
                if (!poolItemObject.IsActive)
                {
                    return poolItemObject.Active();
                }
            }

            return null;
        }

        /// <summary>
        /// 移除并销毁单个对象
        /// </summary>
        /// <param name="gameObject">要销毁的对象</param>
        public void DestroyObject(GameObject gameObject)
        {
            var hashKey = gameObject.GetHashCode();
            if (_itemObjectDict.ContainsKey(hashKey))
            {
                Object.Destroy(gameObject);
                _itemObjectDict.Remove(hashKey);
            }
        }

        /// <summary>
        /// 销毁同一的所有对象
        /// </summary>
        public void Destroy()
        {
            foreach (var poolItemObject in _itemObjectDict.Values)
            {
                Object.Destroy(poolItemObject.GameObject);
            }
            _itemObjectDict.Clear();
        }

        /// <summary>
        /// 销毁超时的对象
        /// </summary>
        public void DestroyBeyondHideTimeObject()
        {
            foreach (var poolItemObject in _itemObjectDict.Values)
            {
                if (poolItemObject.IsBeyondHideTime())
                {
                    DestroyObject(poolItemObject.GameObject);
                }
            }
        }
    }
}
