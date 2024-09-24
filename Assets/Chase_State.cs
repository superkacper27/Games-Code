using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_State : MonoBehaviour
{

    public GameObject target;

    public States state = States.Idle;   
    public float speed = 0f;
    public enum States
    {
        Chase,
        Idle
    };
    // Start is called before the first frame update
    void Start()
    {
        if(state == States.Chase)
        StartCoroutine("ChaseOff");
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(state)
        {
            
            case States.Chase:
            float speedDelta = (speed * Time.deltaTime);

            Vector3 newPosition = chase(target.transform.position, speedDelta);

            transform.position = newPosition;
            if (Input.GetKey(KeyCode.E))
                {
                    state = States.Idle;
                    
                }
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

            case States.Idle:
            if (Input.GetKey(KeyCode.Q))
                {
                    state = States.Chase;
                    StartCoroutine("ChaseOff");
                }
                
                break;
        }
    }
    // IEnumerator ChaseOff()
    // {
    //     yield return new WaitForSeconds(5.0f);
    //     state = States.Idle;
    //     StartCoroutine("ChaseOn");
    // }

IEnumerator ChaseOff()
    {
        yield return new WaitForSeconds(5.0f);
        state = States.Idle;
        
    }
    IEnumerator ChaseOn()
    {
        yield return new WaitForSeconds(5.0f);
        state = States.Chase;
        StartCoroutine("ChaseOff");
    }
}
