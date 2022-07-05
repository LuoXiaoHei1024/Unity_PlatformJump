/*****************************************************
    文件：Stone.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 11:22
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private bool _isReturn;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<BoxCollider2D>();
        // _rigidbody2D.Sleep();
        _isReturn = false;
    }

    void Update()
    {
        if (_collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            // ChangeGravity(0);
            _rigidbody2D.Sleep();
            Invoke("ChangeIsReturn", 1.5f);
        }

        if (_isReturn)
        {
            transform.localPosition = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 玩家复活
            GameController.Instance.ResurrectionPlayer();
            // 死亡次数加一
            // GameController.Instance.AddDieNum(1);
        }
    }

    private void ChangeIsReturn()
    {
        _isReturn = true;
    }

    public void ChangeGravity(float x)
    {
        Debug.Log("wakeup");
        _rigidbody2D.gravityScale = x;
        _rigidbody2D.WakeUp();
        _rigidbody2D.velocity = new Vector2(0,-2);
        Debug.Log("stone");
    }
}
