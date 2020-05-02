using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameSystem
{
    protected Ass m_Ass = null;
    public GameSystem(Ass ass)
    {
        m_Ass = ass;
    }
    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }
}
