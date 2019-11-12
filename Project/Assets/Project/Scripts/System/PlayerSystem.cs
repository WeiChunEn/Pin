using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : GameSystem
{
    private int m_Player_Point;

    public PlayerSystem(Ass ass):base(ass)
    {
        Initialize();
    }
    public override void Initialize()
    {
        m_Player_Point = m_Ass._iPlayer_Point;
    }

}
