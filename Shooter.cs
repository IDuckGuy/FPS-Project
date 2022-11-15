using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public GameObject bullet;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //left click to shoot
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        } else if (Input.GetMouseButton(2)) {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        //clones bullets
        var clone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(clone, 10f);
    }
}
