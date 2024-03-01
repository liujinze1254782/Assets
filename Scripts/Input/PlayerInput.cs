using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    InputControl control;

    Vector2 axis => control.PlayerInput.Move.ReadValue<Vector2>();
    //ÅÐ¶ÏÊÇ·ñ¿ª»ð
    public bool fire => control.PlayerInput.Fire.WasPerformedThisFrame();
   
    public bool Move => axis.x!=0f || axis.y!=0f;

    public bool changeWeapon => control.PlayerInput.ChangeWeapon.WasPerformedThisFrame();

    public float xInput => axis.x;
    public float yInput => axis.x != 0 ? 0 : axis.y;
    private void Awake()
    {
        control = new InputControl();
    }
    public void EnableGameplayInputs()
    {
        control.PlayerInput.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
