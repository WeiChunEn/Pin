using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LimitState : ISceneState
{
    private GameObject m_Limit_Record;
    private GameObject m_Limit_Now_Name; //這次玩的人名
    private int m_Limit_Now_Record;//這次的分數
    public bool _bCan_Write;//判斷分數有沒有比排行的高
    public LimitState(SceneStateManager Manager) : base(Manager)
    {
        this.StateName = "LimitState";
    }
    public override void StateBegin()
    {
        m_Limit_Record = GameObject.Find("Limit_Record");
        m_Limit_Now_Name = GameObject.Find("Input_Name");
        //取得按鈕
        Find_Btn();
        Ass.Instance.Initinal();

        Ass.Instance.Load_Data();
        Ass.Instance.Sort_Limit_Record();
        Set_Record();

    }
    public override void StateUpdate()
    {
        Ass.Instance.Update();
    }

    private void Find_Btn()
    {

        Button Limit_Restart_Btn = GameObject.Find("LimitRestart").GetComponent<Button>();
        Button Limit_Home_Btn = GameObject.Find("LimitHome").GetComponent<Button>();
        Button Limit_Write_Record_Yes = GameObject.Find("Yes").GetComponent<Button>();
        Button Limit_Write_Record_No = GameObject.Find("No").GetComponent<Button>();
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
        Limit_Write_Record_Yes.onClick.AddListener(delegate ()
        {

            Write_Score();
        });

    }
    /// <summary>
    /// 把有紀錄的分數寫到紀錄欄上
    /// </summary>
    public void Set_Record()
    {
        for (int i = 0; i < 8; i++)
        {
            m_Limit_Record.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = Ass.Instance._sAll_Limit_Record[i];
            m_Limit_Record.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Ass.Instance._iAll_Limit_Int[i].ToString();
        }
    }
    public void Write_Score()
    {
        m_Limit_Now_Record = Int32.Parse(GameObject.Find("PointText").GetComponent<TextMeshProUGUI>().text);
        //m_Limit_Now_Record = Ass.Instance._iLimit_Record;
        if (m_Limit_Now_Record > Ass.Instance._iAll_Limit_Int[7])
        {
            _bCan_Write = true;
            Ass.Instance._sAll_Limit_Record[7] = m_Limit_Now_Name.GetComponent<TMP_InputField>().text;
            Ass.Instance._iAll_Limit_Int[7] = m_Limit_Now_Record;
            Ass.Instance.Sort_Limit_Record();
            Set_Record();
        }
        else
        {
            _bCan_Write = false;
        }
        

    }
    private void OnSetHomeBtnClick(Button Clicl_Btn)
    {
        Ass.Instance._iNow_Level = 0;
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnRestartLimitBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Ass.Instance.Save_Data();
        m_Manager.SetState(new LimitState(m_Manager), "LimitScene");

    }
    private void OnBackHomeBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);

        Ass.Instance.Save_Data();
        Ass.Instance._iNow_Level = 0;
        m_Manager.SetState(new MainState(m_Manager), "MainScene");

    }


}
