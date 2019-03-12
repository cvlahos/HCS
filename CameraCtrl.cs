using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform playerTR;            // The position that we will store as a vector3 later that that camera will be following.
    public float smoothing;        // The speed with which the camera will be following. closer to 0 makes it more smooth


    Vector3 distanceBetweenCameraAndTarget;     // The initial offset from the target.


    void Start()
    {
        
        playerTR = GameObject.Find("name").GetComponent<Transform>();
        // Calculate the initial offset.
        distanceBetweenCameraAndTarget = transform.position - playerTR.position;

        
    }


    void LateUpdate()
    {
        // Create a position the camera is tracking that includes the location of the player and the offset stored in another variable
       Vector3 targetCamPos = playerTR.position + distanceBetweenCameraAndTarget;

        // Smoothly interpolate between the camera's current position and it's target position.
 
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

