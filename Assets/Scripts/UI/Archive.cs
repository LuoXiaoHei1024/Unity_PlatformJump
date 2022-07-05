/*****************************************************
    文件：Archive.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 20:11
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;
using UnityEngine.UI;

public class Archive : MonoBehaviour
{
    public Text txtLevel;
    public Text txtCherryNum;
    public Text txtDieNum;

    private int curLevel = 0;

    public void ShowArchive(int level, int cherry, int die)
    {
        curLevel = level;
        
        txtLevel.transform.parent.gameObject.SetActive(true);
        txtCherryNum.transform.parent.gameObject.SetActive(true);
        txtDieNum.transform.parent.gameObject.SetActive(true);

        txtLevel.text = level.ToString();
        txtCherryNum.text = cherry.ToString();
        txtDieNum.text = die.ToString();
    }

    public void HideArchive()
    {
        txtLevel.transform.parent.gameObject.SetActive(false);
        txtCherryNum.transform.parent.gameObject.SetActive(false);
        txtDieNum.transform.parent.gameObject.SetActive(false);
    }

    public void BtnStartGame()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        string name = gameObject.name;
        switch (name)
        {
            case "Archive1":
                SaveManager.Instance.curArchive = SaveManager.Instance.gameData1;
                SaveManager.Instance.curArchiveName = 1;
                break;
            case "Archive2":
                SaveManager.Instance.curArchive = SaveManager.Instance.gameData2;
                SaveManager.Instance.curArchiveName = 2;
                break;
            case "Archive3":
                SaveManager.Instance.curArchive = SaveManager.Instance.gameData3;
                SaveManager.Instance.curArchiveName = 3;
                break;
        }

        curLevel = SaveManager.Instance.curArchive.level;
        switch (curLevel)
        {
            case 0:
                SaveManager.Instance.curArchive.level = 1;
                Debug.Log(SaveManager.Instance.gameData1.level);
                // Debug.Log("xxxxxxxxx");
                // Debug.Log(SaveManager.Instance.gameData1.level);
                // Debug.Log("YYYYYYYY");
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game01Scene);
                MySceneManager.Instance.ChangeScene(new Game01Scene());
                break;
            case 1:
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game01Scene);
                MySceneManager.Instance.ChangeScene(new Game01Scene());
                break;
            case 2:
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game02Scene);
                MySceneManager.Instance.ChangeScene(new Game02Scene());
                break;
            case 3:
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game03Scene);
                MySceneManager.Instance.ChangeScene(new Game03Scene());
                break;
            case 4:
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game04Scene);
                MySceneManager.Instance.ChangeScene(new Game04Scene());
                break;
        }
        
        UIManager.Instance.ClosePanel("AdventurePanel");
    }

    public void BtnDelArchive()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        string name = gameObject.name;
        switch (name)
        {
            case "Archive1":
                SaveManager.Instance.gameData1 = CreateGameData();
                SaveManager.Instance.SaveByGameData(1);
                break;
            case "Archive2":
                SaveManager.Instance.gameData2 = CreateGameData();
                SaveManager.Instance.SaveByGameData(2);
                break;
            case "Archive3":
                SaveManager.Instance.gameData3 = CreateGameData();
                SaveManager.Instance.SaveByGameData(3);
                break;
        }
        
        HideArchive();
    }

    private GameData CreateGameData()
    {
        GameData gameData = new GameData();
        gameData.level = 0;
        gameData.finishLevel = 0;
        gameData.cherry = 0;
        gameData.die = 0;
        gameData.playerPos = new List<int>{-7,0,0};
        gameData.cameraPos = new List<int>{0,0,0};
        gameData.cherryState = new List<bool>();
        for (int i = 0; i < 16; i++)
        {
            gameData.cherryState.Add(false);
        }
            
        return gameData;
    }
}
