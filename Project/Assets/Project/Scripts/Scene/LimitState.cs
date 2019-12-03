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
    private GameObject m_Limit_Score_Text; //分數文字
    private GameObject m_Can_Write_Text; //告知使用者能不能寫紀錄
    private GameObject m_Write_Record_Menu; //寫紀錄的Menu
    private Button m_Write_Record_Btn; //開啟寫分數欄的按鈕
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
        m_Limit_Score_Text = GameObject.Find("Score");
        m_Write_Record_Btn = GameObject.Find("LimitWrite").GetComponent<Button>();
        m_Write_Record_Menu = GameObject.Find("Set_Record");
        m_Can_Write_Text = GameObject.Find("WriteCheck");
        //取得按鈕
        Find_Btn();
        m_Write_Record_Menu.SetActive(false);
        Ass.Instance.Initinal();

        Ass.Instance.Load_Data();
        Ass.Instance.Sort_Limit_Record();
        Set_Record();

    }
    public override void StateUpdate()
    {
        Ass.Instance.Update();
        m_Limit_Now_Record = Int32.Parse(GameObject.Find("PointText").GetComponent<TextMeshProUGUI>().text);
        m_Limit_Score_Text.GetComponent<TextMeshProUGUI>().text = m_Limit_Now_Record.ToString();
        if (m_Limit_Now_Record >= Ass.Instance._iAll_Limit_Int[7] )
        {
            _bCan_Write = true;
        }
        else
        {
            _bCan_Write = false;
        }
        if(Ass.Instance._bGame_Start==true)
        {
            if (_bCan_Write == true)
            {
                m_Can_Write_Text.GetComponent<Text>().text = "恭喜您可以把分數寫到排行榜上";
                m_Write_Record_Btn.interactable = true;

            }
            else
            {
                m_Can_Write_Text.GetComponent<Text>().text = "很抱歉您的分數不夠格列在排行榜上";
                m_Write_Record_Btn.interactable = false;
            }
        }
        
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
        Limit_Write_Record_No.onClick.AddListener(delegate ()
        {

            m_Write_Record_Menu.SetActive(false);
        });
        m_Write_Record_Btn.onClick.AddListener(delegate ()
        {

            m_Write_Record_Menu.SetActive(true);
        });

    }
    /// <summary>
    /// 把有紀錄的分數寫到紀錄欄上
    /// </summary>
    public void Set_Record()
    {
        for (int i = 0; i < 8; i++)
        {
            m_Limit_Record.transform.GetChild(i).GetComponent<Text>().text = Ass.Instance._sAll_Limit_Record[i];
            m_Limit_Record.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Ass.Instance._iAll_Limit_Int[i].ToString();
        }
    }
    public void Write_Score()
    {
        //m_Limit_Now_Record = Int32.Parse(GameObject.Find("PointText").GetComponent<TextMeshProUGUI>().text);
        //m_Limit_Now_Record = Ass.Instance._iLimit_Record;


        Ass.Instance._sAll_Limit_Record[7] = m_Limit_Now_Name.GetComponent<InputField>().text;
        Ass.Instance._iAll_Limit_Int[7] = m_Limit_Now_Record;
        Ass.Instance.Sort_Limit_Record();
        Set_Record();
        m_Write_Record_Menu.SetActive(false);

        m_Write_Record_Btn.interactable = false;
        m_Can_Write_Text.GetComponent<Text>().text = "謝謝您的遊玩，請下次再光臨";
        




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
