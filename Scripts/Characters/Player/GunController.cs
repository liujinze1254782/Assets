using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    public PlayerInput input;
    public Animator animator;//开火动画转移，目前摆烂
    public Transform ammoPosition;

    [Header("Ammo Info")]
    [SerializeField] public GameObject[] ammoPrefabs;//子弹的预设数组
    public int ammoKinds;    //子弹的种类数
    [SerializeField] public int[] ammoNumbers;//子弹量
    public int currentAmmo;    //当前使用的子弹编号,被fireState调用
    [Space]
    [Header("FireCheck")]
    public bool canFire;
    public float FireCD=0.1f;


    //设定连发计时器
    public float timer;
    //记录gun的旋转
    public Quaternion gunrotate;
   

    void Awake()
    {
      
        input = GetComponentInParent<PlayerInput>();
        ammoKinds = ammoPrefabs.Length;
        currentAmmo = 0;
        gunrotate = Quaternion.identity;
    }
    private void Update()
    {
        
        changeWeapon();
        canFire=checkCanFire();
        gunRotate();
       
    }


    //下一个武器
    void changeWeapon()
    {
        if (input.changeWeapon)
        {
            currentAmmo = (currentAmmo + 1) % ammoKinds;
        }
    }

    bool checkCanFire()
    {
        timer += Time.deltaTime;
        if (ammoNumbers[currentAmmo] <= 0)
            return false;
        if (timer < FireCD)
            return false;
        return true;
    }
    void gunRotate()
    {
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            transform.Rotate(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            transform.Rotate(0, 0, -90);
        }

    }

}
