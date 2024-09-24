using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player2 : MonoBehaviour
{
    public int coins = 0;
    public Text scoreText;

    public GameObject enemy, enemy2, enemy3;
    public int currentScore;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetInt("currentScore");
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        // Move the player ship to where the mouse is clicked on-screen
        if (Input.GetButton("Fire1"))
        {
            Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
            transform.position = new Vector3(newpos.x, newpos.y, 0.0f);
        }

        Vector3 input = new Vector3(0.0f,0.0f,0.0f);

        // Move the player based on cursor key inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            input += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            input += Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            input += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            input += Vector3.down;
        }

        Vector3 velocity = input.normalized * speed * Time.deltaTime;

        // Could replace the above with the following code
        //Vector3 velocity = Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.tag == "Coins"))
        {
        if(enemy.activeSelf == true)
        {
        GameObject enemyObject = GameObject.Find("enemy");
        //GameObject enemyObject2 = GameObject.Find("enemy2");
        //GameObject enemyObject3 = GameObject.Find("enemy3");
        Chase2 enemy = enemyObject.GetComponent<Chase2>();
       // Chase enemy2 = enemyObject2.GetComponent<Chase>();
        //Chase enemy3 = enemyObject3.GetComponent<Chase>();

        int aggression = enemy.aggression;
        //int aggression2 = enemy2.aggression;
        //int aggression3 = enemy3.aggression;
        //enemy3.aggression ++;
      //  enemy2.aggression ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
        enemy.aggression ++;
        coins ++;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has " + coins + " Coin(s) in their Invetory.");
        }
        if(enemy2.activeSelf == true)
        {
        //GameObject enemyObject = GameObject.Find("enemy");
        GameObject enemyObject2 = GameObject.Find("enemy2");
        //GameObject enemyObject3 = GameObject.Find("enemy3");
        //Chase enemy = enemyObject.GetComponent<Chase>();
        Chase2 enemy2 = enemyObject2.GetComponent<Chase2>();
        //Chase enemy3 = enemyObject3.GetComponent<Chase>();

        //int aggression = enemy.aggression;
        int aggression2 = enemy2.aggression;
        //int aggression3 = enemy3.aggression;
        //enemy3.aggression ++;
        enemy2.aggression ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
       // enemy.aggression ++;
        coins ++;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has " + coins + " Coin(s) in their Invetory.");
        }
        if(enemy3.activeSelf == true)
        {
        //GameObject enemyObject = GameObject.Find("enemy");
        ////GameObject enemyObject2 = GameObject.Find("enemy2");
        GameObject enemyObject3 = GameObject.Find("enemy3");
        //Chase enemy = enemyObject.GetComponent<Chase>();
        //Chase1 enemy2 = enemyObject2.GetComponent<Chase1>();
        Chase2 enemy3 = enemyObject3.GetComponent<Chase2>();

        //int aggression = enemy.aggression;
        //int aggression2 = enemy2.aggression;
        int aggression3 = enemy3.aggression;
        enemy3.aggression ++;
        //enemy2.aggression ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
       // enemy.aggression ++;
        coins ++;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has " + coins + " Coin(s) in their Invetory.");
        }
        if(enemy.activeSelf == false)
        {
            

        
        currentScore ++;
        scoreText.text = "Score: "+currentScore;

        coins ++;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has " + coins + " Coin(s) in their Invetory.");
        }
        if(enemy2.activeSelf == false)
        {
            

        
        currentScore ++;
        scoreText.text = "Score: "+currentScore;

        coins ++;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has " + coins + " Coin(s) in their Invetory.");
        }
        if(enemy3.activeSelf == false)
        {
            

        
        currentScore ++;
        scoreText.text = "Score: "+currentScore;

        coins ++;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has " + coins + " Coin(s) in their Invetory.");
        }
        }
        

        else if(collision.collider.tag == "Crosses")
        {
        if(enemy.activeSelf == true)
        {
        GameObject enemyObject = GameObject.Find("enemy");
       // GameObject enemyObject2 = GameObject.Find("enemy2");
        //GameObject enemyObject3 = GameObject.Find("enemy3");
        Chase2 enemy = enemyObject.GetComponent<Chase2>();
       // Chase enemy2 = enemyObject2.GetComponent<Chase>();
        //Chase enemy3 = enemyObject3.GetComponent<Chase>();
        int aggression = enemy.aggression;
        enemy.aggression --;
        
       // enemy3.hasCross = true;
      //  enemy2.hasCross = true;
        currentScore ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
        enemy.hasCross = true;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has the holy power of a cross for 5 seconds");
        Invoke("Reset", 5f);
        }
        if(enemy2.activeSelf == true)
        {
        //GameObject enemyObject = GameObject.Find("enemy");
        GameObject enemyObject2 = GameObject.Find("enemy2");
        //GameObject enemyObject3 = GameObject.Find("enemy3");
        //Chase enemy = enemyObject.GetComponent<Chase>();
        Chase2 enemy2 = enemyObject2.GetComponent<Chase2>();
        //Chase enemy3 = enemyObject3.GetComponent<Chase>();
        int aggression2 = enemy2.aggression;
        enemy2.aggression --;
        
       // enemy3.hasCross = true;
        enemy2.hasCross = true;
        currentScore ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
       // enemy.hasCross = true;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has the holy power of a cross for 5 seconds");
        Invoke("Reset", 5f);
        }
        if(enemy3.activeSelf == true)
        {
        //GameObject enemyObject = GameObject.Find("enemy");
       // GameObject enemyObject2 = GameObject.Find("enemy2");
        GameObject enemyObject3 = GameObject.Find("enemy3");
        //Chase1 enemy = enemyObject.GetComponent<Chase1>();
       // Chase enemy2 = enemyObject2.GetComponent<Chase>();
        Chase2 enemy3 = enemyObject3.GetComponent<Chase2>();
        int aggression = enemy3.aggression;
        enemy3.aggression --;
        
        enemy3.hasCross = true;
      //  enemy2.hasCross = true;
        currentScore ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
        //enemy.hasCross = true;
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has the holy power of a cross for 5 seconds");
        Invoke("Reset", 5f);
        }
        if(enemy.activeSelf == false)
        {
        
        currentScore ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
        
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has the holy power of a cross for 5 seconds");
        
        }
        if(enemy2.activeSelf == false)
        {
        
        currentScore ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
        
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has the holy power of a cross for 5 seconds");
        
        }
        if(enemy3.activeSelf == false)
        {
        
        currentScore ++;
        currentScore ++;
        scoreText.text = "Score: "+currentScore;
        
        GameObject collectable = collision.gameObject;

        Debug.Log("Player collided with a collectable: " + collision.collider.name);
        Destroy(collectable);

        Debug.Log("Player now has the holy power of a cross for 5 seconds");
        
        }
        }
    }
    private void Reset()
    {
        if(enemy.activeSelf == true)
        {
            GameObject enemyObject = GameObject.Find("enemy");
            Chase2 enemy = enemyObject.GetComponent<Chase2>();
            enemy.hasCross = false;
        }
        
        if(enemy2.activeSelf == true)
        {
            GameObject enemyObject2 = GameObject.Find("enemy2");
            Chase2 enemy2 = enemyObject2.GetComponent<Chase2>();
            enemy2.hasCross = false;
        }
        
        if(enemy3.activeSelf == true)
        {
            GameObject enemyObject3 = GameObject.Find("enemy3");
            Chase2 enemy3 = enemyObject3.GetComponent<Chase2>();
            enemy3.hasCross = false;
        }
        
        
        
        

        
        
        
        
    }
}
