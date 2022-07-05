/*****************************************************
    文件：SimulationModeMenu.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:16
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LFramework.Manager
{
    public class SimulationModeMenu
    {
        private const string kSimulationModeKey  = "simulation mode";
        private const string kSimulationModePath = "LFramework/ResManager/Simulation Mode";

        [MenuItem(kSimulationModePath)]
        private static void ToggleSimulationMode()
        {
            ResMgr.SimulationMode = !ResMgr.SimulationMode;
        }		
	
        [MenuItem(kSimulationModePath, true)]
        public static bool ToggleSimulationModeValidate ()
        {
            Menu.SetChecked(kSimulationModePath, ResMgr.SimulationMode);
            return true;
        }
    }
}
