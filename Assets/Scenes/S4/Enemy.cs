using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform  aferdied;
	ScroreBoard scroreBoard;
	private void Start()
	{
		addcollider(); 
	}

	private void addcollider()
	{
		Collider enemyCollider  = gameObject.AddComponent<SphereCollider>();
		enemyCollider.isTrigger=false;		
	}

	private void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(deathFX,gameObject.transform.position,Quaternion.identity);
		fx.transform.parent=aferdied;
		Destroy(gameObject);
		this.deathFX.SetActive(true);
		updateScoreBoard();
	}
	private void updateScoreBoard()
	{
		scroreBoard = FindObjectOfType<ScroreBoard>();
		this.scroreBoard.updateScore();
	}
}
