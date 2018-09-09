using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class musicPlayer : MonoBehaviour
{   
    private void Awake()
    {
        print(FindObjectsOfType<musicPlayer>().Length);
        if(FindObjectsOfType<musicPlayer>().Length>1)
        {
            print("Distory");
            Destroy(gameObject);
        }
        else
        {
             print("not Distory");
            DontDestroyOnLoad(gameObject);
        }
    }
    
}
 
