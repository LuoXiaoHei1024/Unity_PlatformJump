/*****************************************************
    文件：MySceneManager.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 15:48
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;

namespace LFramework.Manager
{
    public class MySceneManager : Singleton<MySceneManager>
    {
        private string _currentSceneName;
        
        private IBaseScene _currentScene = new LFrameworkScene();
        private IBaseScene _lastScene;

        private MySceneManager()
        {
            Debug.Log("singleton MySceneManager ctor");
        }
        
        public void ChangeScene(IBaseScene baseScene)
        {
            _lastScene = _currentScene;
            _currentScene = baseScene;
            // 上一个场景退出，当前场景进入
            _lastScene.ExitScene();
            // _currentScene.EnterScene();
        }

        public void SetCurrentSceneName(string sceneName)
        {
            _currentSceneName = sceneName;
        }

        public string GetCurrentSceneName()
        {
            return _currentSceneName;
        }

        public BaseScene GetCurrentScene()
        {
            return (BaseScene) _currentScene;
        }
    }
}
