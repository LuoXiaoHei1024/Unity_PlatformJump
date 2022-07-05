/*****************************************************
    文件：AdventurePanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/23 22:20
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;

public class AdventurePanel : BasePanel
{
    public Archive archive1;
    public Archive archive2;
    public Archive archive3;

    public override void InitPanel()
    {
        base.InitPanel();
    }

    public override void UpdatePanel()
    {
        base.UpdatePanel();
        if (SaveManager.Instance.gameData1.level == 0)
        {
            archive1.HideArchive();
        }
        else
        {
            archive1.ShowArchive(SaveManager.Instance.gameData1.level,
                SaveManager.Instance.gameData1.cherry,
                SaveManager.Instance.gameData1.die);
        }
        if (SaveManager.Instance.gameData2.level == 0)
        {
            archive2.HideArchive();
        }
        else
        {
            archive2.ShowArchive(SaveManager.Instance.gameData2.level,
                SaveManager.Instance.gameData2.cherry,
                SaveManager.Instance.gameData2.die);
        }
        if (SaveManager.Instance.gameData3.level == 0)
        {
            archive3.HideArchive();
        }
        else
        {
            archive3.ShowArchive(SaveManager.Instance.gameData3.level,
                SaveManager.Instance.gameData3.cherry,
                SaveManager.Instance.gameData3.die);
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

    public void BtnExit()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("AdventurePanel");
        UIManager.Instance.OpenPanel("MenuPanel");
    }
}
