using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{


    public GameObject target;
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            

            // Get parent object
            GameObject parent = transform.parent.gameObject;
            WaypointPatternMovement1 wpp1 = parent.GetComponent<WaypointPatternMovement1>();
            wpp1.state = WaypointPatternMovement1.Spotted.Spotted;

            // Do a GetCompnonent 

            
            
        }    
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
             

            GameObject parent = transform.parent.gameObject;
            WaypointPatternMovement1 wpp1 = parent.GetComponent<WaypointPatternMovement1>();
            wpp1.state = WaypointPatternMovement1.Spotted.Not_Spotted;
        }
    }
}
