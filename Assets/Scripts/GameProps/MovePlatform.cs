/*****************************************************
    文件：MovePlatform.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/13 20:43
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    // 速度
    public float speed = 3;
    //方向改变时间间隔，常量
    public float changeTime = 3;
    //轴向控制
    public bool vertical; 
    
    //计时器
    private float timer;
    //方向控制
    private int direction = 1;
    
    private Transform playerDefTransform;
    
    void Start()
    {
        timer = changeTime;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector3 pos = transform.position;
        if (vertical) // 垂直方向
        {
            pos.y = pos.y + Time.deltaTime * speed * direction;
        }
        else
        {
            pos.x = pos.x + Time.deltaTime * speed * direction;
        }

        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
