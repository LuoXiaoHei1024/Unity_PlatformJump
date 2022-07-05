/*****************************************************
    文件：GameData.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 17:42
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    /// <summary>
    /// 
    /// </summary>
    public int level { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int finishLevel { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int cherry { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int die { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <int > playerPos { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <int > cameraPos { get; set; }
    /// <summary>
    /// false 表明还没收集，true 表明收集了
    /// </summary>
    public List<bool> cherryState { get; set; }
}
