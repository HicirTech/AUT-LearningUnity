using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("loadScene", 2f);
	}

	private void loadScene(){
        SceneManager.LoadScene(1);
    }
}

