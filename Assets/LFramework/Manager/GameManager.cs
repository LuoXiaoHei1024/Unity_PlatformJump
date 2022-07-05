/*****************************************************
    文件：GameManager.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 15:57
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LFramework.Manager
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance => _instance;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            // GameDevelop();
            Debug.Log("hello");
            InitGame();

            // 加载新场景
            // 设置当前应该加载场景的名字
            MySceneManager.Instance.SetCurrentSceneName(SceneName.MenuScene);
            MySceneManager.Instance.ChangeScene(new MenuScene());
        }

        private void InitGame()
        {
            SaveManager.Instance.LoadByGameSetting();
            SaveManager.Instance.LoadByAchievementData();
            SaveManager.Instance.LoadByGameData(1);
            SaveManager.Instance.LoadByGameData(2);
            SaveManager.Instance.LoadByGameData(3);
            
            AudioManager.Instance.ChangeAudioSize(
                SaveManager.Instance.gameSettingData.sound,SaveManager.Instance.gameSettingData.bgmSound);

            
        }

        private void GameDevelop()
        {
            
        }
    }
}
