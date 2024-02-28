using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/stateMachine/PlayerState/Fire", fileName = "Tank_playerFireState")]
public class Tank_playerFireState : Tank_playerState
{
    [SerializeField]float FireDuringtime;

    public override void Enter()
    {
        base.Enter();
        //将currentWeapon所表示的子弹发射出去
        Instantiate(player.ammoPrefabs[0],player.ammoPosition.position, player.transform.rotation);
    }
    public override void LogicUpdate()
    {
        if (player.currentWeapon == 0)
            stateMachine.SwitchState(typeof(Tank_playerIdleState));
        //超过时间就转移到空闲状态
        if (Time.time - statetime > FireDuringtime)
            stateMachine.SwitchState(typeof(Tank_playerIdleState));

    }
    public override void PhysicUpdate()                                                                                                                                                                                                                              
    {

        player.SetZeroVelocity();

    }





}
