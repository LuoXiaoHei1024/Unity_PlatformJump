/*****************************************************
    文件：IBaseScene.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/15 10:37
    功能：场景接口
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// 场景接口
    /// </summary>
    public interface IBaseScene
    {
        /// <summary>
        /// 进入场景
        /// </summary>
        void EnterScene();

        /// <summary>
        /// 退出场景
        /// </summary>
        void ExitScene();
    }
}
