/*****************************************************
    文件：LoadGame.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/20 16:20
    功能：加载游戏过度场景
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LFramework.Util
{
    /// <summary>
    /// 加载游戏过度场景
    /// </summary>
    public class LoadGame : MonoBehaviour
    {
        public Slider processView;

        // Use this for initialization
        void Start()
        {
            LoadGameMethod();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void LoadGameMethod()
        {
            StartCoroutine(StartLoading(MySceneManager.Instance.GetCurrentSceneName()));
        }

        private IEnumerator StartLoading(string sceneName)
        {
            var displayProgress = 0;
            var toProgress = 0;
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            op.allowSceneActivation = false;
            while (op.progress < 0.9f)
            {
                toProgress = (int) op.progress * 100;
                while (displayProgress < toProgress)
                {
                    ++displayProgress;
                    SetLoadingPercentage(displayProgress);
                    yield return new WaitForEndOfFrame();
                }
            }

            toProgress = 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }

            
            MySceneManager.Instance.GetCurrentScene().EnterScene();
            op.allowSceneActivation = true;
        }

        private void SetLoadingPercentage(float v)
        {
            processView.value = v / 100;
        }
    }
}
