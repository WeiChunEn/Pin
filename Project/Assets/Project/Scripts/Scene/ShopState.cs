using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopState : ISceneState
{

    private GameObject m_Player_Point;
    private GameObject m_Buy_Window;
    private GameObject m_Check_Window;
    private GameObject m_Protected;
    private AudioSource m_audioSource;
    public ShopState(SceneStateManager Manager):base(Manager)
    {
        this.StateName = "ShopScene";
       
    }

    public override void StateBegin()
    {
        m_Buy_Window = GameObject.Find("Buy_Window");
        m_Check_Window = GameObject.Find("Check_Window");
        m_Protected = GameObject.Find("Protected");
        m_Protected.SetActive(false);
        m_audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        //取得按鈕
        Find_Btn();
        m_Buy_Window.SetActive(false);
        m_Check_Window.SetActive(false);
        m_Player_Point = GameObject.Find("Player_Point");
        m_Player_Point.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Player_Point").ToString();
        

    }

   
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Button Level_Btn = GameObject.Find("Select_Level_Btn").GetComponent<Button>();
        Button Buy_Btn = GameObject.Find("Buy").GetComponent<Button>();
        Button Small_Btn = GameObject.Find("Small").GetComponent<Button>();
        Button Big_Btn = GameObject.Find("Big").GetComponent<Button>();
        Button Close_Btn = GameObject.Find("Close").GetComponent<Button>();
        Button No_Btn = GameObject.Find("No").GetComponent<Button>();
        Home_Btn.onClick.AddListener(delegate ()
        {
           
            OnHomeBtnClick(Home_Btn);
        });
        Sound_Btn.onClick.AddListener(() => OnSoundBtnClick(Sound_Btn));
        Level_Btn.onClick.AddListener(() => OnLevelBtnClick(Level_Btn));
        Buy_Btn.onClick.AddListener(() => OnBuyBtnClick(Buy_Btn));
        Small_Btn.onClick.AddListener(() => OnMoneyBtnClick(Small_Btn));
        Big_Btn.onClick.AddListener(() => OnMoneyBtnClick(Big_Btn));
        Close_Btn.onClick.AddListener(() => OnCloseBtnClick(Close_Btn));
        No_Btn.onClick.AddListener(() => OnNoBtnClick(No_Btn));
        Debug.Log(Home_Btn.name);
    }

    private void OnHomeBtnClick(Button Click_Btn)
    {
       
        Debug.Log(Click_Btn.name);
        m_Protected.SetActive(true);
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnLevelBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Protected.SetActive(true);
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnSoundBtnClick(Button Click_Btn)
    {
        if (Click_Btn.gameObject.GetComponent<Image>().sprite.name == "SoundOn")
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOff");
            m_audioSource.Stop();
        }
        else
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOn");
            m_audioSource.Play();
        }

    }

    private void OnBuyBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Buy_Window.SetActive(true);
    }
    private void OnCloseBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Buy_Window.SetActive(false);
    }
    private void OnMoneyBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Check_Window.SetActive(true);
    }
    private void OnNoBtnClick(Button Click_Btn)
    {
        m_Check_Window.SetActive(false);
    }

}
