using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    public PlayerInput input;
    public Animator animator;//���𶯻�ת�ƣ�Ŀǰ����
    public Transform ammoPosition;

    [Header("Ammo Info")]
    [SerializeField] public GameObject[] ammoPrefabs;//�ӵ���Ԥ������
    public int ammoKinds;    //�ӵ���������
    [SerializeField] public int[] ammoNumbers;//�ӵ���
    public int currentAmmo;    //��ǰʹ�õ��ӵ����,��fireState����
    [Space]
    [Header("FireCheck")]
    public bool canFire;
    public float FireCD=0.1f;


    //�趨������ʱ��
    public float timer;
    //��¼gun����ת
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


    //��һ������
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
