using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ELN : MonoBehaviour {

	// Use this for initialization
	private Text number;
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
		this.number.text=Enemynumber+" enemy left!";
	}
	
	// Update is called once per frame
	
}
