using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    public float speed = 30;
    // public ParticleSystem explosionParticle;

    private PlayerController playerControllerScript;
    private float leftBound = -50;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (playerControllerScript.gameOver == false)
        {
            // transform.Translate(Vector3.left * Time.deltaTime * speed);
            // Moves the object (not affected by rotation)
            transform.position += new Vector3(Time.deltaTime * -speed, 0, 0);
        }
        
        if (transform.position.x < leftBound && !gameObject.CompareTag("road"))
        {
            Destroy(gameObject);
        }
    }

    // private void OnCollisionEnter(Collision collision other){
    //     if(other.gameObject.CompareTag("Player")){
    //         explosionParticle.Play();
    //     }
    // }
}
