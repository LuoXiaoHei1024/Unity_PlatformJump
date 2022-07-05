/*****************************************************
    文件：WoodenSign.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/12 17:26
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSign : MonoBehaviour
{
    public Vector3 playerPos;
    public Vector3 cameraPos;
    
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
            // 更改玩家复活位置
            GameController.Instance.SetSavePos(playerPos,cameraPos);
        }
    }
}
