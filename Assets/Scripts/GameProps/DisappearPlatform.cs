/*****************************************************
    文件：DisappearPlatform.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 22:8
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    public DisappearPlatformC disappearPlatformC;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 开始隐藏自己
            disappearPlatformC.Hide();
        }
    }
}
