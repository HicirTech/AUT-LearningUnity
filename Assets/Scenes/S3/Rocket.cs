using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		this.rigidbody=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

    private void ProcessInput()
    {
		if(Input.GetKey(KeyCode.Space))
		{
			//print("space");
			this.rigidbody.AddRelativeForce(Vector3.up);
		}
		if(Input.GetKey(KeyCode.A))
		{
			//print("lefe");
			transform.Rotate(Vector3.forward);
		}
		else if(Input.GetKey(KeyCode.D))
		{
		//	print("right");
			transform.Rotate(-Vector3.forward);
		}
		
    }
}
