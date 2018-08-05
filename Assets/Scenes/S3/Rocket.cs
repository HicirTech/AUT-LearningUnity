using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

	private AudioSource audioSource;
	[SerializeField] [Range(0,7)] private static int levelCount=0;
	[SerializeField] private bool collisionEnable = true ;
	[SerializeField] private float rcsThrust = 100f;
	[SerializeField] private float mainThrust = 100f;
	[SerializeField] private float levelDelay =2f;
	[SerializeField] private AudioClip engine;
	[SerializeField] private AudioClip death;
	[SerializeField] private AudioClip success;
	[SerializeField] private ParticleSystem running;
	[SerializeField] private ParticleSystem diePart;
	[SerializeField] private ParticleSystem winPart;
	private Rigidbody rigidbody;
 	private Vector3 rotate;
	private Vector3 thrust;
	private bool isAlive;	
	
    void Start () {
		this.isAlive=true;
		this.getReady();
		//this.rigidbody=GetComponent<Rigidbody>();
		//this.audioSource = GetComponent<AudioSource>();
	}

	void Update () {		
		if(this.isAlive)
			this.processInput();	
	}
	private void getVetctorReady()
	{
		this.rotate = Vector3.forward*(this.rcsThrust*Time.deltaTime);
		this.thrust=Vector3.up*(this.mainThrust*Time.deltaTime);
	}
	private void getReady()
	{
		this.getVetctorReady();
		this.getRockReady();
	}
	private void processInput()
	{
		this.ResopondToRotate();
		this.RespondToThrust();
		if(Debug.isDebugBuild)
			this.debugkey();
	}
	private void getRockReady()
	{
		this.rigidbody=GetComponent<Rigidbody>();
		this.audioSource = GetComponent<AudioSource>();
	}

	private void debugkey()
	{
		this.debugL();
		this.debugC();
	}
	private void debugL()
	{
		if(Input.GetKey(KeyCode.L))
		{
			//levelCount++;
			this.LoadLevel();
		}
	}
	private void debugC()
	{
		if(Input.GetKey(KeyCode.C))
		{
			this.collisionEnable=!this.collisionEnable;
		}

	}
	private void OnCollisionEnter(Collision collision)
	{
		if(isAlive!=true)
		{
			return;
		}
		switch(collision.gameObject.tag)
		{
			case "Friendly":	
				break;
			case "Finish":
				this.audioSource.PlayOneShot(this.success);
				this.playWin();
				break;
			default:
				if(this.collisionEnable)
				{
					this.playDie();
				}
				break;
		}	
	}	
	private	void playWin()
	{
		this.running.Stop();
		this.winPart.Play();
		this.audioSource.Stop();
		Invoke("LoadLevel",this.levelDelay);
	}
	private void playDie()
	{
		this.isAlive=!isAlive;
		this.running.Stop();
		this.diePart.Play();
		this.audioSource.Stop();
		this.audioSource.PlayOneShot(this.death);
		Invoke("LoadLevel",levelDelay);	
	}
	private void LoadLevel()
	{
		if(this.isAlive)
		{
			if(levelCount<=7)
				levelCount++;		
			else
				levelCount=0;
		}
		SceneManager.LoadScene(levelCount);
	}
    private void ResopondToRotate()
    {
		this.rigidbody.angularVelocity=Vector3.zero;
    	this.codeProcess();

    }
	private void codeProcess()
	{
		if (Input.GetKey(KeyCode.A))
			transform.Rotate(rotate);
        else if (Input.GetKey(KeyCode.D))
			transform.Rotate(-rotate);
	}

    private void RespondToThrust()
    {
		this.rigidbody.freezeRotation = true;
	
        if (Input.GetKey(KeyCode.Space))
        {
            this.rigidbody.AddRelativeForce(thrust);

            if (!this.audioSource.isPlaying)
            {
                this.audioSource.PlayOneShot(this.engine);
            }
			this.running.Play();
        }
        else
        {
			this.running.Stop();
            this.audioSource.Stop();
        }
		this.rigidbody.freezeRotation=false;
    }

}
/* code Rubbish bin


	private enum State{live,die,wait};
	private void LoadLevel0()
	{
		SceneManager.LoadScene(0);
	}
	private void LoadLevel1()
	{
		SceneManager.LoadScene(1);
	}
 */