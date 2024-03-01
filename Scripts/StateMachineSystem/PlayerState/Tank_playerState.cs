using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_playerState : ScriptableObject, IState
{
    [SerializeField] protected string stateName;
    protected Animator animator;

    protected Tank_playerStateMachine stateMachine;
    protected PlayerController player;
    protected PlayerInput input;
    protected GunController gun;
   
    //状态开始时间
    protected float statetime;
    public void Iniatialize(Animator animator, PlayerController player, Tank_playerStateMachine stateMachine, PlayerInput input, GunController gun)
    {
        this.animator = animator;
        this.player = player;
        this.stateMachine = stateMachine;
        this.input = input;
        this.gun = gun;
        
    }
    public virtual void Enter()
    {
        statetime = Time.time;
        animator.Play(stateName);
        
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
      
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
