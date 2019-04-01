using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBox : MonoBehaviour
{

    Transform playerTR; 

    Vector3 startPoint; // this will be used to store the location of the player at the begining of the level

    Quaternion startRotate; // don't worry about the rotation for now

    // Start is called before the first frame update
    void Start()
    {
        playerTR = GameObject.Find("pCube").GetComponent<Transform>();  // finding the player's transform 
        startPoint = playerTR.position; // this will store the player's location as a vector3
        startRotate = playerTR.rotation; // don't worry about the rotation for now
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTR.position = startPoint; // reset the player to the start location
            playerTR.rotation = startRotate;
            Debug.Log("touched the lose box");
        }

        if (other.CompareTag("PickUps"))
        {
            SuperGameManager.pickUpCount--;
        }

    }

}
