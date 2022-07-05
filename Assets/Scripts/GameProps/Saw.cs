/*****************************************************
    文件：Saw.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 23:19
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Vector2 left;
    public Vector2 right;
    public float moveSpeed;

    private bool _isRightMove;
    private float _leftPos;
    private float _rightPos;
    private float _y;
    private float _z;
    
    void Start()
    {
        _isRightMove = true;
        _leftPos = left.x;
        _rightPos = right.x;
        _y = left.y;
        _z = transform.position.z;
    }

    void Update()
    {
        if (_isRightMove)
        {
            transform.position = new Vector3(
                transform.position.x + Time.deltaTime * moveSpeed,
                _y,
                _z);
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x - Time.deltaTime * moveSpeed,
                _y,
                _z);
        }

        if (transform.position.x <= _leftPos)
        {
            _isRightMove = true;
        }

        if (transform.position.x >= _rightPos)
        {
            _isRightMove = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 玩家复活
            GameController.Instance.ResurrectionPlayer();
            // 死亡次数加一
            // GameController.Instance.AddDieNum(1);
        }
    }
}
