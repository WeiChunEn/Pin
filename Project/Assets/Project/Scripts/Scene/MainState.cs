using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainState : ISceneState
{
    public MainState(SceneStateManager Manager):base(Manager)
    {
        this.StateName = "MainScene";
    }
    public override void StateBegin()
    {
        //取得按鈕
        Find_Btn();
        
    }
    private void Find_Btn()
    {
        Button Start_Btn = GameObject.Find("Start_Btn").GetComponent<Button>();
        Button Limit_Btn = GameObject.Find("Limit_Btn").GetComponent<Button>();
        Button Shop_Btn = GameObject.Find("Shop_Btn").GetComponent<Button>();
        Button Leave_Btn = GameObject.Find("Leave_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Start_Btn.onClick.AddListener(() => OnLevelBtnClick(Start_Btn));
        Limit_Btn.onClick.AddListener(() => OnLimitBtnClick(Limit_Btn));
        Shop_Btn.onClick.AddListener(() => OnShopBtnClick(Shop_Btn));
        Leave_Btn.onClick.AddListener(() => OnLeaveBtnClick(Leave_Btn));
        Sound_Btn.onClick.AddListener(() => OnSoundBtnClick(Sound_Btn));
    }
    private void OnLevelBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new LevelState(m_Manager), "LevelScene");
    }
    private void OnShopBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new ShopState(m_Manager), "ShopScene");
    }
    private void OnLimitBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new LimitState(m_Manager), "LimitScene");
    }
    private void OnLeaveBtnClick(Button Click_Btn)
    {
        Debug.Log(Click_Btn.name);
        Application.Quit();
    }
    private void OnSoundBtnClick(Button Click_Btn)
    {
        if(Click_Btn.gameObject.GetComponent<Image>().sprite.name == "SoundOn")
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOff");
        }
        else
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOn");
        }
        
    }


   
}
