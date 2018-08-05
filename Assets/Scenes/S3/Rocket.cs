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
		isAlive=true;
		this.getReady();
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
		ResopondToRotate();
		RespondToThrust();
		if(Debug.isDebugBuild)
			debugkey();
	}
		private void getRockReady()
	{
		this.rigidbody=GetComponent<Rigidbody>();
		this.audioSource = GetComponent<AudioSource>();
	}

	private void debugkey()
	{
		debugL();
		debugC();
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
				playWin();
				break;
			default:
				if(this.collisionEnable)
				{
					playDie();
				}
				break;
		}	
	}	
	private	void playWin()
	{
		running.Stop();
		winPart.Play();
		audioSource.Stop();
        audioSource.PlayOneShot(success);
		Invoke("LoadLevel",levelDelay);
	}
	private void playDie()
	{
		isAlive=!isAlive;
		running.Stop();
		diePart.Play();
		audioSource.Stop();
		audioSource.PlayOneShot(death);
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