using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelState : ISceneState
{
   
    private GameObject m_FirstPage;
    private GameObject m_SecondPage;
    private GameObject m_ThirdPage;
    private Button m_First_Next_Page_Btn;
    private Button m_Second_Next_Page_Btn;
    private Button m_Second_Last_Page_Btn;
    private Button m_Third_Last_Page_Btn;
    public LevelState(SceneStateManager Manager) : base(Manager)
    {
        this.StateName = "LevelScene";
    }
    public override void StateBegin()
    {
        m_FirstPage = GameObject.Find("FirstPage");
        m_SecondPage = GameObject.Find("SecondPage");
        m_ThirdPage = GameObject.Find("ThirdPage");
        Find_Btn();
        m_SecondPage.SetActive(false);
        m_ThirdPage.SetActive(false);
        //取得按鈕
       

    }
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
        Button Shop_Btn = GameObject.Find("Shop_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Button Level_1_Btn = GameObject.Find("Level_1").GetComponent<Button>();
        m_First_Next_Page_Btn = GameObject.Find("First_Next_Page_Btn").GetComponent<Button>();
        m_Second_Next_Page_Btn = GameObject.Find("Second_Next_Page_Btn").GetComponent<Button>();
        m_Second_Last_Page_Btn = GameObject.Find("Second_Last_Page_Btn").GetComponent<Button>();
        m_Third_Last_Page_Btn = GameObject.Find("Third_Last_Page_Btn").GetComponent<Button>();
        Home_Btn.onClick.AddListener(() => OnHomeBtnClick(Home_Btn));
        Shop_Btn.onClick.AddListener(() => OnShopBtnClick(Shop_Btn));
        Level_1_Btn.onClick.AddListener(() => OnLevel_1_BtnClick(Level_1_Btn));
        Sound_Btn.onClick.AddListener(() => OnSoundBtnClick(Sound_Btn));
        m_First_Next_Page_Btn.onClick.AddListener(() => First_Next_PageBtnClick());
        m_Second_Next_Page_Btn.onClick.AddListener(() => Second_Next_PageBtnClick());
        m_Second_Last_Page_Btn.onClick.AddListener(() => Second_Last_PageBtnClick());
        m_Third_Last_Page_Btn.onClick.AddListener(() => Third_Last_PageBtnClick());
        // Debug.Log(Home_Btn.name);
    }

    public void OnHomeBtnClick(Button Click_Btn)
    {

        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnShopBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new ShopState(m_Manager), "ShopScene");
    }

    private void OnLevel_1_BtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new GameState(m_Manager), "GameScene");
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
    private void First_Next_PageBtnClick()
    {
        m_FirstPage.SetActive(false);
        m_SecondPage.SetActive(true);

    }
    private void Second_Next_PageBtnClick()
    {
        m_SecondPage.SetActive(false);
        m_ThirdPage.SetActive(true);

    }
    private void Second_Last_PageBtnClick()
    {
        m_FirstPage.SetActive(true);
        m_SecondPage.SetActive(false);

    }
    private void Third_Last_PageBtnClick()
    {
        m_SecondPage.SetActive(true);
        m_ThirdPage.SetActive(false);

    }


}
