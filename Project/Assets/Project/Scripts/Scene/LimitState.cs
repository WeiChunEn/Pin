using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitState : ISceneState
{
    public LimitState(SceneStateManager Manager):base(Manager)
    {
        this.StateName = "LimitState";
    }
    public override void StateBegin()
    {

        //取得按鈕
        Find_Btn();


    }


    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
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
