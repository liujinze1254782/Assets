using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public PlayerInput input;
    public Rigidbody2D rb;
    public float moveSpeed = 1.8f;

    public Transform ammoPosition;
    [SerializeField] public GameObject[] ammoPrefabs;

    public int currentWeapon;
    

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        currentWeapon = 0;
       
    }

    public void Start()
    {
        input.EnableGameplayInputs();
    }
    private void Update()
    {
        changeWeapon();
    }

    void changeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentWeapon = 0;
        }
    }


    public void SetVelocity(float _xVelocity,float _yVelocity)
    {
        if (_xVelocity > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (_xVelocity < 0)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (_yVelocity > 0)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        else if(_yVelocity<0)
            transform.rotation = Quaternion.Euler(0, 0, 270);

        rb.velocity = new Vector2(_xVelocity, _yVelocity);       
    }

    public void SetZeroVelocity()
    {
        SetVelocity(0f,0f);
    }

}
