using UnityEngine;
using System;
using System.Collections;

// 遊戲主迴圈
public class GameLoop : MonoBehaviour
{
    // 場景狀態
    SceneStateManager m_SceneStateManager = new SceneStateManager();

    // 
    void Awake()
    {
        // 切換場景不會被刪除
        GameObject.DontDestroyOnLoad(this.gameObject);

       
    }

    // Use this for initialization
    void Start()
    {
        m_SceneStateManager.SetState(new MainState(m_SceneStateManager), "MainScene");
        // 設定起始的場景
        //m_SceneStateManager.SetState(new StartState(m_SceneStateManager), "");
    }

    // Update is called once per frame
    void Update()
    {
        m_SceneStateManager.StateUpdate();
    }
}
