using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("loadScene", 2f);
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void loadScene()
    {
        SceneManager.LoadScene(1);
    }
}
