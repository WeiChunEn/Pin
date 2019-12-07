using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class Ass
{
    private GameObject m_Pin;    //射出的針
    private GameObject m_Spawn; //針的射出點
    public GameObject _gGameCanvas; //遊戲關卡的Canvas
    public GameObject _gGameOver_Panel; //GameOver的Panel
    public GameObject _gGameClear_Panel; //GameClear的Panel
    public GameObject _gLimit_Panel;    //極限的Panel
    public GameObject _gCheck_Limit; //判斷是否為極限關卡
    public GameObject _gCan_Shoot;  //判斷能不能發射的
    public GameObject _gPoint_Text; //關卡分數
    public GameObject _gCountDown; //倒數計時
    public GameObject _gGame_Time; //遊戲時間物件
    public GameObject _gSet_Btn; //設定的按鈕
    public GameObject _gSet_Menu; //設定的介面
    public GameObject _gLimit_Record;//極限紀錄
    private GameObject _gSkill_Freeze;
    private GameObject _gSkill_Gray;
    private GameObject _gSkill_Add;
    private GameObject _gSkill_Black;
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
    public string _sLimit_Record;       //這次極限人名
    public int _iLimit_Record;              //這次極限分數
    public string[] _sAll_Limit_Record = new string[8]; //全部極限人名Array
    public int[] _iAll_Limit_Int = new int[8]; //全部極限分數Array
    public float _fCount_Down;          //倒數秒數
    public int _iPlayer_Point;      //玩家分數
    public int _iLevel_Point;     //關卡分數
    public float _fGame_Time;        //遊戲時間
    private int[] m_Skill_Time = new int[3]; //技能發動的時間
    private int[] m_Skill_Over_Time = new int[3]; //技能結束的時間
    private string[] m_14_Skill = new string[2];  //  14關技能\
    private string[] m_15_Skill = new string[3];  // 15關技能


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
        _fGame_Time = 60;

        _gCheck_Limit = GameObject.Find("Limit");
        if (_gCheck_Limit)
        {
            _iNow_Level = -1;
        }

        _gGameCanvas = GameObject.Find("GameCanvas");
        _gGameOver_Panel = GameObject.Find("GameOver");
        _gGameClear_Panel = GameObject.Find("GameClear");
        _gSet_Menu = GameObject.Find("Set_Menu");
        if (_gGameOver_Panel && _gGameClear_Panel)
        {
            _gGameOver_Panel.SetActive(false);
            _gGameClear_Panel.SetActive(false);
            _gSet_Menu.SetActive(false);
            m_Pin.tag = "Pin";
        }
        m_Level_System = new LevelSystem(this);
        m_Player_Ststem = new PlayerSystem(this);
        m_Rotater_System = new Rotater_System(this);
        _gPoint_Text = GameObject.Find("PointText");
        m_Spawn = GameObject.Find("Spawn");
        _gCountDown = GameObject.Find("CountDown");
        _gCan_Shoot = GameObject.Find("CanShoot");
        _gGame_Time = GameObject.Find("GameTime");
        _gSet_Btn = GameObject.Find("Set_Btn");
        if (_iNow_Level <= 5)
        {
            if (_gSet_Btn)
            {
                _gSet_Btn.transform.GetChild(0).gameObject.SetActive(true);
            }

            m_Pin = Resources.Load<GameObject>("Prefebs/Pin1-5");
        }
        else if (_iNow_Level <= 10)
        {

            if (_gSet_Btn)
            {
                _gSet_Btn.transform.GetChild(1).gameObject.SetActive(true);
            }
            m_Pin = Resources.Load<GameObject>("Prefebs/Pin6-10");
        }
        else if (_iNow_Level <= 13)
        {
            _fGame_Time = 60;
            if (_gSet_Btn)
            {
                _gSet_Btn.transform.GetChild(2).gameObject.SetActive(true);
            }
            m_Pin = Resources.Load<GameObject>("Prefebs/Pin11-13");
        }
        else if (_iNow_Level <= 15)
        {
            _fGame_Time = 80;
            if (_iNow_Level == 14)
            {
                m_Skill_Time = new int[2];
                m_Skill_Over_Time = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    m_Skill_Time[i] = UnityEngine.Random.Range(10, (int)_fGame_Time);
                    Debug.Log(m_Skill_Time[i]);
                    m_14_Skill[i] = "";
                }
                _gSkill_Gray = GameObject.Find("Gray");
                _gSkill_Freeze = GameObject.Find("Freeze");
                _gSkill_Gray.SetActive(false);
                _gSkill_Freeze.SetActive(false);
            }
            else
            {
                m_Skill_Time = new int[3];
                m_Skill_Over_Time = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    m_Skill_Time[i] = UnityEngine.Random.Range(10, (int)_fGame_Time);
                    Debug.Log(m_Skill_Time[i]);
                    m_15_Skill[i] = "";
                }
                _gSkill_Add = GameObject.Find("Add");
                _gSkill_Black = GameObject.Find("Black");
                _gSkill_Add.SetActive(false);
                _gSkill_Black.SetActive(false);
            }

            
            if (_gSet_Btn)
            {
                _gSet_Btn.transform.GetChild(3).gameObject.SetActive(true);
            }
            m_Pin = Resources.Load<GameObject>("Prefebs/Pin14-15");
        }
        if (_iNow_Level == -1)
        {
            _fGame_Time = 180;
            m_Pin = Resources.Load<GameObject>("Prefebs/PinLimit");
            _gLimit_Panel = GameObject.Find("Limit_Menu");
            _gLimit_Panel.SetActive(false);
            _gSet_Menu.SetActive(false);
            m_Pin.tag = "Pin";
        }

    }
    public void Update()
    {
        Debug.Log(m_15_Skill[0] + "1");
        Debug.Log(m_15_Skill[1] + "2");
        Debug.Log(m_15_Skill[2] + "3");
        m_Player_Ststem.Update();

        if (_bCountDown_Start == true)
        {
            _fCount_Down += Time.deltaTime;
            if (_iNow_Level >= 6 && _iNow_Level <= 15)
            {

                if (_fGame_Time > 60 && _fGame_Time <= 70 || _fGame_Time <= 10)
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + "0" + ((int)_fGame_Time % 60).ToString();

                }
                else if (_fGame_Time == 60)
                {

                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + "0" + "0";
                }
                else
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + ((int)_fGame_Time % 60).ToString();

                }
                if (_fGame_Time <= 20)
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().color = new Color(229f / 255f, 30f / 255f, 38f / 255f);
                }
            }
            if (_fCount_Down <= 1.0f)
            {

                _gCountDown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "3";
            }
            else if (_fCount_Down <= 2.0f)
            {
                _gCountDown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "2";
            }
            else if (_fCount_Down <= 3.0f)
            {
                _gCountDown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "1";
            }
            else
            {
                _gCountDown.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "GO~";
            }
            if (_fCount_Down >= 4.0f)
            {
                Count_Down();
            }
        }



        if (_bGame_Start == true)
        {

            InputProcess();

            m_Rotater_System.Update();

            _iLevel_Point = Int32.Parse(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
            if (_iNow_Level >= 6 && _iNow_Level <= 15)
            {
                _fGame_Time -= Time.deltaTime;
                if (_fGame_Time > 60 && _fGame_Time <= 70 || _fGame_Time <= 10)
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + "0" + ((int)_fGame_Time % 60).ToString();

                }
                else if (_fGame_Time == 60)
                {

                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + "0" + "0";
                }
                else
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + ((int)_fGame_Time % 60).ToString();

                }
                if (_fGame_Time <= 20)
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().color = new Color(229f / 255f, 30f / 255f, 38f / 255f);
                }
                if (_iNow_Level == 14)
                {
                    for (int i = 0; i < 2; i++)
                    {

                        if (m_Skill_Time[i] == Convert.ToInt32(_fGame_Time))
                        {



                            Skill_Start(i);
                            m_Skill_Time[i] = -1;
                            Debug.Log((m_Skill_Over_Time[i]));
                        }
                        if (m_Skill_Over_Time[i] == Convert.ToInt32(_fGame_Time))
                        {

                            m_Skill_Over_Time[i] = -1;
                            m_14_Skill[i] = "Finish";

                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (m_14_Skill[i] == "true")
                        {
                            if (i == 0)
                            {
                                _gSkill_Freeze.SetActive(true);
                            }
                            else if (i == 1)
                            {
                                _gSkill_Gray.SetActive(true);
                            }
                        }
                        else
                        {
                            if (i == 0)
                            {
                                _gSkill_Freeze.SetActive(false);
                            }
                            else if (i == 1)
                            {
                                _gSkill_Gray.SetActive(false);
                            }
                        }
                    }


                }
                else if (_iNow_Level == 15)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (m_Skill_Time[i] == Convert.ToInt32(_fGame_Time))
                        {



                            Skill_Start(i);
                            m_Skill_Time[i] = -1;
                            Debug.Log((m_Skill_Over_Time[i]));
                        }
                        if (m_Skill_Over_Time[i] == Convert.ToInt32(_fGame_Time))
                        {

                            m_Skill_Over_Time[i] = -1;
                            m_15_Skill[i] = "Finish";
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        if (m_15_Skill[i] == "true")
                        {
                            if (i == 0)
                            {
                                _gSkill_Black.SetActive(true);
                            }
                            else if (i == 1)
                            {

                                int tmpSpeed = Convert.ToInt32(m_Rotater_System._gRotate_Speed.transform.GetChild(0).name);
                                if (tmpSpeed == 100||tmpSpeed==-100)
                                {
                                    tmpSpeed *= 2;
                                }
                                m_Rotater_System._gRotate_Speed.transform.GetChild(0).name = tmpSpeed.ToString();





                            }
                            else if (i == 2)
                            {
                                _gSkill_Add.SetActive(true);
                            }
                        }
                        else if(m_15_Skill[i] == "Finish")
                        {
                            if (i == 0)
                            {
                                _gSkill_Black.SetActive(false);
                            }
                            else if (i == 1)
                            {
                                int tmpSpeed = Convert.ToInt32(m_Rotater_System._gRotate_Speed.transform.GetChild(0).name);
                                if (tmpSpeed == 200 || tmpSpeed == -200)
                                {
                                    tmpSpeed /= 2;
                                }
                                m_Rotater_System._gRotate_Speed.transform.GetChild(0).name = tmpSpeed.ToString();

                            }
                            else if (i == 2)
                            {
                                _gSkill_Add.SetActive(false);
                            }
                        }
                    }
                }
            }
            else if (_iNow_Level == -1)
            {
                _fGame_Time -= Time.deltaTime;
                if (_fGame_Time > 60 && _fGame_Time <= 70 || _fGame_Time <= 10)
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + "0" + ((int)_fGame_Time % 60).ToString();

                }
                else if (_fGame_Time == 60)
                {

                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + "0" + "0";
                }
                else
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().text = "0" + ((int)_fGame_Time / 60).ToString() + ":" + ((int)_fGame_Time % 60).ToString();

                }
                if (_fGame_Time <= 20)
                {
                    _gGame_Time.GetComponent<TextMeshProUGUI>().color = new Color(229f / 255f, 30f / 255f, 38f / 255f);
                }
            }
            Debug.Log(_iLevel_Point);
            if ((_fGame_Time <= 0 || _iLevel_Point < 0) && _iNow_Level != -1)
            {
                Debug.Log(_iLevel_Point);
                GameOver();
            }
            else if (_iNow_Level == -1 && (_fGame_Time <= 0 || _iLevel_Point < 0))
            {
                GameClear();
            }


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
            Touch touch;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                 if(!EventSystem.current.currentSelectedGameObject)
                 {
                      if(m_14_Skill[0]!=true)
                    {
                        Create_Pin();
                        if (_iPin_Num == 1)
                        {

                            m_Pin.tag = "Last";
                        }
                    }
            }

         }

#else

        if (Input.GetButtonDown("Fire1") && _gCan_Shoot.tag == "true")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject);
            if (!EventSystem.current.currentSelectedGameObject)
            {
                if (m_14_Skill[0] != "true")
                {
                    Create_Pin();
                    if (_iPin_Num == 1)
                    {

                        m_Pin.tag = "Last";
                    }
                }



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
        if (m_15_Skill[2] != "true")
        {
            _iPin_Num--;
        }
        else
        {
            _iPin_Num++;
        }
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
                _iPin_Num = 8;
                break;
            case 2:
                _iPin_Num = 10;
                break;
            case 3:
                _iPin_Num = 10;
                break;
            case 4:
                _iPin_Num = 12;
                break;
            case 5:
                _iPin_Num = 15;
                break;
            case 6:
                _iPin_Num = 10;
                break;
            case 7:
                _iPin_Num = 12;
                break;
            case 8:
                _iPin_Num = 12;
                break;
            case 9:
                _iPin_Num = 15;
                break;
            case 10:
                _iPin_Num = 15;
                break;
            case 11:
                _iPin_Num = 12;
                break;
            case 12:
                _iPin_Num = 15;
                break;
            case 13:
                _iPin_Num = 12;
                break;
            case 14:
                _iPin_Num = 10;
                break;
            case 15:
                _iPin_Num = 8;
                break;
            case -1:
                _iPin_Num = 1000;
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
            case "Clear":
                if (_iNow_Level != 15)
                {

                    _sClear_Level[_iNow_Level] = "true";
                }



                break;
            case "one":

                _sLevel_Star[_iNow_Level - 1, 0] = "true";

                if (_iNow_Level != 15)
                {

                    _sClear_Level[_iNow_Level] = "true";
                }
                break;
            case "two":
                _sLevel_Star[_iNow_Level - 1, 0] = "true";
                _sLevel_Star[_iNow_Level - 1, 1] = "true";

                if (_iNow_Level != 15)
                {

                    _sClear_Level[_iNow_Level] = "true";
                }
                break;
            case "three":
                _sLevel_Star[_iNow_Level - 1, 0] = "true";
                _sLevel_Star[_iNow_Level - 1, 1] = "true";
                _sLevel_Star[_iNow_Level - 1, 2] = "true";

                if (_iNow_Level != 15)
                {

                    _sClear_Level[_iNow_Level] = "true";
                }
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

        _sClear_Type = "fail";
        if (_iNow_Level != -1)
        {
            _gGameOver_Panel.SetActive(true);
            _gGameCanvas.GetComponent<Canvas>().sortingOrder = 1;
        }
        else if (_iNow_Level == -1)
        {
            _gLimit_Panel.SetActive(true);
            _gCheck_Limit.GetComponent<Canvas>().sortingOrder = 1;
        }
        _bGame_Start = false;




    }
    /// <summary>
    /// 通關介面
    /// </summary>
    public void GameClear()
    {


        if (_iNow_Level != -1)
        {
            _gGameClear_Panel.SetActive(true);
            _gGameCanvas.GetComponent<Canvas>().sortingOrder = 1;

        }
        else if (_iNow_Level == -1)
        {
            _gLimit_Panel.SetActive(true);
            _gCheck_Limit.GetComponent<Canvas>().sortingOrder = 1;
        }
        _bGame_Start = false;

        Set_Star();
        Load_Level();
        _gGameClear_Panel.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = _iLevel_Point.ToString();
        _iPlayer_Point += _iLevel_Point;
        Save_Data();
        switch (_sClear_Type)
        {
            case "Clear":
                _gGameClear_Panel.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "one":
                _gGameClear_Panel.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "two":
                _gGameClear_Panel.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "three":
                _gGameClear_Panel.transform.GetChild(5).gameObject.SetActive(true);
                break;
        }

    }

    /// <summary>
    /// 倒數計時
    /// </summary>
    public void Count_Down()
    {


        _gCountDown.SetActive(false);
        _bGame_Start = true;
        if (_iNow_Level != -1)
        {
            _gGameCanvas.GetComponent<Canvas>().sortingOrder = -1;
        }
        else if (_iNow_Level == -1)
        {
            _gCheck_Limit.GetComponent<Canvas>().sortingOrder = -1;
        }

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
                if (_iLevel_Point < 50)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 70)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 2:
                if (_iLevel_Point < 50)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 70)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 100)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 3:
                if (_iLevel_Point < 50)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 80)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 110)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 4:
                if (_iLevel_Point < 120)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 150)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 180)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 5:
                if (_iLevel_Point < 150)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 180)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 200)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 6:
                if (_iLevel_Point < 70)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 90)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 120)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 7:
                if (_iLevel_Point < 120)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 150)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 180)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 8:
                if (_iLevel_Point < 240)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 270)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 300)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 9:
                if (_iLevel_Point < 300)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 330)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 360)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 10:
                if (_iLevel_Point < 330)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 360)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 400)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 11:
                if (_iLevel_Point < 180)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 220)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 250)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 12:
                if (_iLevel_Point < 200)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 240)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 280)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 13:
                if (_iLevel_Point < 80)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 120)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 150)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 14:
                if (_iLevel_Point < 50)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 70)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 100)
                {
                    _sClear_Type = "two";
                }
                else
                {
                    _sClear_Type = "three";
                }
                break;
            case 15:
                if (_iLevel_Point < 40)
                {
                    _sClear_Type = "Clear";
                }
                else if (_iLevel_Point < 60)
                {
                    _sClear_Type = "one";
                }
                else if (_iLevel_Point < 80)
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

    public void Set_Open_Menu()
    {
        if (_bGame_Start == true)
        {
            _gSet_Menu.SetActive(true);
            _bGame_Start = false;
            if (_iNow_Level != -1)
            {
                _gGameCanvas.GetComponent<Canvas>().sortingOrder = 4;
            }
            else if (_iNow_Level == -1)
            {
                _gCheck_Limit.GetComponent<Canvas>().sortingOrder = 4;
            }

        }

    }
    public void Set_Close_Menu()
    {
        if (_bGame_Start == false && _gSet_Menu.activeSelf == true)
        {
            _gSet_Menu.SetActive(false);
            _bGame_Start = true;
            if (_iNow_Level != -1)
            {
                _gGameCanvas.GetComponent<Canvas>().sortingOrder = -1;
            }
            else if (_iNow_Level == -1)
            {
                _gCheck_Limit.GetComponent<Canvas>().sortingOrder = -1;
            }
        }
    }

    /// <summary>
    /// 14-15關技能
    /// </summary>
    public void Skill_Start(int Skill_Num)
    {
        if (_iNow_Level == 14)
        {

            int tmp = UnityEngine.Random.Range(0, 2);
            if (tmp == 0 && (m_14_Skill[tmp] == "Finish" || m_14_Skill[tmp] == "true"))
            {
                m_14_Skill[tmp + 1] = "true";
                m_Skill_Over_Time[tmp + 1] = m_Skill_Time[Skill_Num] - 10;
            }
            else if (tmp == 1 && (m_14_Skill[tmp] == "Finish" || m_14_Skill[tmp] == "true"))
            {
                m_14_Skill[tmp - 1] = "true";
                m_Skill_Over_Time[tmp - 1] = m_Skill_Time[Skill_Num] - 10;
            }
            else
            {
                m_14_Skill[tmp] = "true";
                m_Skill_Over_Time[tmp] = m_Skill_Time[Skill_Num] - 10;
            }


            Debug.Log(m_14_Skill[0]);
            Debug.Log(m_14_Skill[1]);


        }
        else if (_iNow_Level == 15)
        {
           
            int tmp = UnityEngine.Random.Range(0, 3);
           
            if (tmp == 0 && (m_15_Skill[tmp] == "Finish"|| m_15_Skill[tmp] == "true"))
            {
                Debug.Log("Styart1");
                tmp = UnityEngine.Random.Range(1, 3);
                if (tmp == 1 && (m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
                {
                   
                    m_15_Skill[tmp+1] = "true";
                    m_Skill_Over_Time[tmp+1] = m_Skill_Time[Skill_Num] - 10;
                    Debug.Log("Styart111");
                }
                else if (tmp == 2 && (m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
                {
                    m_15_Skill[tmp-1] = "true";
                    m_Skill_Over_Time[tmp-1] = m_Skill_Time[Skill_Num] - 10;
                    Debug.Log("Styart111");
                }
                else
                {
                    m_15_Skill[tmp] = "true";
                    m_Skill_Over_Time[tmp] = m_Skill_Time[Skill_Num] - 10;
                }
            }
            else if (tmp == 1 && (m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
            {
                Debug.Log("Styart2");
                tmp = 0;
                if (tmp == 0 && (m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
                {
                    tmp = 2;
                    m_15_Skill[tmp ] = "true";
                    m_Skill_Over_Time[tmp] = m_Skill_Time[Skill_Num] - 10;
                    Debug.Log("Styart222");
                }
                else if (tmp == 0 && (m_15_Skill[tmp] != "Finish" || m_15_Skill[tmp] != "true"))
                {
                    m_15_Skill[tmp] = "true";
                    m_Skill_Over_Time[tmp] = m_Skill_Time[Skill_Num] - 10;
                    Debug.Log("Styart222");
                }


            }
            else if (tmp == 2 &&( m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
            {
                Debug.Log("Styart3");
                tmp = UnityEngine.Random.Range(0, 2);
                if (tmp == 1 && (m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
                {
                    m_15_Skill[tmp - 1] = "true";
                    m_Skill_Over_Time[tmp - 1] = m_Skill_Time[Skill_Num] - 10;
                    Debug.Log("Styart333");
                }
                else if (tmp == 0 && (m_15_Skill[tmp] == "Finish" || m_15_Skill[tmp] == "true"))
                {
                    m_15_Skill[tmp + 1] = "true";
                    m_Skill_Over_Time[tmp + 1] = m_Skill_Time[Skill_Num] - 10;
                    Debug.Log("Styart333");
                }
                else
                {
                    m_15_Skill[tmp] = "true";
                    m_Skill_Over_Time[tmp] = m_Skill_Time[Skill_Num] - 10;
                }

            }
            else
            {
                Debug.Log(tmp);
                m_15_Skill[tmp ] = "true";
                m_Skill_Over_Time[tmp] = m_Skill_Time[Skill_Num] - 10;
                Debug.Log("Styart444");
            }
          
            

        }
    }
    /// <summary>
    /// 存取資料
    /// </summary>
    public void Save_Data()
    {
        if (_iNow_Level != -1)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PlayerPrefs.SetString("PlayerStar" + i.ToString() + "_" + j.ToString(), _sLevel_Star[i, j]);

                }
                PlayerPrefs.SetString("PlayerLevel" + i.ToString(), _sClear_Level[i]);

            }
        }
        else
        {

            for (int i = 0; i < 8; i++)
            {
                PlayerPrefs.SetString("Player_Limit_Name" + i.ToString(), _sAll_Limit_Record[i]);
                PlayerPrefs.SetInt("Player_Limit_Score" + i.ToString(), _iAll_Limit_Int[i]);
            }
        }
        PlayerPrefs.SetInt("Player_Point", _iPlayer_Point);
    }
    /// <summary>
    /// 排序極限分數
    /// </summary>
    public void Sort_Limit_Record()
    {
        for (int j = 7; j > 0; --j)
            for (int k = 0; k < j; ++k)
            {

                if (_iAll_Limit_Int[k] < _iAll_Limit_Int[k + 1])
                {

                    int tmp2;
                    string tmp3;
                    tmp2 = _iAll_Limit_Int[k];
                    _iAll_Limit_Int[k] = _iAll_Limit_Int[k + 1];
                    _iAll_Limit_Int[k + 1] = tmp2;
                    tmp3 = _sAll_Limit_Record[k];
                    _sAll_Limit_Record[k] = _sAll_Limit_Record[k + 1];
                    _sAll_Limit_Record[k + 1] = tmp3;
                }
            }
    }
    /// <summary>
    /// 讀取資料
    /// </summary>
    public void Load_Data()
    {
        //string tmp;
        //tmp = PlayerPrefs.GetString("Player_Point");
        //_iPlayer_Point = Int32.Parse(tmp);
        _iPlayer_Point = PlayerPrefs.GetInt("Player_Point");
        if (_iNow_Level != -1)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _sLevel_Star[i, j] = PlayerPrefs.GetString("PlayerStar" + i.ToString() + "_" + j.ToString());

                }
                _sClear_Level[i] = PlayerPrefs.GetString("PlayerLevel" + i.ToString());

            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (PlayerPrefs.GetString("Player_Limit_Name" + i.ToString()) != "")
                {

                    _sAll_Limit_Record[i] = PlayerPrefs.GetString("Player_Limit_Name" + i.ToString());
                    _iAll_Limit_Int[i] = PlayerPrefs.GetInt("Player_Limit_Score" + i.ToString());
                }
                else
                {

                    _sAll_Limit_Record[i] = "未命名";
                    _iAll_Limit_Int[i] = Int32.Parse("0");
                }

            }

        }

    }
}
