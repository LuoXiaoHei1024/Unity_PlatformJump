/*****************************************************
    文件：PlayerMove.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/24 16:19
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public int againJumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private KeyCode _left;
    private KeyCode _right;
    private KeyCode _jump;
    private int _curJumpCount;
    private int _maxJumpCount;
    private bool _isJump;
    private bool _isAllowJump;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

        _curJumpCount = 1;
        _maxJumpCount = 2;
        _isJump = false;
        _isAllowJump = false;
    }

    void Update()
    {
        if (Input.GetKey(_left))
        {
            // Run(-1);
            transform.localScale = new Vector3(-1.5f,1.5f,1);
            _rigidbody.velocity = new Vector2(-1 * speed,
                _rigidbody.velocity.y);
            _animator.SetFloat("Run", 1.0f);
        }
        if (Input.GetKey(_right))
        {
            // Run(1);
            transform.localScale = new Vector3(1.5f,1.5f,1);
            _rigidbody.velocity = new Vector2(1 * speed,
                _rigidbody.velocity.y);
            _animator.SetFloat("Run", 1.0f);
        }

        if (Input.GetKeyUp(_left) || Input.GetKeyUp(_right))
        {
            _animator.SetFloat("Run", 0.0f);
            _rigidbody.velocity = new Vector2(0,_rigidbody.velocity.y);
        }
        
        
        if (Input.GetKeyDown(_jump))
        {
            if (_curJumpCount == 1 &&
                (_collider.IsTouchingLayers(LayerMask.GetMask("Ground")) || _isAllowJump))
            {
                AudioManager.Instance.PlayPlayerAudio("Jump", "sounds", true);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,
                    jumpForce);
                _animator.SetBool("Jump", true);
                _animator.SetBool("Fall", false);
                _curJumpCount++;
                _isJump = true;
                _isAllowJump = false;
            }
            else if(_curJumpCount <= _maxJumpCount && _isJump)
            {
                AudioManager.Instance.PlayPlayerAudio("Jump", "sounds", true);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,
                    againJumpForce);
                _animator.SetBool("Jump", true);
                _animator.SetBool("Fall", false);
                _curJumpCount++;
            }
        }

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1)
                                   * Time.deltaTime;
        }
        else if(_rigidbody.velocity.y > 0 && !Input.GetKey(_jump))
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1)
                                   * Time.deltaTime;
        }

        if (_animator.GetBool("Jump"))
        {
            if (_rigidbody.velocity.y < 0)
            {
                _animator.SetBool("Jump", false);
                _animator.SetBool("Fall", true);
            }
        }
        else if(_collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _animator.SetBool("Fall", false);
            _animator.SetBool("Jump", false);
            _curJumpCount = 1;
            _isJump = false;
        }
    }

    // private void Run(int hori)
    // {
    //     
    // }

    public void SetKeyCode(KeyCode left, KeyCode right, KeyCode jump)
    {
        _left = left;
        _right = right;
        _jump = jump;
    }

    public void AddForce(float x)
    {
        // _rigidbody.AddForce(Vector2.up * x);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, x);
    }

    public void AllowJump()
    {
        _isAllowJump = true;
    }
}
