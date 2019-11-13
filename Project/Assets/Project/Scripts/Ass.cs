using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Ass
{
    private GameObject m_Pin;    //射出的針
    private GameObject m_Spawn; //針的射出點
    public GameObject _gGameCanvas; //遊戲關卡的Canvas
    public GameObject _gGameOver_Panel; //GameOver的Panel
    public GameObject _gGameClear_Panel; //GameClear的Panel
    public GameObject _gCan_Shoot;  //判斷能不能發射的
    public GameObject _gPoint_Text; //關卡分數
    public Rotater_System m_Rotater_System = null;
    private PlayerSystem m_Player_Ststem = null;
    private LevelSystem m_Level_System = null;
    public bool _bGame_Start;
    public int _iPin_Num;

    public int _iNow_Level;
    public string[] _sClear_Level = new string[15];
    public string[,] _sLevel_Star = new string[15, 3];
    public string _sClear_Type;

    public int _iPlayer_Point;
    public int _iLevel_Point;
    //private enum Clear_Type
    //{
    //    fail,
    //    one,
    //    two,
    //    three
    //}
    //public string _sClear_Type;

    //Singleton
    private static Ass _instance;
    public static Ass Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Ass();
            return _instance;
        }
    }
    private Ass() { }

    public void Initinal()
    {
        _bGame_Start = false;
        m_Pin = Resources.Load<GameObject>("Prefebs/Pin");
        _gGameCanvas = GameObject.Find("GameCanvas");
        _gGameOver_Panel = GameObject.Find("GameOver");
        _gGameClear_Panel = GameObject.Find("GameClear");
        
        if (_gGameOver_Panel&& _gGameClear_Panel) 
        {
            _gGameOver_Panel.SetActive(false);
            _gGameClear_Panel.SetActive(false);
        }
        m_Level_System = new LevelSystem(this);
        m_Player_Ststem = new PlayerSystem(this);
        m_Rotater_System = new Rotater_System(this);
        _gPoint_Text = GameObject.Find("PointText");
        m_Spawn = GameObject.Find("Spawn");
        _gCan_Shoot = GameObject.Find("CanShoot");



    }
    public void Update()
    {
   
        if (_bGame_Start == true )
        {

            InputProcess();
            
            m_Rotater_System.Update();
            
        }





    }
    public void Release()
    {
       
        m_Spawn = null;
        _gGameCanvas = null;
        _gGameOver_Panel = null;
        _gGameClear_Panel = null;
        _gPoint_Text = null;
    }
    private void InputProcess()
    {
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)

		                 if (Input.touchCount == 1 && _gCan_Shoot.tag == "true")
                        {
                            Create_Pin();

                        }

#else

        if (Input.GetButtonDown("Fire1") && _gCan_Shoot.tag == "true")
        {
            Create_Pin();
            if(_iPin_Num==1)
            {
               
                m_Pin.tag = "Last";
            }
            
        }

#endif

    }

    public GameObject Create_Pin()
    {
        _iPin_Num--;
        
        _gCan_Shoot.tag = "false";
        return UnityEngine.Object.Instantiate(m_Pin, m_Spawn.transform.position, m_Spawn.transform.rotation, m_Spawn.transform);

    }

    public void Set_Pin_Num()
    {
        switch (_iNow_Level)
        {
            case 1:
                _iPin_Num = 10;
                break;
        }
    }

    public void Load_Level()
    {
        Debug.Log(_sClear_Type);
        m_Level_System.Level_End(_sClear_Type);
        for (int i = 0; i < 15; i++)
        {
            _sClear_Level[i] = m_Level_System._sClear_Level[i];
            //_sClear_Level[i]="";
            for (int j = 0; j < 3; j++)
            {
                //_sLevel_Star[i, j] = "";
                _sLevel_Star[i, j] = m_Level_System._sLevel_Star[i, j];
            }
        }
    }

    public void GameOver()
    {
        _gGameOver_Panel.SetActive(true);
        _gGameCanvas.GetComponent<Canvas>().sortingOrder = 1;
        _bGame_Start = false;
        _iNow_Level = 0;
        _sClear_Type = "fail";
        

    }
    public void GameClear()
    {
        
        _gGameClear_Panel.SetActive(true);
        _gGameCanvas.GetComponent<Canvas>().sortingOrder = 1;
        _bGame_Start = false;
        Set_Star();
        _iNow_Level = 0;
        



    }

    public void Set_Star()
    {
        _iLevel_Point = Int32.Parse(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
        
        switch (_iNow_Level)
        {
            case 1:
                if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 90)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 2:
                if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 90)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 3:
                if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 90)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 4:
                if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 90)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 5:
                if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 90)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;


        }
    }
}
