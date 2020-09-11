using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject drivewayPrefab;
    public GameObject[] mailboxPrefabs;
    public GameObject[] housePrefabs;
    public GameObject[] carPrefabs;
    public GameObject[] movingCarPrefabs;
    private Vector3 spawnPosMailbox;
    private Vector3 spawnPosDriveway;
    private Vector3 spawnPosHouse;
    private Vector3 spawnPosCar;
    private Vector3 spawnPosMovingCar;
    private float startDelay = 4;
    private float repeatDelay = 1;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, repeatDelay);
        InvokeRepeating("SpawnMovingCar", startDelay, 1);
    }

    // Update is called once per frame
    void Update()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Spawn()
    {
        if (playerControllerScript.gameOver == false)
        {

            int mailboxIndex = Random.Range(0, mailboxPrefabs.Length);
            int houseIndex = Random.Range(0, housePrefabs.Length);
            int carIndex = Random.Range(0, carPrefabs.Length);

            spawnPosMailbox = new Vector3(85, 10, -6);
            spawnPosDriveway = new Vector3(66, 1, -24.5f);
            spawnPosHouse = new Vector3(63, 0.9f, -46);
            spawnPosCar = new Vector3(65, 2, -10);


            Quaternion flip = Quaternion.Euler(0, 0, 0);
            if (Random.Range(0, 2) == 0)
            {
                spawnPosMailbox = Vector3.Reflect(spawnPosMailbox, Vector3.forward);
                spawnPosDriveway = Vector3.Reflect(spawnPosDriveway, Vector3.forward);
                spawnPosHouse = Vector3.Reflect(spawnPosHouse, Vector3.forward);
                spawnPosCar = Vector3.Reflect(spawnPosCar, Vector3.forward);
                flip = Quaternion.Euler(0, 180f, 0);
            }

            Instantiate(mailboxPrefabs[mailboxIndex], spawnPosMailbox, mailboxPrefabs[mailboxIndex].transform.rotation * flip);
            Instantiate(drivewayPrefab, spawnPosDriveway, drivewayPrefab.transform.rotation * flip);
            Instantiate(housePrefabs[houseIndex], spawnPosHouse, housePrefabs[houseIndex].transform.rotation * flip);
            // Spawns a car 2 out of 3 times
            if (Random.Range(0, 3) != 0)
            {
                Instantiate(carPrefabs[carIndex], spawnPosCar, carPrefabs[carIndex].transform.rotation * flip);
            }
        }
    }
    void SpawnMovingCar()
    {
        if (playerControllerScript.gameOver == false)
        {
            int movingCarIndex = Random.Range(0, movingCarPrefabs.Length);

            spawnPosMovingCar = new Vector3(65, 3, 2);

            // Rnadomly chooses a side of the road
            if (Random.Range(0, 2) == 0)
            {
                spawnPosMovingCar = Vector3.Reflect(spawnPosMovingCar, Vector3.forward);
            }
            // Moving car
            // Spawns a car 2 out of 3 times
            if (Random.Range(0, 3) != 0)
            {
                Instantiate(movingCarPrefabs[movingCarIndex], spawnPosMovingCar, movingCarPrefabs[movingCarIndex].transform.rotation * Quaternion.Euler(0, -90f, 0));
            }


        }
    }
}
