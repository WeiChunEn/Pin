using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater_System : MonoBehaviour
{
    public float _fSpeed;
    public int tmp;
    // Use this for initialization
    void Start ()
    {
        _fSpeed = 100.0f;
        tmp = 1;

    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(0, 0, _fSpeed * Time.deltaTime*tmp);
	}
   
}
