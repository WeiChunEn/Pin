using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelState : ISceneState
{

    private GameObject m_FirstPage;
    private GameObject m_SecondPage;
    private GameObject m_ThirdPage;
    private GameObject[,] m_Level_Star_Array;
    private GameObject[] m_Level_Array;
    private Button m_First_Next_Page_Btn;
    private Button m_Second_Next_Page_Btn;
    private Button m_Second_Last_Page_Btn;
    private Button m_Third_Last_Page_Btn;

    public LevelState(SceneStateManager Manager) : base(Manager)
    {
       
        this.StateName = "LevelScene";
        Ass.Instance.Initinal();
    }
    public override void StateBegin()
    {
        
        m_FirstPage = GameObject.Find("FirstPage");
        m_SecondPage = GameObject.Find("SecondPage");
        m_ThirdPage = GameObject.Find("ThirdPage");
        Find_Btn();
        Find_Level();
        m_SecondPage.SetActive(false);
        m_ThirdPage.SetActive(false);
        //取得按鈕


    }
    private void Find_Level()
    {
        m_Level_Star_Array = new GameObject[15, 3];
        m_Level_Array = new GameObject[15];
        Debug.Log(Ass.Instance._sClear_Level[0]);
        for (int i = 0; i < 15; i++)
        {
            m_Level_Array[i] = GameObject.Find((i + 1).ToString());
            if (Ass.Instance._sClear_Level[i] == "true" || Ass.Instance._sClear_Level[i] == "false")
            {
                m_Level_Array[i].tag = Ass.Instance._sClear_Level[i];
            }
            if (m_Level_Array[i].tag == "true")
            {
                Debug.Log(m_Level_Array[i].tag);
                m_Level_Array[i].GetComponent<Button>().interactable = true;
            }
           

           
            for (int j = 0; j < 3; j++)
            {
                m_Level_Star_Array[i, j] = GameObject.Find((i + 1).ToString()).transform.GetChild(j).gameObject;
                if (Ass.Instance._sLevel_Star[i, j] == "true")
                {
                    m_Level_Star_Array[i, j].tag = Ass.Instance._sLevel_Star[i, j];
                }
                // m_Level_Star_Array[i, j].tag = Ass.Instance._sLevel_Star[i, j];
                if (m_Level_Star_Array[i, j].tag == "true")
                {
                    m_Level_Star_Array[i, j].SetActive(true);
                }
               


               
            }
        }
    }
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
        Button Shop_Btn = GameObject.Find("Shop_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Button Level_1_Btn = GameObject.Find("1").GetComponent<Button>();
        m_First_Next_Page_Btn = GameObject.Find("First_Next_Page_Btn").GetComponent<Button>();
        m_Second_Next_Page_Btn = GameObject.Find("Second_Next_Page_Btn").GetComponent<Button>();
        m_Second_Last_Page_Btn = GameObject.Find("Second_Last_Page_Btn").GetComponent<Button>();
        m_Third_Last_Page_Btn = GameObject.Find("Third_Last_Page_Btn").GetComponent<Button>();
        Home_Btn.onClick.AddListener(() => OnHomeBtnClick(Home_Btn));
        Shop_Btn.onClick.AddListener(() => OnShopBtnClick(Shop_Btn));
        Level_1_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_1_Btn));
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

    private void OnLevel_BtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Ass.Instance._iNow_Level = Int32.Parse(Click_Btn.name);
        
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
