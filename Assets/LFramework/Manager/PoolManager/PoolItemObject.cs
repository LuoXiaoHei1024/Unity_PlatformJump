/*****************************************************
    文件：PoolItemObject.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/19 21:56
    功能：对象池组中的对象
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// 对象池组中的对象
    /// </summary>
    public class PoolItemObject
    {
        /// <summary>
        /// 游戏对象
        /// </summary>
        public readonly GameObject GameObject;

        /// <summary>
        /// 隐藏时间
        /// </summary>
        private float _hideTime;

        /// <summary>
        /// 对象的状态（是否激活）
        /// </summary>
        public bool IsActive;

        public PoolItemObject(GameObject gameObject)
        {
            GameObject = gameObject;
            IsActive = true;
        }

        /// <summary>
        /// 激活对象，将对象显示
        /// </summary>
        /// <returns>返回对象</returns>
        public GameObject Active()
        {
            GameObject.SetActive(true);
            IsActive = true;
            _hideTime = 0;
            return GameObject;
        }

        /// <summary>
        /// 隐藏对象，不是销毁
        /// </summary>
        public void Hide()
        {
            GameObject.SetActive(false);
            IsActive = false;
            _hideTime = Time.time;
        }

        public bool IsBeyondHideTime()
        {
            if (IsActive)
            {
                return false;
            }

            if (Time.time - this._hideTime >= PoolManager.Instance.hide_Time)
            {
                // Debug.Log("已超时！！！");
                return true;
            }

            return false;
        }
    }
}
