using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class LevelState : ISceneState
{

    private GameObject m_FirstPage;
    private GameObject m_SecondPage;
    private GameObject m_ThirdPage;
    private GameObject[,] m_Level_Star_Array;
    private GameObject[] m_Level_Array;
    private GameObject m_Protected;
    public GameObject _gPlayer_Point;
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
        _gPlayer_Point = GameObject.Find("Player_Point");
        m_Protected = GameObject.Find("Protected");
        m_Protected.SetActive(false);
        Ass.Instance.Load_Data();
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
        int tmp_Star_Num = 0;
        for (int i = 0; i < 15; i++)
        {
            m_Level_Array[i] = GameObject.Find((i + 1).ToString());
            if (Ass.Instance._sClear_Level[i] == "true" || Ass.Instance._sClear_Level[i] == "false")
            {
                m_Level_Array[i].tag = Ass.Instance._sClear_Level[i];
            }
            if (m_Level_Array[i].tag == "true")
            {
                
                m_Level_Array[i].GetComponent<Button>().interactable = true;
            }
           

           
            for (int j = 0; j < 3; j++)
            {
                m_Level_Star_Array[i, j] = GameObject.Find((i + 1).ToString()).transform.GetChild(j).gameObject;
                if (Ass.Instance._sLevel_Star[i, j] == "true")
                {
                    m_Level_Star_Array[i, j].tag = Ass.Instance._sLevel_Star[i, j];
                }
                
                if (m_Level_Star_Array[i, j].tag == "true")
                {
                    m_Level_Star_Array[i, j].SetActive(true);
                    tmp_Star_Num++;
                    
                }
               


               
            }
        }
        Ass.Instance._iPlayer_Point = tmp_Star_Num*10;
        _gPlayer_Point.GetComponent<TextMeshProUGUI>().text = Ass.Instance._iPlayer_Point.ToString();
        
        
    }
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
        Button Shop_Btn = GameObject.Find("Shop_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Button Level_1_Btn = GameObject.Find("1").GetComponent<Button>();
        Button Level_2_Btn = GameObject.Find("2").GetComponent<Button>();
        Button Level_3_Btn = GameObject.Find("3").GetComponent<Button>();
        Button Level_4_Btn = GameObject.Find("4").GetComponent<Button>();
        Button Level_5_Btn = GameObject.Find("5").GetComponent<Button>();
        Button Level_6_Btn = GameObject.Find("6").GetComponent<Button>();
        Button Level_7_Btn = GameObject.Find("7").GetComponent<Button>();
        Button Level_8_Btn = GameObject.Find("8").GetComponent<Button>();
        Button Level_9_Btn = GameObject.Find("9").GetComponent<Button>();
        Button Level_10_Btn = GameObject.Find("10").GetComponent<Button>();
        Button Level_11_Btn = GameObject.Find("11").GetComponent<Button>();
        Button Level_12_Btn = GameObject.Find("12").GetComponent<Button>();
        Button Level_13_Btn = GameObject.Find("13").GetComponent<Button>();
        Button Level_14_Btn = GameObject.Find("14").GetComponent<Button>();
        Button Level_15_Btn = GameObject.Find("15").GetComponent<Button>();
        m_First_Next_Page_Btn = GameObject.Find("First_Next_Page_Btn").GetComponent<Button>();
        m_Second_Next_Page_Btn = GameObject.Find("Second_Next_Page_Btn").GetComponent<Button>();
        m_Second_Last_Page_Btn = GameObject.Find("Second_Last_Page_Btn").GetComponent<Button>();
        m_Third_Last_Page_Btn = GameObject.Find("Third_Last_Page_Btn").GetComponent<Button>();
        Home_Btn.onClick.AddListener(() => OnHomeBtnClick(Home_Btn));
        Shop_Btn.onClick.AddListener(() => OnShopBtnClick(Shop_Btn));
        Level_1_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_1_Btn));
        Level_2_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_2_Btn));
        Level_3_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_3_Btn));
        Level_4_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_4_Btn));
        Level_5_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_5_Btn));
        Level_6_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_6_Btn));
        Level_7_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_7_Btn));
        Level_8_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_8_Btn));
        Level_9_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_9_Btn));
        Level_10_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_10_Btn));
        Level_11_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_11_Btn));
        Level_12_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_12_Btn));
        Level_13_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_13_Btn));
        Level_14_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_14_Btn));
        Level_15_Btn.onClick.AddListener(() => OnLevel_BtnClick(Level_15_Btn));
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
        m_Protected.SetActive(true);
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnShopBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Protected.SetActive(true);
        m_Manager.SetState(new ShopState(m_Manager), "ShopScene");
    }

    private void OnLevel_BtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Ass.Instance._iNow_Level = Int32.Parse(Click_Btn.name);
        m_Protected.SetActive(true);
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
