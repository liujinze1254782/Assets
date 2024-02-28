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
        
    }
    public override void LogicUpdate()
    {
        //����ʱ���ת�Ƶ�����״̬
        if (Time.time - statetime > FireDuringtime)
            stateMachine.SwitchState(typeof(Tank_playerIdleState));

    }
    public override void PhysicUpdate()
    {

        player.SetZeroVelocity();

    }





}
