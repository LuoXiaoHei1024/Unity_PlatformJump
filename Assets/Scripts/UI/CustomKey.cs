/*****************************************************
    文件：CustomKey.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 16:45
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomKey : MonoBehaviour,IPointerExitHandler,IPointerClickHandler
{
    public KeyCode curInput = KeyCode.None;
    public Text txtDesplay;

    private bool _isStart = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (_isStart)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetMouseButton(0)|| Input.GetMouseButton(1) || Input.GetMouseButton(2))
                    {
                        continue;//去除鼠标按键的影响
                    }
                    if (Input.GetKeyDown(keyCode))
                    {
                        curInput = keyCode;//按下的按钮
                        txtDesplay.text = curInput.ToString();
                        _isStart = false;
                    }
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isStart = true;
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isStart = false;
    }
}
