using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelState : ISceneState
{
    public LevelState(SceneStateManager Manager):base(Manager)
    {
        this.StateName = "LevelScene";
    }
    public override void StateBegin()
    {
        
        //取得按鈕
        Find_Btn();

    }
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
        Home_Btn.onClick.AddListener(() => OnHomeBtnClick(Home_Btn));

        Debug.Log(Home_Btn.name);
    }

    public void OnHomeBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new StartState(m_Manager), "StartScene");
    }

}
