using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float speed = 15.0f;
    public float turnSpeed = 80.0f;
    public float horizontalInput;
    public float verticalInput;
    public float rotation;
    public int score;
    public Text scoreText;
    public Text gameOverText;
    public Text pressSpaceToStartText;
    public Text pressSpaceToRestartText;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = true;
        gameOverText.GetComponent<Text>().enabled = false;
        pressSpaceToStartText.GetComponent<Text>().enabled = true;
        pressSpaceToRestartText.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            // Rotates the bus
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            rotation = transform.rotation.eulerAngles[1] - 90;
            // Ignores the rotation
            transform.position += new Vector3(0, 0, Time.deltaTime * -rotation);
        } else {
            if (Input.GetKeyDown("space"))
            {
                RestartGame();
            }
        }
        if(Mathf.Abs(transform.position.z) > 70){
            GameOver();
        }

    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("mailbox") ){
            score++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
            explosionParticle.Play();

        } else if(collision.gameObject.CompareTag("car") || collision.gameObject.CompareTag("house")){
            Invoke("GameOver", 0.2f);
        }
    }
    private void GameOver(){
        gameOverText.GetComponent<Text>().enabled = true;
        pressSpaceToRestartText.GetComponent<Text>().enabled = true;
        gameOver = true;
    }
    private void RestartGame(){
        GameObject[] obstacles1 = GameObject.FindGameObjectsWithTag("car");
        GameObject[] obstacles2 = GameObject.FindGameObjectsWithTag("house");
        GameObject[] obstacles3 = GameObject.FindGameObjectsWithTag("mailbox");
        GameObject[] obstacles4 = GameObject.FindGameObjectsWithTag("driveway");
        foreach(GameObject obstacle in obstacles1){
            GameObject.Destroy(obstacle);
        }
        foreach(GameObject obstacle in obstacles2){
            GameObject.Destroy(obstacle);
        }
        foreach(GameObject obstacle in obstacles3){
            GameObject.Destroy(obstacle);
        }
        foreach(GameObject obstacle in obstacles4){
            GameObject.Destroy(obstacle);
        }

        Invoke("setGameOverToFalse", 0.4f);
        transform.position = new Vector3(-9, 1.4f, 0);
        transform.rotation = Quaternion.Euler(0,90,0);
        score = 0;
        scoreText.text = score.ToString();
        gameOverText.GetComponent<Text>().enabled = false;
        pressSpaceToStartText.GetComponent<Text>().enabled = false;
        pressSpaceToRestartText.GetComponent<Text>().enabled = false;
    }
    private void setGameOverToFalse(){
        gameOver = false;
    }
}
