//Taylor Burdgess, Charlie Garrido

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TASK 1: I want the player to move ONLY at the bottom half of the screen. It can still exit from right and left and appear on the other side, but it should not move below the bottom line of the screen and above the middle of the screen.
public class Player : MonoBehaviour
{
    //private variables arent seen in Unity, public are
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 8.5f;
    private float verticalUpperLimit = 0.6f;
    private float verticalLowerLimit = -3.5f;

    void SetTransformY(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }

    //called at the start of the game
    void Start()
    {
        playerSpeed = 10.0f;
        //transform.position = new Vector3(2, 3, 4);
    }

    // Update is called once per frame
    //Time.deltaTime to fix
    void Update()
    {
        Movement();
        //transform.position = new Vector3(2, 3, 4);
    }

    void Movement()
    {
        //Read Input from player
        horizontalInput = Input.GetAxis ("Horizontal");
        verticalInput = Input.GetAxis ("Vertical");
        //move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        //Player leaves screen Horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
                transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        } 

        //Blocks the player from moving past upper & lower screen limits
        else if (transform.position.y > verticalUpperLimit) 
        { 
            SetTransformY(0.6f); 
        }
        else if (transform.position.y < verticalLowerLimit) 
        { 
            SetTransformY(-3.5f); 
        }

    }

    
}


//TASK 2: Create a Second Enemy Type with a Different Movement Pattern and Spawn Pattern
public class Enemytype1 : MonoBehaviour
{
  private float speed= 5f;
  private float spawnInterval= 4f;
  private Vector3 spawnPosition;

  void Start()
  {
    //Random intial position 
     float transform.position.x = Random.Range(-5f, 5f);
     transform.position = new Vector3(transform.position.x * -1, y, 0);
  }

  void Update()
  {
   //Horizontal input axis
   float horizontalInput = Input.GetAxis("Horizontal");

   //Vertical axis input
  float verticalInput = Input.GetAxis("Vertical");
   
  //Transform position
  transform.position = new Vector3(transform.position.x * -1, y, 0);

  //Output log
  Debug.log(transform.position);
  }
}

public class Enemytype2 : MonoBehaviour
{
  private float speed= -3.5f;
  private float spawnInterval= 5f;
  private Vector3 spawnPosition;

  void Start()
  {
    //Random intial position 
     float transform.position.x = Random.Range(-3f, 3f);
     transform.position = new Vector3(transform.position.x * -1, y, 0);
  }

  void Update()
  {
   //diagonal input axis
   float diagonalInput = Input.GetAxis("diagonal");

   //Vertical axis input
  float verticalInput = Input.GetAxis("Vertical");
   
  //Transform position
  transform.position = new Vector3(transform.position.x * -1, y, 0);

  //Output log
  Debug.log(transform.position);
}
}

public class Enemyspawn : MonoBehaviour
{
public GameObject firstEnemyPrefab;
public GameObject secondEnemyPrefab;
private float Enemytype1spawnInterval= 3f;
private float Enemytype2spawnInterval= 5f;

void Start()
{
     // Spawning enemies in different intervals
        StartCoroutine(FirstEnemySpawn());
        StartCoroutine(SecondEnemySpawn());
}

void Update()
{
   
      // Check spawn time for the first enemy
        if (firstEnemyTimer >= firstEnemySpawnInterval)
        {
            FirstEnemySpawn();
            firstEnemyTimer = 1f; // Reset timer after spawn
        }

      // Check spawn time the second enemy
      if (secondEnemyTimer >= secondEnemySpawnInterval)
{
    SecondEnemySpawn();
    secondEnemyTimer = 1f; // Reset timer after spawn
}

    // First enemy spawn method 
    void FirstEnemySpawn()
 {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 5f, 0); // Random X position
        Instantiate(firstEnemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("First enemy spawned!!!");
}

    //Second enemy spawn method
    void SecondEnemySpawn()
{
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 5f, 0); // Random X position
        Instantiate(secondEnemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Second enemy spawned!!!");
}
}

}

