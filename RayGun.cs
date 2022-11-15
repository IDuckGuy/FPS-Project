using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    // Start is called before the first frame update
    public float gunDamage;
    public float gunRange;
    public float fireRate;
    public GameObject firePoint;
    public int impactForce = 100;
    public float reloadTime;
    public int magSize;
    public int currentAmmo;
    public int reserveAmmo;

    private float nextFire;
    void Start()
    {
        currentAmmo = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        //Secondary fire right click
        if(Input.GetMouseButtonDown(1) && Time.time > nextFire && currentAmmo > 0)
        {
            GunShoot();
            currentAmmo--;
        }
        if(currentAmmo <= 0 && reserveAmmo > 0)
        {
            Reload();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            reserveAmmo = reserveAmmo + currentAmmo;
            currentAmmo = 0;
        }
    }

    void GunShoot()
    {
        //makes sure the raycast hits the desired target.
        RaycastHit hit;
        nextFire = Time.time * fireRate;
        if(Physics.Raycast(firePoint.transform.position,firePoint.transform.forward, out hit, gunRange))
        {
            //logs the damage and what it
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(gunDamage);
            }
            if(hit.rigidbody !=null)
            {
                Debug.Log("potato");
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    void Reload()
    {
        nextFire = Time.time + reloadTime;
        if(reserveAmmo > magSize)
        {
            reserveAmmo = reserveAmmo - magSize;
            currentAmmo = magSize;
        }
        else
        {
            currentAmmo = reserveAmmo;
            reserveAmmo = 0;
        }
    }
}
