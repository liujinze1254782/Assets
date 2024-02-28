using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Data/stateMachine/PlayerState/Move", fileName = "Tank_playerMoveState")]
public class Tank_playerMoveState : Tank_playerState
{
    public float direction;
    public override void Enter()
    {
        base.Enter();
        
       
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(Tank_playerIdleState));
        }
        if (input.fire)
        {
            stateMachine.SwitchState(typeof(Tank_playerFireState));
        }


    }

    public override void PhysicUpdate()
    {
        player.SetVelocity(player.moveSpeed * input.xInput, player.moveSpeed * input.yInput);
    }
}
