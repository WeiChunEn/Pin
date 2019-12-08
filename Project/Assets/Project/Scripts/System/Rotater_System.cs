using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Rotater_System : GameSystem
{

    public Rotater_System(Ass ass) : base(ass)
    {
        Initialize();
    }
    private float _fSpeed;
    public int m_Level_Point;
    private GameObject m_Pin_Num;
    private GameObject m_Level_Point_Text;
    public GameObject m_Rotater;
    private GameObject m_Ball;
    private GameObject[] m_Rotater_Array = new GameObject[15];
    private GameObject m_Intro;
    public GameObject _gRotate_Speed;
    private GameObject _gLimit_Rotater;
    private Button m_Close_Intro;
    private Button m_Game_Over;

    // Use this for initialization
    public override void Initialize()
    {
        m_Level_Point = 0;

        if (m_Ass._iNow_Level != 0)
        {
            for (int i = 0; i < 15; i++)
            {
                m_Rotater_Array[i] = GameObject.Find("Level" + (i + 1).ToString());

                if ((i + 1) != m_Ass._iNow_Level)
                {
                    if (m_Rotater_Array[i])
                    {

                        m_Rotater_Array[i].SetActive(false);

                    }

                }
            }
        }

        if (m_Ass._iNow_Level == 1 || m_Ass._iNow_Level == 6 || m_Ass._iNow_Level == 11 || m_Ass._iNow_Level == 14 || m_Ass._iNow_Level == 15 || m_Ass._iNow_Level == -1)
        {
            m_Ass._bCountDown_Start = false;
            m_Intro = GameObject.Find("Intro");
            m_Close_Intro = GameObject.Find("Close").gameObject.GetComponent<Button>();
            m_Close_Intro.onClick.AddListener(delegate ()
            {
                Count_Down_Start();
            });
        }
        else
        {
            m_Ass._bCountDown_Start = true;
        }
        m_Rotater = GameObject.Find("Point");
        m_Ball = GameObject.Find("Ball");
        m_Pin_Num = GameObject.Find("Pin_Num");
        m_Level_Point_Text = GameObject.Find("PointText");
        _gRotate_Speed = GameObject.Find("RotaterSpeed");





    }

    // Update is called once per frame
    public override void Update()
    {


        _fSpeed = Int32.Parse(_gRotate_Speed.transform.GetChild(0).name);
        if (m_Rotater)
        {
            if (m_Ass._iNow_Level != -1)
            {
                m_Rotater.name = m_Ass._iNow_Level.ToString();
                m_Rotater.transform.Rotate(0, 0, _fSpeed * Time.deltaTime);
            }
            else if (m_Ass._iNow_Level == -1)
            {
                //_gLimit_Rotater = m_Rotater;
                //_gLimit_Rotater.transform.Rotate(0, 0, _fSpeed * Time.deltaTime);
                Set_Limit_Ball();
            }

            if (m_Ass._iPin_Num < 100)
            {
                m_Pin_Num.GetComponent<TextMeshPro>().text = m_Ass._iPin_Num.ToString();
            }
            else if (m_Ass._iPin_Num > 50)
            {
                m_Pin_Num.GetComponent<TextMeshPro>().text = "∞";
            }

            
            if (m_Ball.tag == "Over")
            {
                m_Ass.GameOver();
            }
            else if (m_Ball.tag == "Clear")
            {
                m_Ass.GameClear();
            }


        }


    }
    public override void Release()
    {
        m_Intro = null;
        m_Close_Intro = null;
        m_Rotater = null;
        m_Pin_Num = null;
        m_Level_Point_Text = null;
        m_Ball = null;
        m_Rotater_Array = null;

    }
    private void Count_Down_Start()
    {
        if (m_Intro)
        {
            m_Intro.SetActive(false);
            m_Ass._bCountDown_Start = true;
        }




    }

    private void Set_Limit_Ball()
    {
        for(int i= 0; i < 9; i++)
        {
            m_Rotater.transform.GetChild(i).transform.Rotate(0, 0, _fSpeed * Time.deltaTime);
        }
        switch ((int)m_Ass._fGame_Time)
        {
            case 180:
                m_Rotater.transform.GetChild(0).gameObject.SetActive(true);
                
                break;
            case 160:
                m_Rotater.transform.GetChild(1).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 140:
                m_Rotater.transform.GetChild(2).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 120:
                m_Rotater.transform.GetChild(3).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 100:
                m_Rotater.transform.GetChild(4).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 80:
                m_Rotater.transform.GetChild(5).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 60:
                m_Rotater.transform.GetChild(6).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 40:
                m_Rotater.transform.GetChild(7).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(6).gameObject.SetActive(false);
                break;
            case 20:
                m_Rotater.transform.GetChild(8).gameObject.SetActive(true);
                m_Rotater.transform.GetChild(7).gameObject.SetActive(false);
                break;

        }
    }

}
