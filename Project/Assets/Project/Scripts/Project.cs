using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project
{
    private GameObject m_Pin;
    private GameObject m_Spawn;
    //Singleton
    private static Project _instance;
    public static Project Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Project();
            return _instance;
        }
    }
    private Project() { }

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
