using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour {

	[SerializeField][Range(1f,20f)] float gridSize =10f;
	TextMesh text;
	// Use this for initialization
	void Start()
	{

		text =gameObject.GetComponentInChildren<TextMesh>();
	}
    void Update()
    {
		Vector3 snapPods;
		snapPods.x=Mathf.RoundToInt(transform.position.x/gridSize)*gridSize;
		snapPods.z=Mathf.RoundToInt(transform.position.z/gridSize)*gridSize;
		transform.position=new Vector3(snapPods.x,0f,snapPods.z);
    
		this.text.text=(gameObject.transform.position.x/10)+","+(gameObject.transform.position.z/10);
		gameObject.name=text.text.ToString();
	}

}
