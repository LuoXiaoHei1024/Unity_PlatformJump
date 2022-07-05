/*****************************************************
    文件：MenuPanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/23 22:20
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;

public class MenuPanel : BasePanel
{
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

    public void BtnAdventure()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("MenuPanel");
        UIManager.Instance.OpenPanel("AdventurePanel");
    }

    public void BtnOption()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("MenuPanel");
        UIManager.Instance.OpenPanel("OptionPanel");
    }

    public void BtnAchievement()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("MenuPanel");
        UIManager.Instance.OpenPanel("AchievementPanel");
    }
    
    public void BtnExitGame()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
