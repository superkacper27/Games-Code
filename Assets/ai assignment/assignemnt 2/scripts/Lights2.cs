using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights2 : MonoBehaviour
{

    public GameObject Loss;
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
        if (collision.CompareTag("Player"))
        {
            float speedDelta = (speed * Time.deltaTime);

             Vector3 newPosition = chase(target.transform.position, speedDelta);

            transform.position = newPosition;

            GameObject playerObject = GameObject.Find("player");
            Player player = playerObject.GetComponent<Player>();  

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
        }    
        
    }
}
