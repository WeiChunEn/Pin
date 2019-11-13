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
        Find_Btn();
        Ass.Instance.Initinal();
        Debug.Log(Ass.Instance._iNow_Level);
       
    }
    public override void StateUpdate()
    {
        Ass.Instance.Update();
    }
    public override void StateEnd()
    {
        Debug.Log("End");
        Ass.Instance.Release();
    }
    private void Find_Btn()
    {

        Button Clear_Level_Btn = GameObject.Find("Clear_Level_Btn").GetComponent<Button>();
        Button Over_Level_Btn = GameObject.Find("Over_Level_Btn").GetComponent<Button>();
        Clear_Level_Btn.onClick.AddListener(delegate ()
        {

            OnClearLevelBtnClick(Clear_Level_Btn);
        });
        Over_Level_Btn.onClick.AddListener(delegate ()
        {

            OnOverLevelBtnClick(Over_Level_Btn);
        });

    }

    private void OnClearLevelBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        //Ass.Instance.Set_Star();
       Ass.Instance.Load_Level();
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnOverLevelBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        
       // Ass.Instance.Set_Star();
        Ass.Instance.Load_Level();
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
}
