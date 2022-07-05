/*****************************************************
    文件：GameMenuPanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 22:19
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;

public class GameMenuPanel : BasePanel
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

    /// <summary>
    /// 继续游戏
    /// </summary>
    public void BtnContinue()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameMenuPanel");
        GameController.Instance.ContinueGame();
    }
    
    /// <summary>
    /// 重试
    /// </summary>
    public void BtnReTry()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameMenuPanel");
        GameController.Instance.RetryGame();
    }
    
    /// <summary>
    /// 重新开始
    /// </summary>
    public void BtnReStart()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameMenuPanel");
        GameController.Instance.ReStartGame();
    }
    
    /// <summary>
    /// 保存并退出
    /// </summary>
    public void BtnExit()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameMenuPanel");
        GameController.Instance.ExitGame();
    }
    
    /// <summary>
    /// 选项
    /// </summary>
    public void BtnOption()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameMenuPanel");
        UIManager.Instance.OpenPanel("GameOptionPanel");
        GameController.Instance.Option();
    }
    
    /// <summary>
    /// 选择关卡
    /// </summary>
    public void BtnChooseLevel()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameMenuPanel");
        UIManager.Instance.OpenPanel("ChooseLevelPanel");
        GameController.Instance.ChooseLevel();
    }
}
