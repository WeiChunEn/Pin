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
    public GameObject _gCountDown; //倒數計時
    public Rotater_System m_Rotater_System = null;
    private PlayerSystem m_Player_Ststem = null;
    private LevelSystem m_Level_System = null;
    public bool _bGame_Start;
    public bool _bCountDown_Start;
    public int _iPin_Num;
    public int _iNow_Level;
    public string[] _sClear_Level = new string[15];     //關卡Array
    public string[,] _sLevel_Star = new string[15, 3];  //關卡星星Array
    public string _sClear_Type;         //通關狀態
    public float _fCount_Down;          //倒數秒數
    public int _iPlayer_Point;      //玩家分數
    public int _iLevel_Point;     //關卡分數


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
        _bCountDown_Start = false;
        _fCount_Down = 0.0f;
        m_Pin = Resources.Load<GameObject>("Prefebs/Pin");
        _gGameCanvas = GameObject.Find("GameCanvas");
        _gGameOver_Panel = GameObject.Find("GameOver");
        _gGameClear_Panel = GameObject.Find("GameClear");

        if (_gGameOver_Panel && _gGameClear_Panel)
        {
            _gGameOver_Panel.SetActive(false);
            _gGameClear_Panel.SetActive(false);
            m_Pin.tag = "Pin";
        }
        m_Level_System = new LevelSystem(this);
        m_Player_Ststem = new PlayerSystem(this);
        m_Rotater_System = new Rotater_System(this);
        _gPoint_Text = GameObject.Find("PointText");
        m_Spawn = GameObject.Find("Spawn");
        _gCountDown = GameObject.Find("CountDown");
        _gCan_Shoot = GameObject.Find("CanShoot");



    }
    public void Update()
    {
        if (_bCountDown_Start == true)
        {
            _fCount_Down += Time.deltaTime;
        }

        if (_fCount_Down >= 4.0f)
        {
            Count_Down();
        }

        if (_bGame_Start == true)
        {

            InputProcess();

            m_Rotater_System.Update();

        }





    }
    /// <summary>
    /// End
    /// </summary>
    public void Release()
    {

        m_Spawn = null;
        _gGameCanvas = null;
        _gGameOver_Panel = null;
        _gGameClear_Panel = null;
        _gPoint_Text = null;
    }
    /// <summary>
    /// 偵測輸入
    /// </summary>
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
            if (_iPin_Num == 1)
            {

                m_Pin.tag = "Last";
            }

        }

#endif

    }

    /// <summary>
    /// 生成針
    /// </summary>
    /// <returns></returns>
    public GameObject Create_Pin()
    {
        _iPin_Num--;

        _gCan_Shoot.tag = "false";
        return UnityEngine.Object.Instantiate(m_Pin, m_Spawn.transform.position, m_Spawn.transform.rotation, m_Spawn.transform);

    }

    /// <summary>
    /// 設定每關針的數量
    /// </summary>
    public void Set_Pin_Num()
    {
        switch (_iNow_Level)
        {
            case 1:
                _iPin_Num = 5;
                break;
            case 2:
                _iPin_Num = 5;
                break;
            case 3:
                _iPin_Num = 5;
                break;
            case 4:
                _iPin_Num = 5;
                break;
            case 5:
                _iPin_Num = 5;
                break;
        }
    }

    /// <summary>
    /// 設定關卡通過以及星星
    /// </summary>
    /// <param name="_sClear_Type">通過的狀態</param>
    public void Level_End(string _sClear_Type)
    {

        switch (_sClear_Type)
        {
            case "fail":
                break;
            case "one":
                _sLevel_Star[_iNow_Level - 1, 0] = "true";
                _sClear_Level[_iNow_Level] = "true";
                break;
            case "two":
                _sLevel_Star[_iNow_Level - 1, 0] = "true";
                _sLevel_Star[_iNow_Level - 1, 1] = "true";
                _sClear_Level[_iNow_Level] = "true";
                break;
            case "three":
                _sLevel_Star[_iNow_Level - 1, 0] = "true";
                _sLevel_Star[_iNow_Level - 1, 1] = "true";
                _sLevel_Star[_iNow_Level - 1, 2] = "true";
                _sClear_Level[_iNow_Level] = "true";
                break;
        }
    }

    /// <summary>
    /// 讀取關卡通過的狀態
    /// </summary>
    public void Load_Level()
    {
        Level_End(_sClear_Type);


    }

    /// <summary>
    /// 失敗介面
    /// </summary>
    public void GameOver()
    {
        _gGameOver_Panel.SetActive(true);
        _gGameCanvas.GetComponent<Canvas>().sortingOrder = 1;
        _bGame_Start = false;



    }
    /// <summary>
    /// 通關介面
    /// </summary>
    public void GameClear()
    {

        _gGameClear_Panel.SetActive(true);
        _gGameCanvas.GetComponent<Canvas>().sortingOrder = 1;
        _bGame_Start = false;

    }
    /// <summary>
    /// 重玩一次
    /// </summary>
    public void Game_Restart()
    {

    }
    /// <summary>
    /// 倒數計時
    /// </summary>
    public void Count_Down()
    {


        _gCountDown.SetActive(false);
        _bGame_Start = true;
        _gGameCanvas.GetComponent<Canvas>().sortingOrder = -1;
        Set_Pin_Num();
        _bCountDown_Start = false;
        _fCount_Down = 0.0f;


    }
    /// <summary>
    /// 存取關卡星星
    /// </summary>
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

    /// <summary>
    /// 存取資料
    /// </summary>
    public void Save_Data()
    {
        //PlayerPrefs.SetString("Level"+_iNow_Level.ToString(),)
    }
}
