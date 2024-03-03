using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController:MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    #region chooseAnim
    public void isMachineGun()
    {
        anim.SetBool("machineGun", true);
    }
    public void isBigGun()
    {
        anim.SetBool("bigGun", true);
    }
    #endregion
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
