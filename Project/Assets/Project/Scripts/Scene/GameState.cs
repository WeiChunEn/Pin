using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : ISceneState
{
    public GameState (SceneStateManager Manager):base(Manager)
    {
        this.StateName = "GameScene";
    }
    public override void StateBegin()
    {
        Project.Instance.Initinal();
        Find_Btn();
    }
    public override void StateUpdate()
    {
        Project.Instance.Update();
    }
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Set_Btn").GetComponent<Button>();
        Home_Btn.onClick.AddListener(delegate ()
        {

            OnHomeBtnClick(Home_Btn);
        });

        Debug.Log(Home_Btn.name);
    }

    private void OnHomeBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
}
