/*****************************************************
    文件：ChangeAudio.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 17:9
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    public Text txtAudio;

    private int audioNum;
    
    void Start()
    {
        audioNum = int.Parse(txtAudio.text.ToString());
    }

    void Update()
    {
        
    }

    public void BtnDown()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        int num = int.Parse(txtAudio.text.ToString());
        num--;
        if (num <= 0)
        {
            num = 0;
        }

        txtAudio.text = num.ToString();
    }

    public void BtnUp()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        int num = int.Parse(txtAudio.text.ToString());
        num++;
        if (num >= 10)
        {
            num = 10;
        }

        txtAudio.text = num.ToString();
    }
}
