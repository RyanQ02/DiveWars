using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource Shooting;

    public float fireRate = 0.4f;
    private float nextFire = 2f;

    void Update()
    {
        //checks if the user presses the fire button and if there is no cooldown left
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
    //fires a bullet
    void Shoot()
    {
        Shooting.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}