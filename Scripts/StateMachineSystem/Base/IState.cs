using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    //进入状态
    void Enter();
    //退出状态
    void Exit();
    //状态的更新
    void LogicUpdate();
    void PhysicUpdate();


}
