/*****************************************************
    文件：OptionPanel.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/23 22:20
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionPanel : BasePanel
{
    public Text txtLeft;
    public Text txtRight;
    public Text txtJump;
    public Text txtAudio;
    public Text txtBgmAudio;

    private string _leftKey;
    private string _rightKey;
    private string _jumpKey;
    private int _sound;
    private int _bgmSound;
    
    public override void InitPanel()
    {
        base.InitPanel();
        
        // SaveManager.Instance.LoadByGameSetting();
        
        
    }

    public override void UpdatePanel()
    {
        base.UpdatePanel();
        _leftKey = SaveManager.Instance.gameSettingData.leftKey;
        _rightKey = SaveManager.Instance.gameSettingData.rightKey;
        _jumpKey = SaveManager.Instance.gameSettingData.jumpKey;
        _sound = SaveManager.Instance.gameSettingData.sound;
        _bgmSound = SaveManager.Instance.gameSettingData.bgmSound;

        txtLeft.text = _leftKey;
        txtRight.text = _rightKey;
        txtJump.text = _jumpKey;
        txtAudio.text = _sound.ToString();
        txtBgmAudio.text = _bgmSound.ToString();
    }

    public override void EnterPanel()
    {
        base.EnterPanel();
        gameObject.SetActive(true);
    }

    public override void ExitPanel()
    {
        base.ExitPanel();

        _leftKey = txtLeft.text;
        _rightKey = txtRight.text;
        _jumpKey = txtJump.text;
        _sound = int.Parse(txtAudio.text);
        _bgmSound = int.Parse(txtBgmAudio.text);
        
        SaveManager.Instance.gameSettingData.leftKey = _leftKey;
        SaveManager.Instance.gameSettingData.rightKey = _rightKey;
        SaveManager.Instance.gameSettingData.jumpKey = _jumpKey;
        SaveManager.Instance.gameSettingData.sound = _sound;
        SaveManager.Instance.gameSettingData.bgmSound = _bgmSound;
        
        SaveManager.Instance.SaveByGameSetting();
        AudioManager.Instance.ChangeAudioSize(
            SaveManager.Instance.gameSettingData.sound, SaveManager.Instance.gameSettingData.bgmSound);

        gameObject.SetActive(false);
    }

    public void BtnExit()
    {
        AudioManager.Instance.PlayUiAudio("Click", "sounds", true);
        UIManager.Instance.ClosePanel("GameOptionPanel");
        UIManager.Instance.OpenPanel("GameMenuPanel");
    }
}
