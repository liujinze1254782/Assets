using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/stateMachine/PlayerState/Idle",fileName = "Tank_playerIdleState")]
public class Tank_playerIdleState : Tank_playerState
{
    public override void Enter()
    {
        base.Enter();
              
    }

    public override void LogicUpdate()
    {
        
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(Tank_playerMoveState));
        }
        if (input.fire)
        {
            stateMachine.SwitchState(typeof(Tank_playerFireState));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetZeroVelocity();
    }
}
