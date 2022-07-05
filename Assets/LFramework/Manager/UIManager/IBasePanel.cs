/*****************************************************
    文件：IBasePanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 15:10
    功能：UI基类接口
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// UI基类接口
    /// </summary>
    public interface IBasePanel
    {
        /// <summary>
        /// 初始化UI面板
        /// </summary>
        void InitPanel();
        
        /// <summary>
        /// 进入UI面板
        /// </summary>
        void EnterPanel();

        /// <summary>
        /// 更新UI面板
        /// </summary>
        void UpdatePanel();

        /// <summary>
        /// 退出UI面板
        /// </summary>
        void ExitPanel();
    }
}
