using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<GameObject> path;
	int index;
	void Start () {
	//	this.path.AddRange(GameObject.FindGameObjectsWithTag("blocks"));
	//	this.path.Sort();
		foreach(GameObject block in path)
		{
			//Invoke("Move",2f);
			print(block.name);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Move()
	{
		//float xp = path[0].transform.position.x;
		
	}
}
