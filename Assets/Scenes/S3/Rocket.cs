using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {
	private enum State{live,die,wait};
	[SerializeField]private float rcsThrust = 150f;
	[SerializeField]private float mainThrust = 1000f;
	private Rigidbody rigidbody;
	private AudioSource audioSource;
	private Vector3 rotate;
	private Vector3 thrust;
    // Use this for initialization

	private  State state;	
	

    void Start () {
		state=State.live;
		this.rotate = Vector3.forward*(this.rcsThrust*Time.deltaTime);
		this.thrust=Vector3.up*(this.mainThrust*Time.deltaTime);
		this.rigidbody=GetComponent<Rigidbody>();
		this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
		processInput();
	}
	private void processInput()
	{
		if(this.state==State.live)
		{
			Rotate();
			Thrust();
		}
		else{
			audioSource.Stop();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(state!=State.live)
		{
			return;
		}
		switch(collision.gameObject.tag)
		{
			case "Friendly":
				break;
			case "Finish":
				state=State.wait;
				Invoke("LoadLevel1",1f);
				break;
			default:
				state=State.die;
				Invoke("LoadLevel0",1f);
				break;
		}	
	}	
	 void LoadLevel0()
	{
		SceneManager.LoadScene(0);
	}
	 void LoadLevel1()
	{
		SceneManager.LoadScene(1);
	}
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
			transform.Rotate(rotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
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
