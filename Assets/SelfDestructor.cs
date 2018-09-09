using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("killSelf",2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void killSelf()
	{
		Destroy(gameObject);
	}	
}
