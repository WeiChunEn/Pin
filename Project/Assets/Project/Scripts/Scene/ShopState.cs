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
    private AudioSource m_Buy_Audio;
    private List<GameObject> Effect_List = new List<GameObject>();
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
        m_Buy_Audio = GameObject.Find("Buy_Audio").GetComponent<AudioSource>();
        //取得按鈕
        Find_Btn();
        m_Buy_Window.SetActive(false);
        m_Check_Window.SetActive(false);
        m_Player_Point = GameObject.Find("Player_Point");
        m_Player_Point.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Player_Point").ToString();
        Ass.Instance.Initinal();
        for (int i = 0; i < 5; i++)
        {
            Ass.Instance._sHave_Effect[i] = PlayerPrefs.GetString("Player_Have_Effect" + i.ToString());

        }
        Ass.Instance._sEquip_Effect = PlayerPrefs.GetString("Player_Equip_Effect");

    }

    public override void StateUpdate()
    {
        Set_Effect_Btn();
       
    }
    private void Find_Btn()
    {
        for(int i = 0; i <5;i++)
        {
            GameObject tmp = GameObject.Find( (i+1).ToString());
            Effect_List.Add(tmp);
            
           
        }
        //Debug.Log(Effect_List.Count);


        if (Ass.Instance._sHave_Effect[0] == "")
        {
            Effect_List[0].GetComponent<Button>().onClick.AddListener(() => Buy_Effect_Btn(0));
        }
        else
        {
            Effect_List[0].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(0));
        }
        if (Ass.Instance._sHave_Effect[1] == "")
        {
            Effect_List[1].GetComponent<Button>().onClick.AddListener(() => Buy_Effect_Btn(1));
        }
        else
        {
            Effect_List[1].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(1));
        }
        if (Ass.Instance._sHave_Effect[2] == "")
        {
            Effect_List[2].GetComponent<Button>().onClick.AddListener(() => Buy_Effect_Btn(2));
        }
        else
        {
            Effect_List[2].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(2));
        }
        if (Ass.Instance._sHave_Effect[3] == "")
        {
            Effect_List[3].GetComponent<Button>().onClick.AddListener(() => Buy_Effect_Btn(3));
        }
        else
        {
            Effect_List[3].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(3));
        }
        if (Ass.Instance._sHave_Effect[4] == "")
        {
            Effect_List[4].GetComponent<Button>().onClick.AddListener(() => Buy_Effect_Btn(4));
        }
        else
        {
            Effect_List[4].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(4));
        }

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
            m_audioSource.Pause();
        }
        else
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOn");
            m_audioSource.Play();
        }

    }

    private void OnBuyBtnClick(Button Click_Btn)
    {
        //m_Buy_Audio.Play();
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
    private void Buy_Effect_Btn(int Num)
    {
       
        m_Buy_Audio.Play();
        Ass.Instance._sHave_Effect[Num] = "UnEquip";
        int tmp = int.Parse(m_Player_Point.GetComponent<TextMeshProUGUI>().text);
        tmp -= int.Parse(Effect_List[Num].transform.GetChild(0).GetComponent<Text>().text);
        Debug.Log(tmp);
        Ass.Instance._iPlayer_Point = tmp;
        PlayerPrefs.SetInt("Player_Point", Ass.Instance._iPlayer_Point);
        m_Player_Point.GetComponent<TextMeshProUGUI>().text = tmp.ToString();


        // Effect_List[0].GetComponent<Button>().onClick.AddListener(() => Buy_Effect_Btn(0));


        Effect_List[Num].GetComponent<Button>().onClick.RemoveAllListeners();
            Effect_List[Num].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(Num));
       



        // Effect_List[Num].GetComponent<Button>().onClick.AddListener(() => Equip_Effect_Btn(Num));
    }
    private void Equip_Effect_Btn(int Num)
    {
        Set_Another_Effect();
        Ass.Instance._sHave_Effect[Num] = "Equip";
        
    }
    /// <summary>
    /// 調整其他擁有的特效狀態
    /// </summary>
    private void Set_Another_Effect()
    {
        for (int i = 0; i < Effect_List.Count; i++)
        {
            if (Ass.Instance._sHave_Effect[i]=="Equip")
            {
                Ass.Instance._sHave_Effect[i] = "UnEquip";
            }
        }
    }
    private void Set_Effect_Btn()
    {
       
        for (int i =0;i< Effect_List.Count; i++)
        {

            Debug.Log(Ass.Instance._sHave_Effect[i] + i.ToString());
            if (int.Parse(m_Player_Point.GetComponent<TextMeshProUGUI>().text) >= int.Parse(Effect_List[i].transform.GetChild(0).GetComponent<Text>().text))
            {
                if(Ass.Instance._sHave_Effect[i] == "")
                {
                    Effect_List[i].GetComponent<Button>().interactable = true;
                }
               
            }
            else
            {
                if (Ass.Instance._sHave_Effect[i] == "")
                {
                    Effect_List[i].GetComponent<Button>().interactable = false;
                }
                
            }
            if(Ass.Instance._sHave_Effect[i] != "")
            {
                if (Ass.Instance._sHave_Effect[i] == "Equip")
                {
                    SpriteState tmp = new SpriteState
                    {
                        disabledSprite = Resources.Load<Sprite>("Shop/Equiping"),
                        pressedSprite = null
                    };
                    Effect_List[i].GetComponent<Button>().spriteState = tmp;
                    Effect_List[i].GetComponent<Button>().interactable = false;
                   
                    // Effect_List[i].GetComponent<Button>().spriteState.pressedSprite = Resources.Load<Sprite>("Shop/Equiping");
                }
                else if (Ass.Instance._sHave_Effect[i] != "Equip" && Ass.Instance._sHave_Effect[i] == "UnEquip")
                {
                    Effect_List[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Shop/CanEquip");
                    SpriteState tmp = new SpriteState
                    {
                        disabledSprite = Resources.Load<Sprite>("Shop/Equiping"),
                        pressedSprite = null
                    };
                    Effect_List[i].GetComponent<Button>().spriteState = tmp;
                    Effect_List[i].GetComponent<Button>().interactable = true;

                }
            }
           
                PlayerPrefs.SetString("Player_Have_Effect" + i.ToString(), Ass.Instance._sHave_Effect[i]);
           
                if (Ass.Instance._sHave_Effect[i] == "Equip")
                {
                 Ass.Instance._sEquip_Effect = (i + 1).ToString();
                }
            PlayerPrefs.SetString("Player_Equip_Effect", Ass.Instance._sEquip_Effect);

        }
    }

}
