using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 15;
    public Rigidbody2D rb;

    public float fireRate = 0.5f;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        // Automatically destroy any Bullets after 6 seconds.
        Destroy(gameObject, 6);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //if it hits an enemies hit box the enemy will be damaged
        if (hitInfo.gameObject.tag == "HitBox")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
        //if it hits the boss it will do damage to the boss
        else if (hitInfo.gameObject.tag == "Boss")
        {
            BossScript boss = hitInfo.GetComponent<BossScript>();
            if (boss != null)
                boss.TakeDamage(damage);

            Destroy(gameObject);
        }
        // If Bullet hits Edge of map, destroy it.
        else if (hitInfo.gameObject.tag == "MapCollider")
        {
            Destroy(gameObject);
        }
    }
}