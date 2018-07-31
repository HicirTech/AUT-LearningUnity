using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {
	 enum State{live,die,wait};
	 AudioSource audioSource;
	[SerializeField] float rcsThrust = 100f;
	[SerializeField] float mainThrust = 100f;
	
	[SerializeField] AudioClip engine;
	[SerializeField] AudioClip death;
	[SerializeField] AudioClip success;
	[SerializeField] ParticleSystem running;
	[SerializeField] ParticleSystem diePart;
	[SerializeField] ParticleSystem winPart;

	 Rigidbody rigidbody;
	
	 Vector3 rotate;
	 Vector3 thrust;
    // Use this for initialization

	  State state;	
	

    void Start () {
		state=State.live;
		this.rotate = Vector3.forward*(this.rcsThrust*Time.deltaTime);
		this.thrust=Vector3.up*(this.mainThrust*Time.deltaTime);
		this.rigidbody=GetComponent<Rigidbody>();
		this.audioSource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(this.state==State.live)
		{
			this.processInput();	
		}
	}
	private void processInput()
	{
		ResopondToRotate();
		RespondToThrust();
		
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
				playWin();
				break;
			default:
				playDie();
				break;
		}	
	}	
	private	void playWin()
	{
		state=State.wait;
		running.Stop();
		winPart.Play();
		audioSource.Stop();
        audioSource.PlayOneShot(success);
		Invoke("LoadLevel1",1f);
		
	}
	private void playDie()
	{
		state=State.die;
		running.Stop();
		diePart.Play();
		audioSource.Stop();
		audioSource.PlayOneShot(death);
		Invoke("LoadLevel0",1f);	
	}
	private void LoadLevel0()
	{
		SceneManager.LoadScene(0);
	}
	private void LoadLevel1()
	{
		SceneManager.LoadScene(1);
	}
    private void ResopondToRotate()
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

    private void RespondToThrust()
    {
		rigidbody.freezeRotation = true;
	
        if (Input.GetKey(KeyCode.Space))
        {
            this.rigidbody.AddRelativeForce(thrust);

            if (!this.audioSource.isPlaying)
            {
                this.audioSource.PlayOneShot(this.engine);
            }
			running.Play();
        }
        else
        {
			this.running.Stop();
            this.audioSource.Stop();
        }
		rigidbody.freezeRotation=false;
    }

}
