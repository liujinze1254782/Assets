using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class Tank_playerStateMachine : StateMachine
{
    //创建一个数组用来存储给player添加的状态，不需要一个个声明了
    [SerializeField] Tank_playerState[] states;

    Animator animator;
    PlayerInput input;
    PlayerController player;
    GunController gun;
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();
        gun = GetComponentInChildren<GunController>();
        
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach(Tank_playerState state in states)
        {
            state.Iniatialize(animator,player, this, input,gun);
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        switchOn(stateTable[typeof(Tank_playerIdleState)]);
    }

}
