using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    
    // Update is called once per frame
    void Update()
    {
        if(playerHealth <=0)
        {
            GameOver();
        }
    }

    // On trigger
    void OnTriggerEnter(Collider owother) {
        //  Whens we teaching the healthz, add health uwu
        if (owother.CompareTag("Health Item"))  playerHealth += 20; // healths awooooo~
    }
    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
