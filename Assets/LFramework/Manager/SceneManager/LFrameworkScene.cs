/*****************************************************
    文件：LFrameworkScene.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 15:59
    功能：LFramework 场景
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LFramework.Manager
{
    /// <summary>
    /// LFramework 场景
    /// </summary>
    public class LFrameworkScene : BaseScene
    {
        public override void EnterScene()
        {
            base.EnterScene();
        }

        public override void ExitScene()
        {
            SceneManager.LoadScene(SceneName.LoadGameScene);
        }
    }
}
