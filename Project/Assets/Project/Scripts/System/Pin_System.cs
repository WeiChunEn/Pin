using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Pin_System : MonoBehaviour
{
    public float _fSpeed;
    public GameObject _gCheck_Point;
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

            _gCheck_Point.transform.SetParent(col.transform);
            _rb.velocity = Vector2.zero;
            transform.SetParent(col.transform);
           
            print(Mathf.Atan2(_gCheck_Point.transform.localPosition.y, _gCheck_Point.transform.localPosition.x)*180/Mathf.PI);
           
        }
    }
}
