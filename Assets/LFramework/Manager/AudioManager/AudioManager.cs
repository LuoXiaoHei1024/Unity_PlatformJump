/*****************************************************
    文件：AudioManager.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2021/11/23 22:23
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Manager;
using LFramework.Util;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioSource uiAudio;
    public AudioSource bgmAudio;
    public AudioSource playerAudio;
    public AudioSource enemyAudio;

    private ResLoader _resLoader = new ResLoader();
    private Dictionary<string,AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void PlayUiAudio(string audioName, string abName, bool isCache = false)
    {
        AudioClip audioClip = null;
        if (_audioClips.ContainsKey(audioName))
        {
            _audioClips.TryGetValue(audioName, out audioClip);
        }
        else
        {
            audioClip = _resLoader.LoadSync<AudioClip>(abName, audioName);
            _audioClips.Add(audioName, audioClip);
            // _resLoader.LoadAsync<AudioClip>(abName,audioName, 
            //     audio =>
            //     {
            //         audioClip = audio;
            //         _audioClips.Add(audioName, audioClip);
            //     });
        }
        
        uiAudio.clip = audioClip;
        uiAudio.Play();
    }
    
    public void PlayBgmAudio(string audioName, string abName, bool isCache = false)
    {
        AudioClip audioClip = null;
        if (_audioClips.ContainsKey(audioName))
        {
            _audioClips.TryGetValue(audioName, out audioClip);
        }
        else
        {
            audioClip = _resLoader.LoadSync<AudioClip>(abName, audioName);
            _audioClips.Add(audioName, audioClip);
            // _resLoader.LoadAsync<AudioClip>(abName,audioName, 
            //     audio =>
            //     {
            //         audioClip = audio;
            //         _audioClips.Add(audioName, audioClip);
            //     });
        }
        
        bgmAudio.clip = audioClip;
        bgmAudio.loop = true;
        bgmAudio.Play();
    }

    public void StopBgmAudio()
    {
        bgmAudio.Stop();
    }
    
    public void PlayPlayerAudio(string audioName, string abName, bool isCache = false)
    {
        AudioClip audioClip = null;
        if (_audioClips.ContainsKey(audioName))
        {
            _audioClips.TryGetValue(audioName, out audioClip);
        }
        else
        {
            audioClip = _resLoader.LoadSync<AudioClip>(abName, audioName);
            _audioClips.Add(audioName, audioClip);
            // _resLoader.LoadAsync<AudioClip>(abName,audioName, 
            //     audio =>
            //     {
            //         audioClip = audio;
            //         _audioClips.Add(audioName, audioClip);
            //     });
        }
        
        playerAudio.clip = audioClip;
        playerAudio.Play();
    }
    
    public void PlayEnemyAudio(string audioName, string abName, bool isCache = false)
    {
        AudioClip audioClip = null;
        if (_audioClips.ContainsKey(audioName))
        {
            _audioClips.TryGetValue(audioName, out audioClip);
        }
        else
        {
            audioClip = _resLoader.LoadSync<AudioClip>(abName, audioName);
            _audioClips.Add(audioName, audioClip);
            // _resLoader.LoadAsync<AudioClip>(abName,audioName, 
            //     audio =>
            //     {
            //         audioClip = audio;
            //         _audioClips.Add(audioName, audioClip);
            //     });
        }
        
        enemyAudio.clip = audioClip;
        enemyAudio.Play();
    }

    public void ChangeAudioSize(int audio, int bgm)
    {
        bgmAudio.volume = (float)bgm / 10;
        uiAudio.volume = (float) audio / 10;
        playerAudio.volume = (float) audio / 10;
        enemyAudio.volume = (float) audio / 10;
    }
}
