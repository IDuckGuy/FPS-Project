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
    void OnTriggerEnter(Collider other) {
        //  Whens we teaching the health, add health uwu
        if (other.CompareTag("Health Item"))  playerHealth += 20; // health
    }
    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
