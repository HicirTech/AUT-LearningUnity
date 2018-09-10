using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScroreBoard : MonoBehaviour {

	// Use this for initialization
	private int Score{set;get;}
	private Text scoreText;
	void Start () {
		this.Score=0;
		this.scoreText= GetComponent<Text>();
		scoreText.text="Score:" + this.Score;
	}
	public void updateScore()
	{
		this.Score+=10;
		this.scoreText.text="Score:" + this.Score;
	}
	
	// Update is called once per frame
	void Update () {
		//updateScore();
	}
	
}
