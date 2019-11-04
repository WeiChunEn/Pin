using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass
{
    private GameObject m_Pin;
    private GameObject m_Spawn;
    private Pin_System m_Pin_System = null;
    private Rotater_System m_Rotater_System = null;
    private PlayerSystem m_Player_Ststem = null;
    public int _iNow_Level;
    public string[] _sClear_Level = new string[15];
    public string[,] _sLevel_Star=new string[15, 3];
    public string _sClear_Type;
    //private enum Clear_Type
    //{
    //    fail,
    //    one,
    //    two,
    //    three
    //}
    //public string _sClear_Type;
    private LevelSystem m_Level_System = null;
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
        
        m_Pin = Resources.Load<GameObject>("Prefebs/Pin");
        m_Spawn = GameObject.Find("Spawn");
         m_Level_System = new LevelSystem(this);
        //m_Pin_System = new Pin_System(this);
        m_Player_Ststem = new PlayerSystem(this);
        
    }
    public void Update()
    {
        InputProcess();
    }
    private void InputProcess()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Create_Pin();

        }
    }

    public GameObject Create_Pin()
    {
        return UnityEngine.Object.Instantiate(m_Pin, m_Spawn.transform.position, m_Spawn.transform.rotation, m_Spawn.transform);
    }

    //public void Level_End()
    //{
    //    _sClear_Level[_iNow_Level]= "true";
    //    switch(_sClear_Type)
    //    {
    //        case "fail":
    //            break;
    //        case "one":
    //            _sLevel_Star[_iNow_Level,0] = "true";
    //            break;
    //        case "two":
    //            _sLevel_Star[_iNow_Level, 1] = "true";
    //            break;
    //        case "three":
    //            _sLevel_Star[_iNow_Level, 2] = "true";
    //            break;
    //    }
    //}
    public void Load_Level()
    {
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
}
