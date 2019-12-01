using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// 場景狀態控制者
public class SceneStateManager
{
    private ISceneState m_State;
    private bool m_bRunBegin = false;
    private string m_LoadSceneName;
    private AsyncOperation asyncOperation;
    //private int displayProgress;

    public SceneStateManager()
    { }

    // 設定狀態
    public void SetState(ISceneState State, string LoadSceneName)
    {
        m_LoadSceneName = LoadSceneName;
        //if (LoadSceneName!="")
        //{
        //    m_LoadSceneName = LoadSceneName;
        //}
        //else
        //{
        //    m_LoadSceneName = "StartScene";
        //}
        Debug.Log("SetState:" + State.ToString());

        m_bRunBegin = false;

        // 載入場景
        LoadScene(LoadSceneName);

        // 通知前一個State結束
        if (m_State != null)
        {

            m_State.StateEnd();
        }


        // 設定
        m_State = State;
    }

    // 載入場景
    private void LoadScene(string LoadSceneName)
    {

        //if (LoadSceneName == null || LoadSceneName.Length == 0)
        //    return;
        asyncOperation = SceneManager.LoadSceneAsync(LoadSceneName);

        //SceneManager.LoadSceneAsync(LoadSceneName);
    }

    // 更新
    public void StateUpdate()
    {

        //是否還在載入
        if (!asyncOperation.isDone)
        {
            return;
        }
        //if (Application.isLoadingLevel)
        //{
        //    return;
        //}







        // 通知新的State開始
        if (m_State != null && m_bRunBegin == false)
        {

            m_State.StateBegin();
            m_bRunBegin = true;

        }

        if (m_State != null)
        {

            m_State.StateUpdate();
        }

    }
}
