using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chase2 : MonoBehaviour
{

    public GameObject Loss;
    public GameObject target;
    public float speed = 0f;

    public int aggression = 1;

    

    public bool hasCross;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speedDelta = (speed * Time.deltaTime) + (aggression * Time.deltaTime);

        Vector3 newPosition = chase(target.transform.position, speedDelta);

        transform.position = newPosition;

        
    }

    Vector3 chase(Vector3 pos, float sd)
    {
        if(hasCross == false)
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
        else
        {
        Vector3 enemyPosition = transform.position;
        Vector3 targetPosition = pos;
        Vector3 closeTarget = targetPosition - enemyPosition;
        float distance = closeTarget.magnitude;
        Vector3 normalizedCloseTarget = closeTarget.normalized;
        Vector3 delta = normalizedCloseTarget *sd;
        Vector3 newPosition = enemyPosition - delta;
        return newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hasCross == false)
        {
            GameObject playerObject = GameObject.Find("player");
            Player2 player = playerObject.GetComponent<Player2>();
            int currentScore = player.currentScore;
            player.currentScore = 0;
            PlayerPrefs.SetInt("currentScore",0);
            Destroy(target);
            Loss.SetActive(true);
            Invoke("Fail", 1f);
        }

        if (collision.CompareTag("Player") && hasCross == true) 
        {
            GameObject playerObject = GameObject.Find("player");
            Player2 player = playerObject.GetComponent<Player2>();
            int currentScore = player.currentScore;
            player.currentScore ++;
            gameObject.SetActive(false);
        }
    }

    private void Fail()
    {
        SceneManager.LoadScene("level1");
    }
}
