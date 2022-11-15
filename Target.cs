using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //gives the enemy health
    public float health, startingHealth = 50f;

    public void TakeDamage(float amount, bool isInstaKill=false)
    {
        //game object gets destroyed if taken damage
        health -= amount;
        if (health <= 0 || isInstaKill)
        {
            Invoke("Respawn", 2f);

            GetComponent<MeshRenderer>().enabled = false;
            Gamemanager.score+=25; //adds 25 to score
        }
    }
    private void Respawn()
    {
        GetComponent<MeshRenderer>().enabled = true;

        health = startingHealth;
    }
}
