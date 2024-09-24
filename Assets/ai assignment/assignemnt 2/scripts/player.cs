using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Text scoreText;

    public GameObject portal;
    public GameObject enemy;
    public int currentScore;
    public int coins = 0;

    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        // Move the player ship to where the mouse is clicked on-screen
        

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

        PlayerPrefs.SetInt("currentScore", currentScore);
        PlayerPrefs.Save();


        if (coins == 3)
        {
            portal.SetActive(true);
            
        }

        if (speed == 1.0f)
        {
            Invoke("Reset", 4.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.name == "coin"))
        {
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

    }

    void Reset()
    {
          speed = 3.0f;
    }
   
    
}
