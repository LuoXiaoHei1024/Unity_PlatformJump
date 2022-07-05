/*****************************************************
    文件：ChooseLevelPanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 22:28
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelPanel : BasePanel
{
    public Button[] btnLevel;
    
    private int _finishLevel;
    
    public override void InitPanel()
    {
        base.InitPanel();
        _finishLevel = SaveManager.Instance.curArchive.finishLevel;
    }

    public override void UpdatePanel()
    {
        base.UpdatePanel();
        for (int i = 0; i < btnLevel.Length; i++)
        {
            if (i <= _finishLevel)
            {
                btnLevel[i].gameObject.SetActive(true);
            }
            else
            {
                btnLevel[i].gameObject.SetActive(false);
            }
        }
    }

    public override void EnterPanel()
    {
        base.EnterPanel();
        gameObject.SetActive(true);
    }

    public override void ExitPanel()
    {
        base.ExitPanel();
        gameObject.SetActive(false);
    }

    public void BtnLevel(int x)
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        switch (x)
        {
            case 1:
                // 设置当前应该加载场景的名字
                SaveManager.Instance.curArchive.level = 1;
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game01Scene);
                MySceneManager.Instance.ChangeScene(new Game01Scene());
                break;
            case 2:
                // 设置当前应该加载场景的名字
                SaveManager.Instance.curArchive.level = 2;
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game02Scene);
                MySceneManager.Instance.ChangeScene(new Game02Scene());
                break;
            case 3:
                // 设置当前应该加载场景的名字
                SaveManager.Instance.curArchive.level = 3;
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game03Scene);
                MySceneManager.Instance.ChangeScene(new Game03Scene());
                break;
            case 4:
                // 设置当前应该加载场景的名字
                SaveManager.Instance.curArchive.level = 4;
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game04Scene);
                MySceneManager.Instance.ChangeScene(new Game04Scene());
                break;
        }
        
        UIManager.Instance.ClosePanel("ChooseLevelPanel");
    }

    public void BtnExit()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("ChooseLevelPanel");
        UIManager.Instance.OpenPanel("GameMenuPanel");
    }
}
