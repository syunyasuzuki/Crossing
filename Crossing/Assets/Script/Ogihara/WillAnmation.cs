﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillAnmation : MonoBehaviour
{
    enum Anim
    {
        wait = 0,
        blink = 1,
        twist = 2,
        twist_blink = 3,
        twist_back = 4
    };

    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

   [SerializeField] int animcount = 0;

    void Animation_Random()//アニメーションをランダムに動かす為の物
    {

    }

    void Set_Animation()//アニメーション
    {
        switch (animcount)
        {
            case 0:
                Animator.SetInteger("AnimationInt", (int)Anim.wait);
                break;
            case 1:
                Animator.SetInteger("AnimationInt", (int)Anim.blink);
                break;
            case 2:
                Animator.SetInteger("AnimationInt", (int)Anim.twist);
                break;
            case 3:
                Animator.SetInteger("AnimationInt", (int)Anim.twist_blink);
                break;
            case 4:
                Animator.SetInteger("AnimationInt", (int)Anim.twist_back);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Set_Animation();
    }
}
