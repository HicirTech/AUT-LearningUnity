using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class MoveController : MonoBehaviour
{

    // Use this for initialization
    [Header("General")]
    [Tooltip("M/s")] [SerializeField] float ControlSpeed = 8;
    [SerializeField] float positionPitchFactor = -5f; 
    [SerializeField] float controlPitchFactor = -20f; 
    [SerializeField] float positionYawFactor = 5f; 
    [SerializeField] float controlRollFactor = -30f; 

    [SerializeField] GameObject[] Guns;

    
    private bool isControlEnable =true ;
    
    
    
    float xThrow;
    float yThrow;
 

    
    void Update()
    {
        if(this.isControlEnable)
        {
            Move();
        //fun();
            rotate();
            processFiring();
        }
    }
    private void rotate()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = (pitchDueToPosition + pitchDueToControlThrow)/1.5f;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Move()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
       
        float xOffSet = xThrow * ControlSpeed * Time.deltaTime;
        float yOffSet = yThrow * ControlSpeed * Time.deltaTime;
        float rowY = Mathf.Clamp(transform.localPosition.y + yOffSet, -2.5f, +2.5f);
        float rowX = Mathf.Clamp(transform.localPosition.x + xOffSet, -3.23f, +3.23f);
        transform.localPosition = new Vector3(rowX, rowY, transform.localPosition.z);
    }

    void processFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            foreach(GameObject e in Guns)
            {
                e.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject e in Guns)
            {
                e.SetActive(false);
            }
        }
    }
    public void onPlayerDie()
    {
       // print("shit!");
        //death();
        this.isControlEnable=false;
    }


}


