using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //当前状态
    IState currentState;

    //利用字典来获取状态集合里的状态
    protected Dictionary<System.Type, IState> stateTable;

    private void Update()
    {
        //每一帧都会调用
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        //每一帧都会调用
        currentState.PhysicUpdate();
    }

    //切换状态（一开始）
    protected void switchOn(IState newstate)
    {
        currentState = newstate;
        currentState.Enter();
        //设置新的状态，并进入新的状态
    }

    //切换状态
    public void SwitchState(IState newstate)
    {
        currentState.Exit();
        switchOn(newstate);
        //先退出原先的状态，并进入新的状态
    }

    //对状态切换方法进行一个重载，借助字典，通过新状态的类型来切换状态
    public void SwitchState(System.Type newstatetype)
    {
        SwitchState(stateTable[newstatetype]);
    }

}
