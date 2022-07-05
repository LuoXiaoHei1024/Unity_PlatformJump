/*****************************************************
    文件：BaseScene.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/15 10:38
    功能：场景基类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// 场景基类
    /// </summary>
    public class BaseScene : IBaseScene
    {
        public BaseScene()
        {
            
        }

        /// <summary>
        /// 进入场景
        /// </summary>
        public virtual void EnterScene()
        {

        }

        /// <summary>
        /// 退出场景
        /// </summary>
        public virtual void ExitScene()
        {

        }
    }
}
