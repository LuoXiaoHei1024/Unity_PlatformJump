/*****************************************************
    文件：House.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/16 19:19
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 保存数据
            // 加载下一关
            GameController.Instance.IntoNextLevel();
        }
    }
}
