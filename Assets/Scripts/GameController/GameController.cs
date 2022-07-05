/*****************************************************
    文件：GameController.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/11 22:4
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using LFramework.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoSingleton<GameController>
{
    private ResLoader _resLoader = new ResLoader();
    
    private GameObject _player;
    private Vector3 _playerResurrectionPos;
    private Vector3 _cameraResurrectionPos;
    private int _cherryNum = 0;
    private int _dieNum = 0;
    private bool _isChangeKey = false;
    
    void Awake()
    {
        Debug.Log(_cherryNum);
        Debug.Log(_dieNum);
        
        // 初始化游戏角色
        _playerResurrectionPos = new Vector3(
            SaveManager.Instance.curArchive.playerPos[0],
            SaveManager.Instance.curArchive.playerPos[1],
            SaveManager.Instance.curArchive.playerPos[2]);
        _player = Object.Instantiate(_resLoader.LoadSync<GameObject>("game", "Player"));
        _player.transform.position = _playerResurrectionPos;
        // _resLoader.LoadAsync<GameObject>("game", "Player",
        //     go =>
        //     {
        //         _player = Object.Instantiate(go);
        //         _player.transform.position = _playerResurrectionPos;
        //     });
        
        _cameraResurrectionPos = new Vector3(
            SaveManager.Instance.curArchive.cameraPos[0],
            SaveManager.Instance.curArchive.cameraPos[1],
            SaveManager.Instance.curArchive.cameraPos[2]);
        CameraFollow.Instance.ChangePos(_cameraResurrectionPos);
    }

    void Update()
    {
        OpenGameMenu();
    }

    #region GameMenu
    
    private void OpenGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.OpenPanel("GameMenuPanel");
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        _player.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        _player.SetActive(true);
        if (_isChangeKey)
        {
            PlayerController.Instance.SetPlayerKey();
            _isChangeKey = false;
        }
    }

    public void RetryGame()
    {
        ContinueGame();
        _player.transform.position = _playerResurrectionPos;
        CameraFollow.Instance.ChangePos(_cameraResurrectionPos);
    }

    public void ReStartGame()
    {
        ContinueGame();
        _playerResurrectionPos = new Vector3(-7,0,0);
        _cameraResurrectionPos = new Vector3(0,0,-10);
        SaveGame();
        
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Game01Scene":
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game01Scene);
                MySceneManager.Instance.ChangeScene(new Game01Scene());
                break;
            case "Game02Scene":
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game02Scene);
                MySceneManager.Instance.ChangeScene(new Game02Scene());
                break;
            case "Game03Scene":
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game03Scene);
                MySceneManager.Instance.ChangeScene(new Game03Scene());
                break;
            case "Game04Scene":
                // 设置当前应该加载场景的名字
                MySceneManager.Instance.SetCurrentSceneName(SceneName.Game04Scene);
                MySceneManager.Instance.ChangeScene(new Game04Scene());
                break;
        }
    }

    public void ExitGame()
    {
        ContinueGame();
        SaveGame();
        MySceneManager.Instance.SetCurrentSceneName(SceneName.MenuScene);
        MySceneManager.Instance.ChangeScene(new MenuScene());
    }

    public void Option()
    {
        _isChangeKey = true;
    }

    public void ChooseLevel()
    {
        // ContinueGame();
        Time.timeScale = 1f;
        _playerResurrectionPos = new Vector3(-7,0,0);
        _cameraResurrectionPos = new Vector3(0,0,-10);
        SaveGame();
    }
    
    #endregion
    
    private void SaveGame()
    {
        SaveManager.Instance.curArchive.cherry += _cherryNum;
        SaveManager.Instance.curArchive.die += _dieNum;
        SaveManager.Instance.curArchive.playerPos[0] = (int)_playerResurrectionPos.x;
        SaveManager.Instance.curArchive.playerPos[1] = (int)_playerResurrectionPos.y;
        SaveManager.Instance.curArchive.playerPos[2] = (int)_playerResurrectionPos.z;
        SaveManager.Instance.curArchive.cameraPos[0] = (int)_cameraResurrectionPos.x;
        SaveManager.Instance.curArchive.cameraPos[1] = (int)_cameraResurrectionPos.y;
        SaveManager.Instance.curArchive.cameraPos[2] = (int)_cameraResurrectionPos.z;
        SaveManager.Instance.SaveByGameData(SaveManager.Instance.curArchiveName);
    }

    public void AddCherryNum(int x)
    {
        _cherryNum += x;
    }

    // public void AddDieNum(int x)
    // {
    //     _dieNum++;
    // }

    public void ResurrectionPlayer()
    {
        _dieNum++;
        _player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        _player.transform.position = _playerResurrectionPos;
        CameraFollow.Instance.ChangePos(_cameraResurrectionPos);
    }

    public void SetSavePos(Vector3 playerPos, Vector3 cameraPos)
    {
        _playerResurrectionPos = playerPos;
        _cameraResurrectionPos = cameraPos;
    }

    public void IntoNextLevel()
    {
        _playerResurrectionPos = new Vector3(-7,0,0);
        _cameraResurrectionPos = new Vector3(0,0,-10);
        // Debug.Log(SaveManager.Instance.curArchive.level);
        // 如果已经是第四关
        if (SaveManager.Instance.curArchive.level == 4)
        {
            SaveManager.Instance.curArchive.finishLevel = 4;
            SaveGame();
            MySceneManager.Instance.SetCurrentSceneName(SceneName.MenuScene);
            MySceneManager.Instance.ChangeScene(new MenuScene());
            return;
        }

        // 不是第四关
        if (SaveManager.Instance.curArchive.level > SaveManager.Instance.curArchive.finishLevel)
        {
            SaveManager.Instance.curArchive.level += 1;
            SaveManager.Instance.curArchive.finishLevel += 1;
            SaveGame();
            switch (SaveManager.Instance.curArchive.level)
            {
                case 2:
                    MySceneManager.Instance.SetCurrentSceneName(SceneName.Game02Scene);
                    MySceneManager.Instance.ChangeScene(new Game02Scene());
                    break;
                case 3:
                    MySceneManager.Instance.SetCurrentSceneName(SceneName.Game03Scene);
                    MySceneManager.Instance.ChangeScene(new Game03Scene());
                    break;
                case 4:
                    MySceneManager.Instance.SetCurrentSceneName(SceneName.Game04Scene);
                    MySceneManager.Instance.ChangeScene(new Game04Scene());
                    break;
            }
        }
        else
        {
            SaveManager.Instance.curArchive.level += 1;
            SaveGame();
            switch (SaveManager.Instance.curArchive.level)
            {
                case 2:
                    MySceneManager.Instance.SetCurrentSceneName(SceneName.Game02Scene);
                    MySceneManager.Instance.ChangeScene(new Game02Scene());
                    break;
                case 3:
                    MySceneManager.Instance.SetCurrentSceneName(SceneName.Game03Scene);
                    MySceneManager.Instance.ChangeScene(new Game03Scene());
                    break;
                case 4:
                    MySceneManager.Instance.SetCurrentSceneName(SceneName.Game04Scene);
                    MySceneManager.Instance.ChangeScene(new Game04Scene());
                    break;
            }
        }
    }
}
