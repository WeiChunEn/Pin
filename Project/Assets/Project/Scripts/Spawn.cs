using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject _gPin;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Create_Pin();
        }
	}

    public void Create_Pin()
    {
        Instantiate(_gPin, transform.position, transform.rotation,gameObject.transform);
    }



}
