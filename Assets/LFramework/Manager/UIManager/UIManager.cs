/*****************************************************
    文件：UIManager.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 15:17
    功能：UI管理者
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;

namespace LFramework.Manager
{
    /// <summary>
    /// UI管理者
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        private Transform _canvasTransform; // 画布
        private Dictionary<string, BasePanel> _panelDict = new Dictionary<string, BasePanel>();
        private ResLoader _resLoader = new ResLoader();

        private UIManager()
        {
            _canvasTransform = GameObject.Find("Canvas").transform;
        }
        
        /// <summary>
        /// 打开一个UI面板
        /// </summary>
        /// <param name="panelName">UI面板名称</param>
        public void OpenPanel(string panelName)
        {
            if (!_panelDict.ContainsKey(panelName))
            {
                InstantiatePanel(panelName);
            }
            _panelDict[panelName].UpdatePanel();
            _panelDict[panelName].EnterPanel();
        }

        /// <summary>
        /// 关闭一个UI面板
        /// </summary>
        /// <param name="panelName">UI面板名称</param>
        public void ClosePanel(string panelName)
        {
            if (!_panelDict.ContainsKey(panelName))
            {
                return;
            }
            _panelDict[panelName].ExitPanel();
        }

        /// <summary>
        /// 实例化UI面板
        /// </summary>
        /// <param name="panelName">UI面板名称</param>
        private void InstantiatePanel(string panelName)
        {
            GameObject itemGo;
            itemGo = Object.Instantiate(
                _resLoader.LoadSync<GameObject>("uipanel", panelName),
                _canvasTransform,
                true
            );
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.transform.localScale = Vector3.one;
            BasePanel basePanel = itemGo.GetComponent<BasePanel>();
            if (basePanel == null)
            {
                Debug.Log("获取面板上BasePanel脚本失败");
            }
            basePanel.InitPanel();
            _panelDict.Add(panelName, basePanel);
            
            // itemGo = ResManager.Instance.GetResource<GameObject>(ResType.UIPanel, panelName, panelName);
            // _resLoader.LoadAsync<GameObject>("uipanel",panelName,
            //     go =>
            //     {
            //         itemGo = Object.Instantiate(go, _canvasTransform, true);
            //         itemGo.transform.localPosition = Vector3.zero;
            //         itemGo.transform.localScale = Vector3.one;
            //         BasePanel basePanel = itemGo.GetComponent<BasePanel>();
            //         if (basePanel == null)
            //         {
            //             Debug.Log("获取面板上BasePanel脚本失败");
            //         }
            //         basePanel.InitPanel();
            //         _panelDict.Add(panelName, basePanel);
            //     });
            // itemGo = Object.Instantiate(
            //     ResManager.Instance.GetResource<GameObject>(ResType.UIPanel, panelName, panelName), 
            //     _canvasTransform, 
            //     true);
            // itemGo.transform.localPosition = Vector3.zero;
            // itemGo.transform.localScale = Vector3.one;
            // BasePanel basePanel = itemGo.GetComponent<BasePanel>();
            // if (basePanel == null)
            // {
            //     Debug.Log("获取面板上BasePanel脚本失败");
            // }
            // basePanel.InitPanel();
            // _panelDict.Add(panelName, basePanel);
        }

        public void DestroyAllPanel()
        {
            foreach (var panel in _panelDict.Values)
            {
                Object.Destroy(panel.gameObject);
            }
            _panelDict.Clear();
        }
    }
}
