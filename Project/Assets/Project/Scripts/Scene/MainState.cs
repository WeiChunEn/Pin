using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainState : ISceneState
{

    private GameObject m_LeaderBoard;
    private Button Leader_Btn;
    public MainState(SceneStateManager Manager) : base(Manager)
    {
        this.StateName = "MainScene";
    }
    public override void StateBegin()
    {
        //取得按鈕
        Find_Btn();
        m_LeaderBoard = GameObject.Find("LeaderBoard");


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
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnShopBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new ShopState(m_Manager), "ShopScene");
    }
    private void OnLimitBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
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
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOff");
        }
        else
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOn");
        }

    }
    private void OnLeaderBtnClick(Button Click_Btn)
    {
        if (m_LeaderBoard.tag == "false")
        {
            Debug.Log(32221);
            
            m_LeaderBoard.GetComponent<Animator>().SetTrigger("Open");
           


        }
        else if (m_LeaderBoard.tag == "true")
        {
            Debug.Log(32222341);
            
            m_LeaderBoard.GetComponent<Animator>().SetTrigger("Close");
           


        }
        Leader_Btn.interactable = false;
    }

}




