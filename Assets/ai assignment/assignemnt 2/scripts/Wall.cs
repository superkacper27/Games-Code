using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.Find("player");
        player Player = playerObject.GetComponent<player>();
        int Coins = Player.coins;
        
        if(Coins == 3)
        {
            Destroy(gameObject);
        }
    }
}
