using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chaser : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;

    public enum Took_Coin
    {
        Coin_Taken,
        Coin_Not_Taken
    };

    public Took_Coin state = Took_Coin.Coin_Not_Taken;
    // Start is called before the first frame update
    void Start()
    {
        
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
    void Update()
    {       
        

            float speedDelta = (speed * Time.deltaTime);
            switch(state)
            {
            case Took_Coin.Coin_Taken:
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

            case Took_Coin.Coin_Not_Taken:
            StartCoroutine("CoinsTaken");
                
            break;

            }
    }
    IEnumerator CoinsTaken()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject playerObject = GameObject.Find("player");
        player Player = playerObject.GetComponent<player>();
        int Coins = Player.coins;
        
        if(Coins == 3)
        {
            state = Took_Coin.Coin_Taken;
        }
        
    }
}
