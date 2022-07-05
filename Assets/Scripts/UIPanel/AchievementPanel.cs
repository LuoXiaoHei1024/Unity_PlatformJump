/*****************************************************
    文件：AchievementPanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 21:27
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;

public class AchievementPanel : BasePanel
{
    public Achievement newble;
    public Achievement skilled;
    public Achievement veteran;
    public Achievement expert;
    public Achievement startAdventure;
    public Achievement thankPartGame;
    public Achievement cherryEmblem;
    public Achievement cherryMedal;

    private int maxLevel;
    private int maxFinishLevel;
    private int maxCherry;
    
    public override void InitPanel()
    {
        base.InitPanel();
        
    }

    public override void UpdatePanel()
    {
        base.UpdatePanel();
        LoadData();
        newble.ShowOrHideAchievement(SaveManager.Instance.achievementData.newble);
        skilled.ShowOrHideAchievement(SaveManager.Instance.achievementData.skilled);
        veteran.ShowOrHideAchievement(SaveManager.Instance.achievementData.veteran);
        expert.ShowOrHideAchievement(SaveManager.Instance.achievementData.expert);
        startAdventure.ShowOrHideAchievement(SaveManager.Instance.achievementData.startAdventure);
        thankPartGame.ShowOrHideAchievement(SaveManager.Instance.achievementData.thankPartGame);
        cherryEmblem.ShowOrHideAchievement(SaveManager.Instance.achievementData.cherryEmblem);
        cherryMedal.ShowOrHideAchievement(SaveManager.Instance.achievementData.cherryMedal);
    }

    public override void EnterPanel()
    {
        base.EnterPanel();
        gameObject.SetActive(true);
    }

    public override void ExitPanel()
    {
        base.ExitPanel();
        SaveManager.Instance.SaveByAchievementData();
        gameObject.SetActive(false);
    }
    
    public void BtnExit()
    {
        UIManager.Instance.ClosePanel("AchievementPanel");
        UIManager.Instance.OpenPanel("MenuPanel");
    }

    private void LoadData()
    {
        maxLevel = GetMaxNumber(
            SaveManager.Instance.gameData1.level,
            SaveManager.Instance.gameData2.level,
            SaveManager.Instance.gameData3.level
        );
        maxFinishLevel = GetMaxNumber(
            SaveManager.Instance.gameData1.finishLevel,
            SaveManager.Instance.gameData2.finishLevel,
            SaveManager.Instance.gameData3.finishLevel
        );
        maxCherry = GetMaxNumber(
            SaveManager.Instance.gameData1.cherry,
            SaveManager.Instance.gameData2.cherry,
            SaveManager.Instance.gameData3.cherry
        );
        
        JudgeLevel();
        JudgeFinishLevel();
        JudgeCherry();
    }

    private int GetMaxNumber(int x,int y,int z)
    {
        int max = x > y ? x : y;
        max = max > z ? max : z;
        return max;
    }

    private void JudgeLevel()
    {
        if (maxLevel == 0)
        {
            SaveManager.Instance.achievementData.startAdventure = false;
        }
        else
        {
            SaveManager.Instance.achievementData.startAdventure = true;
        }
    }
    
    private void JudgeFinishLevel()
    {
        switch (maxFinishLevel)
        {
            case 0:
                SaveManager.Instance.achievementData.newble = false;
                SaveManager.Instance.achievementData.skilled = false;
                SaveManager.Instance.achievementData.veteran = false;
                SaveManager.Instance.achievementData.expert = false;
                SaveManager.Instance.achievementData.thankPartGame = false;
                break;
            case 1:
                SaveManager.Instance.achievementData.newble = true;
                SaveManager.Instance.achievementData.skilled = false;
                SaveManager.Instance.achievementData.veteran = false;
                SaveManager.Instance.achievementData.expert = false;
                SaveManager.Instance.achievementData.thankPartGame = false;
                break;
            case 2:
                SaveManager.Instance.achievementData.newble = true;
                SaveManager.Instance.achievementData.skilled = true;
                SaveManager.Instance.achievementData.veteran = false;
                SaveManager.Instance.achievementData.expert = false;
                SaveManager.Instance.achievementData.thankPartGame = false;
                break;
            case 3:
                SaveManager.Instance.achievementData.newble = true;
                SaveManager.Instance.achievementData.skilled = true;
                SaveManager.Instance.achievementData.veteran = true;
                SaveManager.Instance.achievementData.expert = false;
                SaveManager.Instance.achievementData.thankPartGame = false;
                break;
            case 4:
                SaveManager.Instance.achievementData.newble = true;
                SaveManager.Instance.achievementData.skilled = true;
                SaveManager.Instance.achievementData.veteran = true;
                SaveManager.Instance.achievementData.expert = true;
                SaveManager.Instance.achievementData.thankPartGame = true;
                break;
        }
    }

    private void JudgeCherry()
    {
        if (maxCherry > 8)
        {
            SaveManager.Instance.achievementData.cherryEmblem = true;
        }
        else
        {
            SaveManager.Instance.achievementData.cherryEmblem = false;
        }
    
        if (maxCherry == 16)
        {
            SaveManager.Instance.achievementData.cherryMedal = true;
        }
        else
        {
            SaveManager.Instance.achievementData.cherryMedal = false;
        }
    }
}
