using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainState : ISceneState
{
    private AudioSource m_Audio;
    private GameObject m_LeaderBoard;
    private GameObject m_Protected;
    private Button Leader_Btn;
    private GameObject m_Limit_Record;
    private string[] m_All_Limit_Record = new string[8]; //全部極限人名Array
    private int[] m_All_Limit_Int = new int[8]; //全部極限分數Array
    public MainState(SceneStateManager Manager) : base(Manager)
    {
        this.StateName = "MainScene";
    }
    public override void StateBegin()
    {
        //PlayerPrefs.DeleteAll();
        //取得按鈕
        Find_Btn();
        m_LeaderBoard = GameObject.Find("LeaderBoard");
        m_Protected = GameObject.Find("Protected");
        m_Limit_Record = GameObject.Find("Limit_Record");
        m_Audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Load_Data();
        Set_Record();
        m_Protected.SetActive(false);

    }
    public override void StateUpdate()
    {
        AnimatorStateInfo info = m_LeaderBoard.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= 1.0f && info.IsName("LeaderBoard_Open") && m_LeaderBoard.tag == "false")
        {
            m_LeaderBoard.tag = "true";
            Leader_Btn.interactable = true;
            

        }
        else if (info.normalizedTime >= 1.0f && info.IsName("LeaderBoard_Close") && m_LeaderBoard.tag == "true")
        {
            m_LeaderBoard.tag = "false";
            Leader_Btn.interactable = true;
            
        }




    }
    private void Find_Btn()
    {
        Button Start_Btn = GameObject.Find("Start_Btn").GetComponent<Button>();
        Button Limit_Btn = GameObject.Find("Limit_Btn").GetComponent<Button>();
        Button Shop_Btn = GameObject.Find("Shop_Btn").GetComponent<Button>();
        Button Leave_Btn = GameObject.Find("Leave_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Leader_Btn = GameObject.Find("LeaderBoard_Btn").GetComponent<Button>();
        Start_Btn.onClick.AddListener(() => OnLevelBtnClick(Start_Btn));
        Limit_Btn.onClick.AddListener(() => OnLimitBtnClick(Limit_Btn));
        Shop_Btn.onClick.AddListener(() => OnShopBtnClick(Shop_Btn));
        Leave_Btn.onClick.AddListener(() => OnLeaveBtnClick(Leave_Btn));
        Sound_Btn.onClick.AddListener(() => OnSoundBtnClick(Sound_Btn));
        Leader_Btn.onClick.AddListener(() => OnLeaderBtnClick(Leader_Btn));
    }
    private void OnLevelBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Protected.SetActive(true);
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnShopBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Protected.SetActive(true);
        m_Manager.SetState(new ShopState(m_Manager), "ShopScene");
    }
    private void OnLimitBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Protected.SetActive(true);
        m_Manager.SetState(new LimitState(m_Manager), "LimitScene");
    }
    private void OnLeaveBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Application.Quit();
    }
    private void OnSoundBtnClick(Button Click_Btn)
    {
        if (Click_Btn.gameObject.GetComponent<Image>().sprite.name == "SoundOn")
        {
            m_Audio.Pause();
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOff");
        }
        else
        {
            m_Audio.Play();
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOn");
        }

    }
    private void OnLeaderBtnClick(Button Click_Btn)
    {
        if (m_LeaderBoard.tag == "false")
        {
            
            
            m_LeaderBoard.GetComponent<Animator>().SetTrigger("Open");
           


        }
        else if (m_LeaderBoard.tag == "true")
        {
            
            
            m_LeaderBoard.GetComponent<Animator>().SetTrigger("Close");
           


        }
        Leader_Btn.interactable = false;
    }


    public void Load_Data()
    {
       
            for (int i = 0; i < 8; i++)
            {
                if (PlayerPrefs.GetString("Player_Limit_Name" + i.ToString()) != "")
                {

                    m_All_Limit_Record[i] = PlayerPrefs.GetString("Player_Limit_Name" + i.ToString());
                    m_All_Limit_Int[i] = PlayerPrefs.GetInt("Player_Limit_Score" + i.ToString());
                }
                else
                {

                    m_All_Limit_Record[i] = "未命名";
                    m_All_Limit_Int[i] = Int32.Parse("0");
                }

            }

        

    }

    public void Set_Record()
    {
        for (int i = 0; i < 8; i++)
        {
            m_Limit_Record.transform.GetChild(i).GetComponent<Text>().text = m_All_Limit_Record[i];
            m_Limit_Record.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = m_All_Limit_Int[i].ToString();
        }
    }

}




