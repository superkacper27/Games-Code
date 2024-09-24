using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {

            Destroy(gameObject);
            GameObject playerObject = GameObject.Find("player");
            player Player = playerObject.GetComponent<player>();
            float speed = Player.speed;
            Player.speed = 1.0f;
        }
    }
}
