using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    // Update is called once per frame
    void Update()
    {
        //0 hp enemy destroys
        if(health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
//enemy takes damage
    public void Damage(float damage)
    {
        health -= damage;
    }
}
