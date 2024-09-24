using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject victory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.Find("player");

        Player player = playerObject.GetComponent<Player>();

        int coins = player.coins;

        if(coins >= 10)
        {
            victory.SetActive(true);
            Invoke("NewLevel", 0.5f);
        }
    }

    private void NewLevel()
    {
    Scene currentScene = SceneManager.GetActiveScene ();
    string sceneName = currentScene.name;



    SceneManager.LoadScene("level2");
    }
    
}
