/*****************************************************
    文件：SavaManager.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/7 14:22
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using LFramework.Util;
using LitJson;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    public GameSettingData gameSettingData = new GameSettingData();
    
    public AchievementData achievementData = new AchievementData();

    public GameData curArchive;
    public int curArchiveName;
    public GameData gameData1 = new GameData();
    public GameData gameData2 = new GameData();
    public GameData gameData3 = new GameData();
    
    private SaveManager()
    {
        
    }

    #region GameSettingData

    public void SaveByGameSetting()
    {
        //保存当前游戏状态，创建save对象（CreateSaveGo函数根据保存数据需要编写）
        // gameSettingData = CreateGameSettingData();
        //保存文件路径（美化代码）
        string filePath = Application.dataPath + "/Resources/JsonData" + "/GameSettingData.json";//文件类型可以时.json也可以是.txt
        //通过JsonMapper.ToJson方法将save对象中的数据转化为json字符串保存下来
        string saveJsonStr = JsonMapper.ToJson(gameSettingData);//using LitJson;
        //创建StreamWriter写入流（注意需要一个string参数代表路径）
        StreamWriter streamWriter = new StreamWriter(filePath);
        //将转化后的字符串写入目标文件
        streamWriter.Write(saveJsonStr);
        //关闭StreamWriter
        streamWriter.Close();
    }
    
    public void LoadByGameSetting()
    { 
        //string保存路径（美化代码）
        string filePath = Application.dataPath + "/Resources/JsonData" + "/GameSettingData.json";
        //创建文件读取流（注意new对象时需要string类型参数代表路径）
        StreamReader streamReader = new StreamReader(filePath);
        //读取文件中所有的字符串（ReadToEnd代表读取到最后，即读取所有）
        string jsonStr = streamReader.ReadToEnd();
        //将读取到的字符串通过JsonMapper.ToObject转换为Save类型的对象（JsonMapper.ToObject<类型>(路径);）
        gameSettingData = JsonMapper.ToObject<GameSettingData>(jsonStr);//using LitJson;
        //设置游戏状态，根据游戏需要自行编写
        // SetGame(saveData);
        // Debug.Log(gameSettingData.leftKey);
    }
    
    // private GameSettingData CreateGameSettingData()
    // {
    //     GameSettingData gameSettingData = new GameSettingData();
    //     gameSettingData.sound = 10;
    //     gameSettingData.bgmSound = 10;
    //     gameSettingData.leftKey = "A";
    //     gameSettingData.rightKey = "D";
    //     gameSettingData.jumpKey = "J";
    //         
    //     return gameSettingData;
    // }

    #endregion

    #region GameData

    public void SaveByGameData(int x)
    {
        //保存当前游戏状态，创建save对象（CreateSaveGo函数根据保存数据需要编写）
        // gameSettingData = CreateGameSettingData();
        //保存文件路径（美化代码）
        string filePath = Application.dataPath + "/Resources/JsonData" + "/Archive" + x.ToString() +
                          ".json";//文件类型可以时.json也可以是.txt
        //通过JsonMapper.ToJson方法将save对象中的数据转化为json字符串保存下来
        string saveJsonStr = "";
        switch (x)
        {
            case 1:
                saveJsonStr = JsonMapper.ToJson(gameData1);//using LitJson;
                break;
            case 2:
                saveJsonStr = JsonMapper.ToJson(gameData2);//using LitJson;
                break;
            case 3:
                saveJsonStr = JsonMapper.ToJson(gameData3);//using LitJson;
                break;
            default:
                saveJsonStr = JsonMapper.ToJson(gameData1);//using LitJson;
                break;
        }
        //创建StreamWriter写入流（注意需要一个string参数代表路径）
        StreamWriter streamWriter = new StreamWriter(filePath);
        //将转化后的字符串写入目标文件
        streamWriter.Write(saveJsonStr);
        //关闭StreamWriter
        streamWriter.Close();
    }
    
    public void LoadByGameData(int x)
    { 
        //string保存路径（美化代码）
        string filePath = Application.dataPath + "/Resources/JsonData" + "/Archive" + x.ToString() +
                          ".json";//文件类型可以时.json也可以是.txt
        //创建文件读取流（注意new对象时需要string类型参数代表路径）
        StreamReader streamReader = new StreamReader(filePath);
        //读取文件中所有的字符串（ReadToEnd代表读取到最后，即读取所有）
        string jsonStr = streamReader.ReadToEnd();
        //将读取到的字符串通过JsonMapper.ToObject转换为Save类型的对象（JsonMapper.ToObject<类型>(路径);）
        switch (x)
        {
            case 1:
                gameData1 = JsonMapper.ToObject<GameData>(jsonStr);//using LitJson;
                break;
            case 2:
                gameData2 = JsonMapper.ToObject<GameData>(jsonStr);//using LitJson;
                break;
            case 3:
                gameData3 = JsonMapper.ToObject<GameData>(jsonStr);//using LitJson;
                break;
            default:
                gameData1 = JsonMapper.ToObject<GameData>(jsonStr);//using LitJson;
                break;
        }
        //设置游戏状态，根据游戏需要自行编写
        // SetGame(saveData);
        // Debug.Log(gameSettingData.leftKey);
    }
    
    // public GameData CreateGameData()
    // {
    //     GameData gameData = new GameData();
    //     gameData.level = 1;
    //     gameData.cherry = 0;
    //     gameData.die = 0;
    //     gameData.playerX = 0;
    //     gameData.playerY = 0;
    //     gameData.playerZ = 0;
    //         
    //     return gameData;
    // }

    #endregion

    #region AchievementData

    public void SaveByAchievementData()
    {
        //保存当前游戏状态，创建save对象（CreateSaveGo函数根据保存数据需要编写）
        // gameSettingData = CreateGameSettingData();
        //保存文件路径（美化代码）
        string filePath = Application.dataPath + "/Resources/JsonData" + "/AchievementData.json";//文件类型可以时.json也可以是.txt
        //通过JsonMapper.ToJson方法将save对象中的数据转化为json字符串保存下来
        string saveJsonStr = JsonMapper.ToJson(achievementData);//using LitJson;
        //创建StreamWriter写入流（注意需要一个string参数代表路径）
        StreamWriter streamWriter = new StreamWriter(filePath);
        //将转化后的字符串写入目标文件
        streamWriter.Write(saveJsonStr);
        //关闭StreamWriter
        streamWriter.Close();
    }
    
    public void LoadByAchievementData()
    { 
        //string保存路径（美化代码）
        string filePath = Application.dataPath + "/Resources/JsonData" + "/AchievementData.json";
        //创建文件读取流（注意new对象时需要string类型参数代表路径）
        StreamReader streamReader = new StreamReader(filePath);
        //读取文件中所有的字符串（ReadToEnd代表读取到最后，即读取所有）
        string jsonStr = streamReader.ReadToEnd();
        //将读取到的字符串通过JsonMapper.ToObject转换为Save类型的对象（JsonMapper.ToObject<类型>(路径);）
        achievementData = JsonMapper.ToObject<AchievementData>(jsonStr);//using LitJson;
        //设置游戏状态，根据游戏需要自行编写
        // SetGame(saveData);
        // Debug.Log(gameSettingData.leftKey);
    }

    #endregion
}
