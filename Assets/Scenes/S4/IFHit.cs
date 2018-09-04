using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	private void OnTriggerEnter(Collider collision)
    {
		print("Trigger");
    }
   private void OnCollisionEnter(Collision collision)
    {
		print("Collision");
    }
}
