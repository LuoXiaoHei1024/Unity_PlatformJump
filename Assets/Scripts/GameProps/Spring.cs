/*****************************************************
    文件：Spring.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/13 22:27
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float force;
    
    private Animator _animator;
    private BoxCollider2D _collider2D;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<BoxCollider2D>();
        // _animator.SetTrigger("Jump");
    }

    void Update()
    {
        if (_collider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            // 给玩家一个向上的力
            PlayerController.Instance.AddPlayerForce(force);
            PlayerController.Instance.AllowJump();
            // 播放动画
            _animator.SetTrigger("Jump");
        }
    }
}
