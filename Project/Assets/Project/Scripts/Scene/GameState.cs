﻿using System.Collections;
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
        GameObject Set_Btn = GameObject.Find("Set_Btn");
        Button Clear_Level_Btn = GameObject.Find("Clear_Level_Btn").GetComponent<Button>();
        Button Clear_Restart_Btn = GameObject.Find("ClearRestart").GetComponent<Button>();
        Button Next_Level_Btn = GameObject.Find("NextLevel").GetComponent<Button>();
        Button Clear_Home_Btn = GameObject.Find("ClearHome").GetComponent<Button>();
        Button Over_Level_Btn = GameObject.Find("Over_Level_Btn").GetComponent<Button>();
        Button Over_Restart_Btn = GameObject.Find("OverRestart").GetComponent<Button>();
        Button Over_Home_Btn = GameObject.Find("OverHome").GetComponent<Button>();
        Button Set_Btn1_5 = Set_Btn.transform.GetChild(0).GetComponent<Button>();
        Button Set_Btn6_10 = Set_Btn.transform.GetChild(1).GetComponent<Button>();
        Button Set_Btn11_15 = Set_Btn.transform.GetChild(2).GetComponent<Button>();
        Button Set_Home = GameObject.Find("SetHome").GetComponent<Button>();
        Button Set_Music = GameObject.Find("SetMusic").GetComponent<Button>();
        Button Set_Close = GameObject.Find("SetClose").GetComponent<Button>();
        Button Set_Level = GameObject.Find("SetLevel").GetComponent<Button>();
        Clear_Level_Btn.onClick.AddListener(delegate ()
        {

            OnClearBackLevelBtnClick(Clear_Level_Btn);
        });
        Over_Level_Btn.onClick.AddListener(delegate ()
        {

            OnOverBackLevelBtnClick(Over_Level_Btn);
        });
        Over_Restart_Btn.onClick.AddListener(delegate ()
        {

            OnRestartLevelBtnClick(Over_Restart_Btn);
        });
        Clear_Restart_Btn.onClick.AddListener(delegate ()
        {

            OnRestartLevelBtnClick(Clear_Restart_Btn);
        });
        Over_Home_Btn.onClick.AddListener(delegate()
        {
            OnBackHomeBtnClick(Over_Home_Btn);
        });
        Clear_Home_Btn.onClick.AddListener(delegate ()
        {
            OnBackHomeBtnClick(Clear_Home_Btn);
        });
        Next_Level_Btn.onClick.AddListener(delegate ()
        {
            OnNextLevelBtnClick(Next_Level_Btn);
        });
        Set_Btn1_5.onClick.AddListener(delegate ()
        {
            Ass.Instance.Set_Open_Menu();
        });
        Set_Btn6_10.onClick.AddListener(delegate ()
        {
            Ass.Instance.Set_Open_Menu();
        });
        Set_Btn11_15.onClick.AddListener(delegate ()
        {
            Ass.Instance.Set_Open_Menu();
        });
        Set_Close.onClick.AddListener(delegate ()
        {
            Ass.Instance.Set_Close_Menu();
        });
        Set_Level.onClick.AddListener(delegate ()
        {
            OnSetLevelBtnClick(Set_Level);
        });
        Set_Home.onClick.AddListener(delegate ()
        {
            OnSetHomeBtnClick(Set_Home);
        });

    }

    private void OnClearBackLevelBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        Ass.Instance.Save_Data();
        Ass.Instance.Set_Star();
        Ass.Instance.Load_Level();
        Ass.Instance._iNow_Level = 0;
        Ass.Instance.Save_Data();

        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnOverBackLevelBtnClick(Button Click_Btn)
    {
        
        Debug.Log(Click_Btn.name);
        Ass.Instance._sClear_Type = "fail";
        Ass.Instance.Load_Level();
        Ass.Instance. _iNow_Level = 0;
        Ass.Instance.Save_Data();
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnRestartLevelBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new GameState(m_Manager), "GameScene");
        
    }
    private void OnBackHomeBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        if (Ass.Instance._sClear_Type!="fail")
        {
            Ass.Instance.Set_Star();
        }
        
        Ass.Instance.Load_Level();
        Ass.Instance._iNow_Level = 0;
        Ass.Instance.Save_Data();
        m_Manager.SetState(new MainState(m_Manager), "MainScene");

    }
    private void OnNextLevelBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Ass.Instance.Set_Star();
        Ass.Instance.Load_Level();
        Ass.Instance._iNow_Level += 1;
        Ass.Instance.Save_Data();
        m_Manager.SetState(new GameState(m_Manager), "GameScene");
    }

    private void OnSetHomeBtnClick(Button Clicl_Btn)
    {
        Ass.Instance._iNow_Level = 0;
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnSetLevelBtnClick(Button Clicl_Btn)
    {
        Ass.Instance._iNow_Level = 0;
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
}
