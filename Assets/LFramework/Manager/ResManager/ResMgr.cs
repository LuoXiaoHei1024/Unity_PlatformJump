/*****************************************************
    文件：ResMgr.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:13
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;

namespace LFramework.Manager
{
    public class ResMgr : MonoSingleton<ResMgr>
    {

#if UNITY_EDITOR
        private const string kSimulationMode = "simulation mode";

        private static int mSimulationMode = -1;
        public static bool SimulationMode
        {
            get
            {
                if (mSimulationMode == -1)
                {
                    mSimulationMode = UnityEditor.EditorPrefs.GetInt(kSimulationMode, 1);
                }

                return mSimulationMode != 0;
            }
            set
            {
                mSimulationMode = value ? 1 : 0;
                UnityEditor.EditorPrefs.SetInt(kSimulationMode,mSimulationMode);
            }
        }
#endif

        /// <summary>
        /// 是否是 模拟加载 AB 包
        /// </summary>
        public static bool IsSimulationModeLogic
        {
            get
            {
#if UNITY_EDITOR
                return SimulationMode;
#endif
                return false;
            }
        }



        public List<Res> SharedLoadedReses = new List<Res>();

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (Input.GetKey(KeyCode.F1))
            {
                GUILayout.BeginVertical("box");

                SharedLoadedReses.ForEach(loadedRes =>
                {
                    GUILayout.Label(string.Format("Name:{0} RefCount:{1} State:{2}", loadedRes.Name,
                        loadedRes.RefCount, loadedRes.State));
                });

                GUILayout.EndVertical();
            }
        }
#endif
    }
}
