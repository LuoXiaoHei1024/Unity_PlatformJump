/*****************************************************
    文件：MenuScene.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/13 19:58
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : BaseScene
{
    
    // private ResLoader _resLoader = new ResLoader();
    
    public override void EnterScene()
    {
        base.EnterScene();
        Debug.Log("进入MenuScene");

        UIManager.Instance.OpenPanel("MenuPanel");
        AudioManager.Instance.StopBgmAudio();
    }

    public override void ExitScene()
    {
        base.ExitScene();
        
        // if (MySceneManager.Instance.GetCurrentScene().GetType() == typeof(Game01Scene))
        // {
            // 加载过度场景
            SceneManager.LoadScene(SceneName.LoadGameScene);
        // }
        // else if (MySceneManager.Instance.GetCurrentScene().GetType() == typeof(GameScene))
        // {
        //     MySceneManager.Instance.SetCurrentSceneName(SceneName.GameScene);
        //     SceneManager.LoadScene(SceneName.LoadGameScene);
        // }
    }
}
