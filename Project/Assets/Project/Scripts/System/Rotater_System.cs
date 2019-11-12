using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Rotater_System : GameSystem
{

    public Rotater_System(Ass ass) : base(ass)
    {
        Initialize();
    }
    private float _fSpeed;
    public int m_Level_Point;
    private GameObject m_Level_Point_Text;
    private GameObject m_Rotater;
    private GameObject[] m_Rotater_Array = new GameObject[15];
    private Button m_Close_Intro;
    private Button m_Game_Over;
    // Use this for initialization
    public override void Initialize()
    {
        m_Level_Point = 0;

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
        if (m_Ass._iNow_Level == 1 || m_Ass._iNow_Level == 6 || m_Ass._iNow_Level == 11 || m_Ass._iNow_Level == 14 || m_Ass._iNow_Level == 15)
        {
            m_Close_Intro = GameObject.Find("Close").gameObject.GetComponent<Button>();
            m_Close_Intro.onClick.AddListener(delegate ()
            {

                Game_Start();
            });
        }
        m_Rotater = GameObject.Find("Point");
        m_Level_Point_Text = GameObject.Find("PointText");
        _fSpeed = 100.0f;




    }

    // Update is called once per frame
    public override void Update()
    {

   

        if (m_Rotater)
        {
            m_Rotater.name = m_Ass._iNow_Level.ToString();
            m_Rotater.transform.Rotate(0, 0, _fSpeed * Time.deltaTime);


        }


    }
    private void Game_Start()
    {
        m_Ass._bGame_Start = true;
    }

}
