using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    public PlayerInput input;

    public Transform ammoPosition;
    //子弹的预设数组
    [SerializeField] public GameObject[] ammoPrefabs;
    //子弹的种类数
    public int ammoKinds;
    [SerializeField] public int[] ammoNumbers;
    //当前使用的子弹编号
    public int currentAmmo;
    //判断能否发射
    public bool canFire;
    //设定连发间隔
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
