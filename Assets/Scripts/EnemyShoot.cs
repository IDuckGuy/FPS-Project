using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time + 5;
    }

// Update is called once per frame
void Update()
{
    if (time - Time.time <= 0)
    {
        Shoot();

        time += 5;
    }
}
void Shoot()
{
//clones bullets
    var clone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    Destroy(clone, 10f);
}
}
