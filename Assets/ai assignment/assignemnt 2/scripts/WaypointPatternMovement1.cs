using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

[Serializable]
public class WayPointCD
{
    // Waypoint we want our NPC to move towards
    public GameObject waypoint;

    

    public bool spotted;
    public GameObject player;
    // Time to wait in seconds when we get to the waypoint
    public float time;
}

public class WaypointPatternMovement1 : MonoBehaviour
{
    public GameObject target;

    public GameObject trap;


    public enum Spotted
    {
        Spotted,
        Not_Spotted,
        Trap,
        Coins_Taken
    };

    public Spotted state = Spotted.Not_Spotted;   
    public WayPointCD[] wpPattern;
    private int patternIndex = 0;
    public float speed = 1;
    [SerializeField]
    private bool hasSpawned = false;

    // Use this for initialization
    void Start ()
    {
		state = Spotted.Not_Spotted;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {

            Destroy(collision.gameObject);
            Invoke("Death", 2f);
        }
    }

    private void Death()
    {
        // Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;
        if(sceneName != "level 1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        float speedDelta = (speed * Time.deltaTime);

           

            
        switch(state)
        {

            case Spotted.Trap:
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
             if(!hasSpawned)
            {
                
                Instantiate(trap, transform.position, Quaternion.identity);
                hasSpawned = true;
            }
            StartCoroutine("TrapPlaced");
            


            break;
            
            case Spotted.Spotted:
             Vector3 newPosition = chase(target.transform.position, speedDelta);
             transform.position = newPosition;
            Vector3 chase(Vector3 pos, float sd)
            {
            Vector3 enemyPosition = transform.position;
            Vector3 targetPosition = pos;
            Vector3 closeTarget = targetPosition - enemyPosition;
            float distance = closeTarget.magnitude;
            Vector3 normalizedCloseTarget = closeTarget.normalized;
            Vector3 delta = normalizedCloseTarget *sd;
            Vector3 newPosition = enemyPosition + delta;
            
            
            return newPosition;
            
            
            }
                break;
            
            case Spotted.Not_Spotted:

            GameObject playerObject = GameObject.Find("player");
             player Player = playerObject.GetComponent<player>();
            int Coins = Player.coins;
            
                WayPointCD wayPointCD = wpPattern[patternIndex];


        // Find the range to close vector
        Vector3 rangeToClose = wayPointCD.waypoint.transform.position - transform.position;

        // Draw this vector at the position of the enemy
        Debug.DrawRay(transform.position, rangeToClose, Color.cyan);

        // What's our distance to the waypoint?
        float distance = rangeToClose.magnitude;

        // How far do we move each frame
        //float speedDelta = speed * Time.deltaTime;

        // If we're close enough to the current waypoint 
        // then increase the pattern index
        if (distance <= speedDelta)
        {
            // 
            // Wait for 2 seconds
            //

            patternIndex++;
            // Reset the patternIndex if we are at the end of the instruction array
            if (patternIndex >= wpPattern.Length)
            {
                patternIndex = 0;
            }

            // Process the current instruction in our control data array
            wayPointCD = wpPattern[patternIndex];

            // Find the new range to close vector
            rangeToClose = wayPointCD.waypoint.transform.position - transform.position;
        }

        // In what direction is our player?
        Vector3 normalizedRangeToClose = rangeToClose.normalized;

        // Draw this vector at the position of the waypoint
        Debug.DrawRay(transform.position, normalizedRangeToClose, Color.magenta);

        Vector3 delta = speedDelta * normalizedRangeToClose;

        transform.Translate(delta);

         if(!hasSpawned)
            {
                StartCoroutine("PlaceTrap");
                
            }

        else
        {
            StopCoroutine("PlaceTrap");
        }

        
        if(Coins == 3)
        {
            state = Spotted.Coins_Taken;
        }
        
                break;

            case Spotted.Coins_Taken:

            speed = .8f;

            Vector3 newPosition1 = chase1(target.transform.position, speedDelta);
             transform.position = newPosition1;
            Vector3 chase1(Vector3 pos, float sd)
            {
            Vector3 enemyPosition = transform.position;
            Vector3 targetPosition = pos;
            Vector3 closeTarget = targetPosition - enemyPosition;
            float distance = closeTarget.magnitude;
            Vector3 normalizedCloseTarget = closeTarget.normalized;
            Vector3 delta = normalizedCloseTarget *sd;
            Vector3 newPosition = enemyPosition + delta;
            
            return newPosition;
            }

            break;
            
        
        

        }
        
    }

    IEnumerator TrapPlaced()
    {
           
            yield return new WaitForSeconds(1.5f);
            //Invoke("TrapTimer", 0f);
            state = Spotted.Not_Spotted;
            float TrapTime = Random.Range(5f, 11f);
            yield return new WaitForSeconds(TrapTime);
            hasSpawned = false;
            

    }

    // IEnumerator TrapTimer()
    // {
        
    // }

    IEnumerator PlaceTrap()
    {
        yield return new WaitForSeconds(20f);
        state = Spotted.Trap;
    }
}
