using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopState : ISceneState
{
   
    public ShopState(SceneStateManager Manager):base(Manager)
    {
        this.StateName = "ShopScene";
       
    }

    public override void StateBegin()
    {
        
        //取得按鈕
        Find_Btn();
        

    }

   
    private void Find_Btn()
    {

        Button Home_Btn = GameObject.Find("Home_Btn").GetComponent<Button>();
        Button Sound_Btn = GameObject.Find("Sound_Btn").GetComponent<Button>();
        Home_Btn.onClick.AddListener(delegate ()
        {
           
            OnHomeBtnClick(Home_Btn);
        });
        Sound_Btn.onClick.AddListener(() => OnSoundBtnClick(Sound_Btn));
        Debug.Log(Home_Btn.name);
    }

    private void OnHomeBtnClick(Button Click_Btn)
    {
       
        Debug.Log(Click_Btn.name);
        m_Manager.SetState(new MainState(m_Manager), "MainScene");
    }
    private void OnSoundBtnClick(Button Click_Btn)
    {
        if (Click_Btn.gameObject.GetComponent<Image>().sprite.name == "SoundOn")
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOff");
        }
        else
        {
            Click_Btn.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Element/SoundOn");
        }

    }

}
