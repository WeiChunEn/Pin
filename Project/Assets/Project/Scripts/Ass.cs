using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass
{
    private GameObject m_Pin;
    private GameObject m_Spawn;
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
}
