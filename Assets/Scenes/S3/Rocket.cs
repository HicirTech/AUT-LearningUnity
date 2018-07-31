using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	[SerializeField]private float rcsThrust = 150f;
	[SerializeField]private float mainThrust = 1000f;
	private Rigidbody rigidbody;
	private AudioSource audioSource;
	Vector3 rotate;
	Vector3 thrust;
    // Use this for initialization
    void Start () {
		this.rotate = Vector3.forward*(this.rcsThrust*Time.deltaTime);
		this.thrust=Vector3.up*(this.mainThrust*Time.deltaTime);
		this.rigidbody=GetComponent<Rigidbody>();
		this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
		Thrust();
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		switch(collision.gameObject.tag)
		{
			case "Friendly":
				print("Collided");
				break;
			case "Fuel":
				print("Fuel");
				break;
			default:
				print("die");
				break;
		}	
	}
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //print("lefe");
			//float rotateSpeed = rcsThrust*Time.deltaTime;
            transform.Rotate(rotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //	print("right");
			//float rotateSpeed = rcsThrust*Time.deltaTime;
            transform.Rotate(-rotate);
        }

    }

    private void Thrust()
    {
		rigidbody.freezeRotation = true;
	
        if (Input.GetKey(KeyCode.Space))
        {
            //print("space");
            this.rigidbody.AddRelativeForce(thrust);

            if (!this.audioSource.isPlaying)
            {
                this.audioSource.Play();
            }
        }
        else
        {
            this.audioSource.Stop();
        }
		rigidbody.freezeRotation=false;
    }

}
