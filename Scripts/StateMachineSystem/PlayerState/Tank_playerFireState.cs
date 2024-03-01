using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/stateMachine/PlayerState/Fire", fileName = "Tank_playerFireState")]
public class Tank_playerFireState : Tank_playerState
{
    [SerializeField]float []FireDuration;
    public AudioClip []fireSound;

    public override void Enter()
    {
        base.Enter();
        gun.timer = 0;
        gun.ammoNumbers[gun.currentAmmo]--;
        //��currentWeapon����ʾ���ӵ������ȥ
        Instantiate(gun.ammoPrefabs[gun.currentAmmo],gun.ammoPosition.position, gun.transform.rotation);
        SoundEffectPlayer.audioSource.mute = false;
        SoundEffectPlayer.audioSource.PlayOneShot(fireSound[gun.currentAmmo]);
    }
    public override void LogicUpdate()
    {
       
        //����ʱ���ת�Ƶ�����״̬
        if (Time.time - statetime > FireDuration[gun.currentAmmo])
            stateMachine.SwitchState(typeof(Tank_playerIdleState));

    }

    public override void PhysicUpdate()                                                                                                                                                                                                                              
    {
        if (gun.currentAmmo == 1)
        {
            player.SetZeroVelocity();
        }
       

    }





}
