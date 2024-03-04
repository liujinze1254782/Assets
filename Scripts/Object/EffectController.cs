using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EffectController不参与子弹的识别，区分动画使用不同子弹的ammoController里的不同动画预设即可

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
