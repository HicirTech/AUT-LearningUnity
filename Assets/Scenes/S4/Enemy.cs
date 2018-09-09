using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform  aferdied;
	private void Start()
	{
		Collider enemyCollider  = gameObject.AddComponent<SphereCollider>();
		enemyCollider.isTrigger=false;		
	}
	private void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(deathFX,gameObject.transform.position,Quaternion.identity);
		fx.transform.parent=aferdied;
		print("EM hit"+gameObject.name);
		Destroy(gameObject);
		this.deathFX.SetActive(true);
	}
}
