/*****************************************************
    文件：BasePanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 15:10
    功能：UI面板基类
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// UI面板基类
    /// </summary>
    public class BasePanel : MonoBehaviour, IBasePanel
    {
        /// <summary>
        /// 初始化UI面板,数据赋值
        /// </summary>
        public virtual void InitPanel()
        {
            
        }

        /// <summary>
        /// 进入UI面板，进入方式
        /// </summary>
        public virtual void EnterPanel()
        {
            
        }

        /// <summary>
        /// 更新UI面板，每次打开更新
        /// </summary>
        public virtual void UpdatePanel()
        {
            
        }

        /// <summary>
        /// 退出UI面板
        /// </summary>
        public virtual void ExitPanel()
        {
            
        }
    }
}
