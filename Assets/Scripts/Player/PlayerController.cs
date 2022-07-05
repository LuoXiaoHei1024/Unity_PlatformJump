/*****************************************************
    文件：PlayerController.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/24 16:10
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using LFramework.Util;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{

    private PlayerMove _playerMove;
    
    void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        Debug.Log("playerinit");
        SetPlayerKey();
    }

    void Update()
    {
        
    }
    
    public void SetPlayerKey()
    {
        var left = SaveManager.Instance.gameSettingData.leftKey;
        var right = SaveManager.Instance.gameSettingData.rightKey;
        var jump = SaveManager.Instance.gameSettingData.jumpKey;
        _playerMove.SetKeyCode(StringToKeyCode(left), StringToKeyCode(right), 
            StringToKeyCode(jump));
    }

    public void AddPlayerForce(float x)
    {
        _playerMove.AddForce(x);
    }

    public void AllowJump()
    {
        _playerMove.AllowJump();
    }

    private KeyCode StringToKeyCode(string x)
    {
        KeyCode keyCode = KeyCode.None;
        switch (x)
        {
            case "A":
                keyCode = KeyCode.A;
                break;
            case "B":
                keyCode = KeyCode.B;
                break;
            case "C":
                keyCode = KeyCode.C;
                break;
            case "D":
                keyCode = KeyCode.D;
                break;
            case "E":
                keyCode = KeyCode.E;
                break;
            case "F":
                keyCode = KeyCode.F;
                break;
            case "G":
                keyCode = KeyCode.G;
                break;
            case "H":
                keyCode = KeyCode.H;
                break;
            case "I":
                keyCode = KeyCode.I;
                break;
            case "J":
                keyCode = KeyCode.J;
                break;
            case "K":
                keyCode = KeyCode.K;
                break;
            case "L":
                keyCode = KeyCode.L;
                break;
            case "M":
                keyCode = KeyCode.M;
                break;
            case "N":
                keyCode = KeyCode.N;
                break;
            case "O":
                keyCode = KeyCode.O;
                break;
            case "P":
                keyCode = KeyCode.P;
                break;
            case "Q":
                keyCode = KeyCode.Q;
                break;
            case "R":
                keyCode = KeyCode.R;
                break;
            case "S":
                keyCode = KeyCode.S;
                break;
            case "T":
                keyCode = KeyCode.T;
                break;
            case "U":
                keyCode = KeyCode.U;
                break;
            case "V":
                keyCode = KeyCode.V;
                break;
            case "W":
                keyCode = KeyCode.W;
                break;
            case "X":
                keyCode = KeyCode.X;
                break;
            case "Y":
                keyCode = KeyCode.Y;
                break;
            case "Z":
                keyCode = KeyCode.Z;
                break;
        }

        return keyCode;
    }
}
