using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : ISceneState
{
    public StartState(SceneStateManager Manager):base(Manager)
    {
        this.StateName = "StartState";
    }
    public override void StateBegin()
    {
        
    }
    public override void StateUpdate()
    {
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }

}
