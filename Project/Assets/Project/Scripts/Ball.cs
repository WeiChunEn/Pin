using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float _fSpeed;
    // Use this for initialization
    void Start ()
    {
        _fSpeed = 100.0f;

    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(0, 0, _fSpeed * Time.deltaTime);
	}
   
}
