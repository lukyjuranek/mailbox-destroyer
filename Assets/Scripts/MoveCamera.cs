using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float transitionSpeed = 1f;
    private Vector3 finalLocation = new Vector3(0, 29, 0);
    private Quaternion finalRotation = Quaternion.Euler(77, 90, 0);

    private Vector3 startLocation = new Vector3(1.67f, 3.12f, 11.82f);
    private Quaternion startRotation = Quaternion.Euler(0, 195.403f, 0);
    private int timeCounter = 0;

    public PlayerController playerControllerScript;
    public bool startMovement = false;
 

    void Start()
    {
        transform.position = startLocation;
        transform.rotation = startRotation;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == true){
            if (Input.GetKeyDown("space"))
            {
                startMovement = true;
            }
        }
        if(startMovement){
                transitionSpeed += 0.05f;
                transform.position = Vector3.Lerp(transform.position, finalLocation, Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * transitionSpeed);
        }
    }
}
