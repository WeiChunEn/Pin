using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Pin : MonoBehaviour
{
    public float _fSpeed;
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
            _rb.velocity = Vector2.zero;
            transform.SetParent(col.transform);
        }
    }
}
