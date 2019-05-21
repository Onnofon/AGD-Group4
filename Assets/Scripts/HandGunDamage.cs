using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour
{ 
    public GameObject projectile;
    public Transform projectileSpawn;

    public int damageAmount = 5;
    public float speedMod;
    public float allowedRange = 15f;
    public float shotDelay = 0.3333f;
    private float timeStamp;
    

    // Update is called once per frame 
    void Update()
    {
        if(Time.time >= timeStamp && Input.GetButtonDown("Fire1"))
        {
            Fire();
            AudioSource gunfire = GetComponent<AudioSource>();
            //GetComponent<Animation>().Play("GunFire");
            gunfire.Play();
            timeStamp = Time.time + shotDelay;
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speedMod;

        Destroy(bullet, 3.0f);
    }
}