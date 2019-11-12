using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : GameSystem
{
    //private int m_Now_Level;
    //private int m_Now_Level_Star;
    private int _iNow_Level;
    public string[] _sClear_Level = new string[15];
    public string[,] _sLevel_Star = new string[15, 3];
    private enum Clear_Type
    {
        fail,
        one,
        two,
        three
    }
    
    public LevelSystem(Ass ass):base(ass)
    {
        Initialize();
    }
    public override void Initialize()
    {
        _iNow_Level = m_Ass._iNow_Level;
    }

    public void Level_End(string _sClear_Type)
    {
        _sClear_Level[_iNow_Level-1] = "true";
        switch (_sClear_Type)
        {
            case "fail":
                break;
            case "one":
                _sLevel_Star[_iNow_Level, 0] = "true";
                break;
            case "two":
                _sLevel_Star[_iNow_Level, 0] = "true";
                _sLevel_Star[_iNow_Level, 1] = "true";
                break;
            case "three":
                _sLevel_Star[_iNow_Level, 0] = "true";
                _sLevel_Star[_iNow_Level, 1] = "true";
                _sLevel_Star[_iNow_Level, 2] = "true";
                break;
        }
    }
}
