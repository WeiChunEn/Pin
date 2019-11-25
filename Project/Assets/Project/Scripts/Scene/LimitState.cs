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
        Ass.Instance.Initinal();
       


    }
    public override void StateUpdate()
    {
        Ass.Instance.Update();
    }

    private void Find_Btn()
    {
        
        Button Limit_Restart_Btn = GameObject.Find("LimitRestart").GetComponent<Button>();
        Button Limit_Home_Btn = GameObject.Find("LimitHome").GetComponent<Button>();
       
        Button Set_Btn_Limit = GameObject.Find("Set_BtnLimit").GetComponent<Button>();
        Button Set_Home = GameObject.Find("SetHome").GetComponent<Button>();
        Button Set_Music = GameObject.Find("SetMusic").GetComponent<Button>();
        Button Set_Close = GameObject.Find("SetClose").GetComponent<Button>();

        Limit_Restart_Btn.onClick.AddListener(delegate ()
        {

            OnRestartLimitBtnClick(Limit_Restart_Btn);
        });
       
        Limit_Home_Btn.onClick.AddListener(delegate ()
        {
            OnBackHomeBtnClick(Limit_Home_Btn);
        });
        Set_Btn_Limit.onClick.AddListener(delegate ()
        {
            Ass.Instance.Set_Open_Menu();
        });
        Set_Close.onClick.AddListener(delegate ()
        {
            Ass.Instance.Set_Close_Menu();
        });
       
        Set_Home.onClick.AddListener(delegate ()
        {
            OnSetHomeBtnClick(Set_Home);
        });


    }

    private void OnSetHomeBtnClick(Button Clicl_Btn)
    {
        Ass.Instance._iNow_Level = 0;
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnRestartLimitBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new LimitState(m_Manager), "LimitScene");

    }
    private void OnBackHomeBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Ass.Instance._iNow_Level = 0;
        Ass.Instance.Save_Data();
        
        m_Manager.SetState(new MainState(m_Manager), "MainScene");

    }


}
