using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ELN : MonoBehaviour {

	// Use this for initialization
	private Text number;
	int killCounter=0;
	Enemy Enemy;
	void Start () {
	
		this.number= GetComponent<Text>();
		
	}
	void Update()
	{
		this.updatenumber();
	}
	public void updatenumber()
	{
		int Enemynumber= FindObjectsOfType<Enemy>().Length;
		if(Enemynumber!=0&&killCounter!=20)
		{
			this.number.text=Enemynumber+" enemys left!";
		}
		else if(Enemynumber==0&&killCounter!=20)
		{
			this.number.text="new enemy is comming";
		}
		else{
			this.number.text="you are safe now!";
		}
	}
	public void updateKill()
	{
			this.killCounter++;
	}
	

	
}
