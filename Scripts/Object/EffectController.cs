using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EffectController�������ӵ���ʶ�����ֶ���ʹ�ò�ͬ�ӵ���ammoController��Ĳ�ͬ����Ԥ�輴��

public class EffectController:MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
