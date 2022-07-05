/*****************************************************
    文件：CameraFollow.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/12 15:50
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;

public class CameraFollow : MonoSingleton<CameraFollow>
{
    // public float smoothing;
    // public Vector2 minPosition;
    // public Vector2 maxPosition;
    //
    // private Transform target;
    
    void Start()
    {
        // target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }
    
    // void LateUpdate()
    // {
    //     if(target != null)
    //     {
    //         if(transform.position != target.position)
    //         {
    //             Vector3 targetPos = target.position;
    //             Vector3 cameraPos = transform.position;
    //             targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
    //             targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
    //             // transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    //             cameraPos.x = Mathf.Lerp(transform.position.x, targetPos.x, smoothing);
    //             cameraPos.y = Mathf.Lerp(transform.position.y, targetPos.y, smoothing);
    //             transform.position = cameraPos;
    //         }
    //     }
    // }

    public void ChangePos(Vector2 pos)
    {
        transform.position = new Vector3(pos.x,pos.y,-10);
    }
}
