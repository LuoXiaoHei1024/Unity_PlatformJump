/*****************************************************
    文件：ChangeCameraPos.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 19:48
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPos : MonoBehaviour
{
    public Vector2 pos;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraFollow.Instance.ChangePos(pos);
        }
    }
}
