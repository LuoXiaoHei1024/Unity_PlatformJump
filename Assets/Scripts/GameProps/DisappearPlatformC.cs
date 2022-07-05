/*****************************************************
    文件：DisappearPlatformC.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/4/18 22:8
    功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatformC : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float disappearSpeed;

    private bool _isHide;
    private float _r;
    private float _g;
    private float _b;
    private float _a;
    
    void Start()
    {
        _isHide = false;
        _a = spriteRenderer.color.a;
        _b = spriteRenderer.color.b;
        _g = spriteRenderer.color.g;
        _r = spriteRenderer.color.r;
    }

    void Update()
    {
        if (_isHide)
        {
            spriteRenderer.color = new Color(_r,_g,_b,
                spriteRenderer.color.a - Time.deltaTime * disappearSpeed);
        }

        if (spriteRenderer.color.a <= 0.1)
        {
            spriteRenderer.gameObject.SetActive(false);
            _isHide = false;
            Invoke("Show",5f);
        }
    }

    public void Hide()
    {
        _isHide = true;
    }

    private void Show()
    {
        spriteRenderer.gameObject.SetActive(true);
        spriteRenderer.color = new Color(_r,_g,_b,1f);
    }
}
