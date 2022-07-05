/*****************************************************
    文件：ExchangePlatform.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 22:33
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;

public class ExchangePlatform : MonoBehaviour
{
    public GameObject[] redPlatform;
    public GameObject[] bluePlatform;
    public float exchangeTime;
    
    private bool _isRedDis;
    
    void Start()
    {
        _isRedDis = true;
        for (int i = 0; i < redPlatform.Length; i++)
        {
            redPlatform[i].SetActive(false);
        }
        InvokeRepeating("Exchange", exchangeTime,exchangeTime);
    }

    void Update()
    {
        
    }

    private void Exchange()
    {
        if (_isRedDis)
        {
            for (int i = 0; i < redPlatform.Length; i++)
            {
                redPlatform[i].SetActive(true);
            }
            for (int i = 0; i < bluePlatform.Length; i++)
            {
                bluePlatform[i].SetActive(false);
            }

            _isRedDis = false;
        }
        else
        {
            for (int i = 0; i < redPlatform.Length; i++)
            {
                redPlatform[i].SetActive(false);
            }
            for (int i = 0; i < bluePlatform.Length; i++)
            {
                bluePlatform[i].SetActive(true);
            }

            _isRedDis = true;
        }
    }
}
