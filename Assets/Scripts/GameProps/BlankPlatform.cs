/*****************************************************
    文件：BlankPlatform.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/13 20:43
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankPlatform : MonoBehaviour
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
            // 玩家复活
            GameController.Instance.ResurrectionPlayer();
            // 死亡次数加一
            // GameController.Instance.AddDieNum(1);
        }
    }
}
