using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    public PlayerInput input;

    public Transform ammoPosition;
    //�ӵ���Ԥ������
    [SerializeField] public GameObject[] ammoPrefabs;
    //�ӵ���������
    public int ammoKinds;
    [SerializeField] public int[] ammoNumbers;
    //��ǰʹ�õ��ӵ����
    public int currentAmmo;
    //�ж��ܷ���
    public bool canFire;
    //�趨�������
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
