using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]

public class Pin_System : MonoBehaviour
{
    
    public float _fSpeed;
    public GameObject _gCheck_Point;
    public GameObject _gPoint_Text;
    private float _fBall_Degree;
    private Rigidbody2D _rb;
    // Use this for initialization
    void Start()
    {
        
        _fSpeed = 5.0f;
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _fSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ball")
        {
           
            _gPoint_Text = GameObject.Find("PointText");
           
            
            _gCheck_Point.transform.SetParent(col.transform);
            _rb.velocity = Vector2.zero;
            transform.SetParent(col.transform);
           
            _fBall_Degree = Mathf.Atan2(_gCheck_Point.transform.localPosition.y, _gCheck_Point.transform.localPosition.x) * 180 / Mathf.PI;
            print(_fBall_Degree);
            Set_Point(col);


        }
        if(col.tag == "Pin")
        {
            print("GameOver");
        }
    }
    public void Set_Point(Collider2D col)
    {
        int tmp;
        switch(col.name)
        {
            case "1":
                if(-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if(-180.0 <= _fBall_Degree && _fBall_Degree <= -90.0 || 90.0 <= _fBall_Degree && _fBall_Degree <= 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
        }
    }
}
