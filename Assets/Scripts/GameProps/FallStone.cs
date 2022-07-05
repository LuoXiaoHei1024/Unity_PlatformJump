/*****************************************************
    文件：FallStone.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 11:16
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStone : MonoBehaviour
{
    public Stone stone;
    public float gravityScale;
    
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
            Debug.Log("hello");
            Invoke("ChangeGravity",1f);
            
        }
    }

    private void ChangeGravity()
    {
        stone.ChangeGravity(gravityScale);
    }
}
