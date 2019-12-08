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
    public GameObject _gBall;
    public GameObject _gCan_Shoot;
    public GameObject _gRotaterSpeed;
    public GameObject _gCheck_Limit;

    private float _fBall_Degree;
    private Rigidbody2D _rb;
    // Use this for initialization
    void Start()
    {
        _gRotaterSpeed = GameObject.Find("RotaterSpeed");
        _gCheck_Limit = GameObject.Find("Limit");
        if (_gCheck_Limit)
        {
            _fSpeed = 60.0f;
        }
        else
        {
            _fSpeed = 5.0f;
        }

        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _fSpeed;

        _gBall = GameObject.Find("Ball");
        _gCan_Shoot = GameObject.Find("CanShoot");


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {

            _gPoint_Text = GameObject.Find("PointText");
            _gCan_Shoot.tag = "true";

            if (_gRotaterSpeed.transform.GetChild(0).tag == "+")
            {
                int tmpSpeed = Convert.ToInt32(_gRotaterSpeed.transform.GetChild(0).name);
                tmpSpeed = -tmpSpeed;
                _gRotaterSpeed.transform.GetChild(0).name = tmpSpeed.ToString();
                _gRotaterSpeed.transform.GetChild(0).tag = "-";
            }
            else if (_gRotaterSpeed.transform.GetChild(0).tag == "-")
            {
                int tmpSpeed = Convert.ToInt32(_gRotaterSpeed.transform.GetChild(0).name);
                tmpSpeed = -tmpSpeed;
                _gRotaterSpeed.transform.GetChild(0).name = tmpSpeed.ToString();
                _gRotaterSpeed.transform.GetChild(0).tag = "+";
            }

            _gCheck_Point.transform.SetParent(col.transform);
            _rb.velocity = Vector2.zero;
            transform.SetParent(col.transform);

            _fBall_Degree = Mathf.Atan2(_gCheck_Point.transform.localPosition.y, _gCheck_Point.transform.localPosition.x) * 180 / Mathf.PI;
            print(_fBall_Degree);
            Set_Point(col);


        }
        if (col.tag == "Pin")
        {
            _gBall.tag = "Over";
            Destroy(gameObject);
        }
        if (gameObject.tag == "Last" && col.tag == "Ball")
        {
            _gBall.tag = "Clear";
        }
    }
    public void Set_Point(Collider2D col)
    {
        int tmp;
        switch (col.name)
        {
            case "1":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree <= -90.0 || 90.0 <= _fBall_Degree && _fBall_Degree <= 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "2":
                if (-150.0 <= _fBall_Degree && _fBall_Degree <= -30.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-30.0 < _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -150.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "3":
                if (-150.0 <= _fBall_Degree && _fBall_Degree <= -30.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-30.0 < _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -150.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "4":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "5":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "6":
                if (-150.0 <= _fBall_Degree && _fBall_Degree <= -30.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-30.0 < _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -150.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "7":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "8":
                if (-89.0 < _fBall_Degree && _fBall_Degree < -18.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-18.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 < _fBall_Degree && _fBall_Degree <= 54.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (54.0 < _fBall_Degree && _fBall_Degree <= 124.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (124.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -161.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-161.0 <= _fBall_Degree && _fBall_Degree <= -89.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "9":
                if (-89.0 < _fBall_Degree && _fBall_Degree < -18.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-18.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 < _fBall_Degree && _fBall_Degree <= 54.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (54.0 < _fBall_Degree && _fBall_Degree <= 124.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (124.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -161.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-161.0 <= _fBall_Degree && _fBall_Degree <= -89.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "10":
                if (-89.0 < _fBall_Degree && _fBall_Degree < -18.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-18.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 < _fBall_Degree && _fBall_Degree <= 54.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (54.0 < _fBall_Degree && _fBall_Degree <= 124.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (124.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -161.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-161.0 <= _fBall_Degree && _fBall_Degree <= -89.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "11":
                if (-116.0 < _fBall_Degree && _fBall_Degree < -64.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-167.0 <= _fBall_Degree && _fBall_Degree <= -116.0 )
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -167.0 || 140.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 140.0 )
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (40 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 <= _fBall_Degree && _fBall_Degree <= 40.0 || -12.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-64.0 <= _fBall_Degree && _fBall_Degree < -12.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "12":
                if (-116.0 < _fBall_Degree && _fBall_Degree < -64.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-167.0 <= _fBall_Degree && _fBall_Degree <= -116.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -167.0 || 140.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 140.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (40 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 <= _fBall_Degree && _fBall_Degree <= 40.0 || -12.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-64.0 <= _fBall_Degree && _fBall_Degree < -12.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "13":
                if (51.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-24.0 <= _fBall_Degree && _fBall_Degree <= -9.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-9.0 < _fBall_Degree && _fBall_Degree <=0.0 || -9.0 < _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-51.0 <= _fBall_Degree && _fBall_Degree < -9.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-140 < _fBall_Degree && _fBall_Degree <= -51.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree <= -140.0 || 167.0 <= _fBall_Degree && _fBall_Degree <= 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 <= _fBall_Degree && _fBall_Degree < 168.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "14":
                if (-170.0 <= _fBall_Degree && _fBall_Degree <= -156.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (152.0 <= _fBall_Degree && _fBall_Degree <= 168.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree <= -170.0 || 168.0 < _fBall_Degree && _fBall_Degree <= 180.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (126.0 <= _fBall_Degree && _fBall_Degree < 152.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (89 <= _fBall_Degree && _fBall_Degree < 126.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-34.0 < _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree < 89.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-156.0 <= _fBall_Degree && _fBall_Degree <= -34.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "15":
                if (82.0<= _fBall_Degree && _fBall_Degree <= 94.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (72.0 <= _fBall_Degree && _fBall_Degree < 82.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (59.0 <= _fBall_Degree && _fBall_Degree < 72.0 )
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (39.0 <= _fBall_Degree && _fBall_Degree < 59.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (19 <= _fBall_Degree && _fBall_Degree < 39.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-75.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree < 19.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -75.0 || 94.0 < _fBall_Degree && _fBall_Degree <= 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Minus":
                tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                tmp -= 10;
                _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                break;
            case "Limit_1":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree <= -90.0 || 90.0 <= _fBall_Degree && _fBall_Degree <= 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_2":
                if (-150.0 <= _fBall_Degree && _fBall_Degree <= -30.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-30.0 < _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -150.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_3":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_4":
                if (-90.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_5":
                if (-89.0 < _fBall_Degree && _fBall_Degree < -18.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-18.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 < _fBall_Degree && _fBall_Degree <= 54.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (54.0 < _fBall_Degree && _fBall_Degree <= 124.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (124.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -161.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-161.0 <= _fBall_Degree && _fBall_Degree <= -89.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_6":
                if (-89.0 < _fBall_Degree && _fBall_Degree < -18.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-18.0 <= _fBall_Degree && _fBall_Degree <= 0.0 || 0.0 < _fBall_Degree && _fBall_Degree <= 54.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (54.0 < _fBall_Degree && _fBall_Degree <= 124.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (124.0 < _fBall_Degree && _fBall_Degree <= 180.0 || -180.0 <= _fBall_Degree && _fBall_Degree < -161.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-161.0 <= _fBall_Degree && _fBall_Degree <= -89.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_7":
                if (-116.0 < _fBall_Degree && _fBall_Degree < -64.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-167.0 <= _fBall_Degree && _fBall_Degree <= -116.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -167.0 || 140.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 140.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (40 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 <= _fBall_Degree && _fBall_Degree <= 40.0 || -12.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-64.0 <= _fBall_Degree && _fBall_Degree < -12.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_8":
                if (-116.0 < _fBall_Degree && _fBall_Degree < -64.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-167.0 <= _fBall_Degree && _fBall_Degree <= -116.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree < -167.0 || 140.0 < _fBall_Degree && _fBall_Degree < 180.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 < _fBall_Degree && _fBall_Degree <= 140.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (40 < _fBall_Degree && _fBall_Degree <= 90.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (0.0 <= _fBall_Degree && _fBall_Degree <= 40.0 || -12.0 <= _fBall_Degree && _fBall_Degree <= 0.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-64.0 <= _fBall_Degree && _fBall_Degree < -12.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
            case "Limit_9":
                if (51.0 <= _fBall_Degree && _fBall_Degree <= 90.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 15;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-24.0 <= _fBall_Degree && _fBall_Degree <= -9.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-9.0 < _fBall_Degree && _fBall_Degree <= 0.0 || -9.0 < _fBall_Degree && _fBall_Degree <= 0.0)
                {

                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 5;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-51.0 <= _fBall_Degree && _fBall_Degree < -9.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 30;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-140 < _fBall_Degree && _fBall_Degree <= -51.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 50;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (-180.0 <= _fBall_Degree && _fBall_Degree <= -140.0 || 167.0 <= _fBall_Degree && _fBall_Degree <= 180.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp += 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                else if (90.0 <= _fBall_Degree && _fBall_Degree < 168.0)
                {
                    tmp = Convert.ToInt32(_gPoint_Text.GetComponent<TextMeshProUGUI>().text);
                    tmp -= 10;
                    _gPoint_Text.GetComponent<TextMeshProUGUI>().text = tmp.ToString();
                }
                break;
        }
    }


    public void Game_ReStart()
    {

    }
}
