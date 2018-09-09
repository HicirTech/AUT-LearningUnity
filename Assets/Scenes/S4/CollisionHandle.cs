using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandle : MonoBehaviour {

	[SerializeField] private GameObject deathFX;
	private void OnTriggerEnter(Collider collision)
    {
	
			startDeathSequence();
    }
  
		private void startDeathSequence()
		{
			print("call on Player die");
			SendMessage("onPlayerDie");
			death();
			Invoke("load",1);
		}
		private void load()
		{
			SceneManager.LoadScene(1);
		}
		    public void death()
    {
        this.deathFX.SetActive(true);
    }

}
