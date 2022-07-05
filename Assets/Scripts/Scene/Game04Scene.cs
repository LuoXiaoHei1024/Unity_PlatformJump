/*****************************************************
    文件：Game04Scene.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 21:45
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game04Scene : BaseScene
{
    public override void EnterScene()
    {
        base.EnterScene();
        AudioManager.Instance.PlayBgmAudio("BGM_04", "sounds", true);
    }

    public override void ExitScene()
    {
        base.ExitScene();
        // 加载过度场景
        SceneManager.LoadScene(SceneName.LoadGameScene);
    }
}
