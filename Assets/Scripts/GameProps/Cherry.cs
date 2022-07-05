/*****************************************************
    文件：Cherry.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/12 15:2
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public int cherryId;
    
    void Start()
    {
        if (GetCherryState(cherryId))
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 触碰玩家
        if (other.gameObject.CompareTag("Player"))
        {
            // 增加草莓数量
            GameController.Instance.AddCherryNum(1);
            // 修改存档
            SetCherryState(cherryId, true);
            // 隐藏自己
            gameObject.SetActive(false);
        }
    }

    private bool GetCherryState(int id)
    {
        // 默认没被收集
        bool state = false;
        state = SaveManager.Instance.curArchive.cherryState[id - 1];

        return state;
    }

    private void SetCherryState(int id, bool state = false)
    {
        SaveManager.Instance.curArchive.cherryState[id - 1] = state;
    }
}
