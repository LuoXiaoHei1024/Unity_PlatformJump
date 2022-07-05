/*****************************************************
    文件：Achievement.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/16 16:51
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Image checkMask;

    public void ShowOrHideAchievement(bool isFinish)
    {
        if (isFinish)
        {
            checkMask.gameObject.SetActive(true);
        }
        else
        {
            checkMask.gameObject.SetActive(false);
        }
    }
}
