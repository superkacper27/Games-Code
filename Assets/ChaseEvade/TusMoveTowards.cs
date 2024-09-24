using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TusMoveTowards : MonoBehaviour
{
    public GameObject target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Position of the target: target.transform.position
        // Position of ther NPC: transform.position
        float speedDelta = speed * Time.deltaTime;

        Vector3 newPosition = tusMoveTowards(target.transform.position, speedDelta);

        transform.position = newPosition;
    }

    Vector3 tusMoveTowards(Vector3 pos, float sd)
    {
        Vector3 enemyPosition = transform.position;
        Vector3 targetPosition = pos;
        Vector3 closeTarget = targetPosition - enemyPosition;
        float distance = closeTarget.magnitude;
        Vector3 normalizedCloseTarget = closeTarget.normalized;
        Debug.DrawRay(enemyPosition, closeTarget, Color.cyan);
        Debug.DrawRay(enemyPosition, normalizedCloseTarget, Color.red);
        Vector3 delta = normalizedCloseTarget *sd;
        Vector3 newPosition = enemyPosition + delta;
        return newPosition;
    }
}
